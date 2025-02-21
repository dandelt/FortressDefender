using UnityEngine;

public abstract class TankPCtrl : PoolObj
{
    [SerializeField] protected TankPlayerDamageReceiver playerReceiver;
    public TankPlayerDamageReceiver PlayerReceiver => playerReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerDamageReceiver();
    }


    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerReceiver != null) return;
        this.playerReceiver = transform.GetComponentInChildren<TankPlayerDamageReceiver>();
        Debug.Log(transform.name + " LoadEnemyDamageReceiver", gameObject);
    }
}