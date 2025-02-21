using UnityEngine;

public class TankEnemyAbstract : DanMonoBehaviour
{
    [SerializeField] protected TankEnemyCtrl ctrl;
    public TankEnemyCtrl Ctrl => ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<TankEnemyCtrl>();
        Debug.Log(transform.name + " LoadCtrl", gameObject);
    }
}