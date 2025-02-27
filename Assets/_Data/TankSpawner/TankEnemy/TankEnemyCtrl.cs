using UnityEngine;

public class TankEnemyCtrl : TankCtrl
{
    [SerializeField] protected Rigidbody2D rigid;
    public Rigidbody2D Rigid => rigid;
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Transform moving;
    public Transform Moving => moving;

    [SerializeField] protected Transform shooting;
    public Transform Shooting => shooting;

    private bool isFrozen = false;


    public override string GetName()
    {
        return "TankEnemyCtrl";
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadModel();
        this.LoadMoving();
        this.LoadShooting();
    }

    protected virtual void LoadMoving()
    {
        if (this.moving != null) return;
        this.moving = transform.Find("Moving");
        Debug.Log(transform.name + " LoadMoving", gameObject);
    }

    protected virtual void LoadShooting()
    {
        if (this.shooting != null) return;
        this.shooting = transform.Find("Shooting");
        Debug.Log(transform.name + " LoadShooting", gameObject);
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

    public void FreezeTank()
    {
        isFrozen = true;
        DisableMovementAndShooting();
    }

    public void UnfreezeTank()
    {
        isFrozen = false;
        EnableMovementAndShooting();
    }

    private void DisableMovementAndShooting()
    {
        this.moving.gameObject.SetActive(false);
        this.shooting.gameObject.SetActive(false);
    }

    private void EnableMovementAndShooting()
    {
        this.moving.gameObject.SetActive(true);
        this.shooting.gameObject.SetActive(true);
    }

    void Update()
    {
        if (isFrozen) return;
    }
}