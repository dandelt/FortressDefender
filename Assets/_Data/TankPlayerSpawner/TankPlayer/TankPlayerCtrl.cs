using UnityEngine;

public class TankPlayerCtrl : TankPCtrl
{
    [SerializeField] protected Rigidbody2D rigid;
    public Rigidbody2D Rigid => rigid;
    [SerializeField] protected Transform model;
    public Transform Model => model;

    public override string GetName()
    {
        return "TankPlayerCtrl";
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + " LoadModel", gameObject);
    }

    protected virtual void LoadRigid()
    {
        if (this.rigid != null) return;
        this.rigid = this.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ":LoadRigid", gameObject);
    }
}