using UnityEngine;

public class ItemSpawnerCtrl : DanSingleton<ItemSpawnerCtrl>
{
    [SerializeField] protected ItemSpawner spawner;
    public ItemSpawner Spawner => spawner;
    [SerializeField] protected ItemPrefabs prefabs;
    public ItemPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<ItemSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = transform.GetComponentInChildren<ItemPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}