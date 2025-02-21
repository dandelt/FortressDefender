using UnityEngine;

public class TankPlayerAbstract : DanMonoBehaviour
{
    [SerializeField] protected TankPlayerCtrl ctrl;
    public TankPlayerCtrl Ctrl => ctrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if(this.ctrl != null) return;
        this.ctrl = GetComponentInParent<TankPlayerCtrl>();
        Debug.Log(transform.name + " LoadCtrl",gameObject);
    }
}
