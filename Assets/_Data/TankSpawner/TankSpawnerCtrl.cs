using UnityEngine;

public class TankSpawnerCtrl : DanSingleton<TankSpawnerCtrl>
{
    [SerializeField] protected TankSpawner spawner;
    public TankSpawner Spawner => spawner;
    [SerializeField] protected TankPrefabs prefabs;
    public TankPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if(this.spawner != null) return;
        this.spawner = transform.GetComponent<TankSpawner>();
        Debug.Log(transform.name + ": LoadSpawner",gameObject);
    }
    
    protected virtual void LoadPrefabs()
    {
        if(this.prefabs != null) return;
        this.prefabs = transform.GetComponentInChildren<TankPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs",gameObject);
    }
}
