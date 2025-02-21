using UnityEngine;

public class EffectSpawnerCtrl : DanSingleton<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner spawner;
    public EffectSpawner Spawner => spawner;
    [SerializeField] protected EffectPrefabs prefabs;
    public EffectPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if(this.spawner != null) return;
        this.spawner = transform.GetComponent<EffectSpawner>();
        Debug.Log(transform.name + ": LoadSpawner",gameObject);
    }
    
    protected virtual void LoadPrefabs()
    {
        if(this.prefabs != null) return;
        this.prefabs = transform.GetComponentInChildren<EffectPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs",gameObject);
    }
}
