using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TankEnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected TankCtrl ctrl;
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected EffectCode smokeCode = EffectCode.Smoke;

    protected override void Reset()
    {
        base.Reset();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        this.currentHp = 1;
        this.maxHp = 1;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadTankCtrl();
    }

    protected virtual void LoadTankCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<TankCtrl>();
        Debug.Log(transform.name + " LoadTankCtrl", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = this.GetComponent<BoxCollider2D>();
        this.boxCollider.offset = new Vector2(-0.03f, 0f);
        this.boxCollider.size = new Vector2(0.83f, 0.87f);
    }

    protected override void OnDead()
    {
        this.SpawnSmoke();
        this.DoDespawn();
        FindFirstObjectByType<EnemyUI>().EnemyDestroyed();

        InventoriesManager.Instance.AddItem(ItemCode.Star, 1);
        InventoriesManager.Instance.AddItem(ItemCode.Clock, 1);
        //item
    }

    protected override void OnHurt()
    {
        //throw new System.NotImplementedException();
    }

    protected virtual void DoDespawn()
    {
        this.ctrl.Despawn.DoDespawn();
    }

    protected virtual void SpawnSmoke()
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.smokeCode.ToString());
        EffectCtrl newImpact =
            EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, transform.parent.position, transform.parent.rotation);
        newImpact.gameObject.SetActive(true);
    }
}