using UnityEngine;

public abstract class TankCtrl : PoolObj
{
    [SerializeField] protected TankEnemyDamageReceiver enemyReceiver;
    public TankEnemyDamageReceiver EnemyReceiver => enemyReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDamageReceiver();
    }

    protected virtual void LoadEnemyDamageReceiver()
    {
        if (this.enemyReceiver != null) return;
        this.enemyReceiver = transform.GetComponentInChildren<TankEnemyDamageReceiver>();
        Debug.Log(transform.name + " LoadEnemyDamageReceiver", gameObject);
    }
}