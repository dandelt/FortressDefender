using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(CircleCollider2D))]
public class BulletDamageSender : DamageSender
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected BulletCtrl ctrl;
    [SerializeField] protected EffectCode impactCode = EffectCode.Impact;

    [SerializeField] protected string shooterTag;

    // public GameObject bulletImpactPrefab; // Prefab chứa vết đạn
    // public Tilemap tilemap; // Tilemap của tường
    public LayerMask wallLayer; // Layer của tường
    public float raycastOffset = 0.2f; // Khoảng cách Raycast bắt đầu trước viên đạn
    public float raycastDistance = 0.3f; // Khoảng cách của Raycast

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected override void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = this.GetComponent<Collider2D>();
        this._collider.isTrigger = true;
        this.circleCollider = (CircleCollider2D)this._collider;
        this.circleCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected override void Send(Collider2D other)
    {
        Debug.Log("Đạn chạm vào: " + other.gameObject.name, gameObject);
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        this.SpawnImpact();

        //fix again
        if (other.CompareTag("Player") && ctrl.shooterTag != "Player")
        {
            // Nếu đạn do Enemy bắn và trúng Player → Trừ máu Player
            damageReceiver.Receive(this.damage, this);
            this.ctrl.Despawn.DoDespawn();
            return;
        }

        if (other.CompareTag("Enemy") && ctrl.shooterTag != "Enemy")
        {
            // Nếu đạn do Player bắn và trúng Enemy → Trừ máu Enemy
            damageReceiver.Receive(this.damage, this);
            this.ctrl.Despawn.DoDespawn();
            return;
        }

        if (other.TryGetComponent<BrickWall>(out BrickWall brickWall))
        {
            Debug.Log($"🧱 Xóa gạch tại vị trí viên đạn chạm vào: {transform.position}");
            brickWall.TakeDamage(transform.position);
        }

        this.ctrl.Despawn.DoDespawn();
    }

    protected virtual void SpawnImpact()
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.impactCode.ToString());
        EffectCtrl newImpact =
            EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, transform.parent.position, transform.parent.rotation);
        newImpact.gameObject.SetActive(true);
    }
}