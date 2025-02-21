using UnityEngine;

public class TankPlayerSpawnerCtrl : DanSingleton<TankPlayerSpawnerCtrl>
{
    [SerializeField] protected TankPlayerSpawner spawner;
    public TankPlayerSpawner Spawner => spawner;
    [SerializeField] protected TankPlayerPrefabs prefabs;
    public TankPlayerPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<TankPlayerSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = transform.GetComponentInChildren<TankPlayerPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}