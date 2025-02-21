using System;
using UnityEngine;

public class TankPlayerShooting : TankPlayerAbstract
{
    [SerializeField] protected FirePoint firePoint;
    [SerializeField] protected EffectCode bulletCode = EffectCode.Bullet;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float shootTimer = 0;
    [SerializeField] protected float shootDelay = 1f;
    public string shooterTag;

    protected void Update()
    {
        this.Shooting();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoint();
    }

    protected virtual void LoadFirePoint()
    {
        if (this.firePoint != null) return;
        this.firePoint = this.Ctrl.Model.GetComponentInChildren<FirePoint>();
    }

    protected virtual void Shooting()
    {
        this.shootTimer += Time.deltaTime;
        if (!InputManager.Instance.IsShootPressed) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        this.SpawnBullet();
    }

    protected virtual EffectCtrl SpawnBullet()
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.bulletCode.ToString());
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position,
            firePoint.transform.rotation);
        newEffect.gameObject.SetActive(true);

        EffectCtrl bulletScript = newEffect.GetComponent<EffectCtrl>();
        bulletScript.shooterTag = gameObject.tag;
        return newEffect;
    }
}