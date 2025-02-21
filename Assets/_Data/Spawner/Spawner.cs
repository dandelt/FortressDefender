using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : DanMonoBehaviour where T : PoolObj
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObjs = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = this.transform.Find("Holder");
        if (this.holder == null)
        {
            this.holder = new GameObject("Holder").transform;
            this.holder.parent = transform;
        }
    }

    public virtual T Spawn(T prefab)
    {
        T newObj = this.GetFromPool(prefab);
        if (newObj == null)
        {
            newObj = Instantiate(prefab);
            spawnCount++;
            this.UpdateName(prefab.transform, newObj.transform);
            newObj.transform.parent = this.holder;
        }

        return newObj;
    }

    public virtual T Spawn(T prefab, Vector3 position)
    {
        T newObj = this.Spawn(prefab);
        newObj.transform.position = position;
        return newObj;
    }

    public virtual T Spawn(T prefab, Vector3 position, Quaternion rotation)
    {
        T newObj = this.Spawn(prefab, position);
        newObj.transform.rotation = rotation;
        return newObj;
    }


    protected virtual T GetFromPool(T prefab)
    {
        foreach (T inPoolObj in inPoolObjs)
        {
            if (inPoolObj.GetName() == prefab.GetName())
            {
                this.RemoveFromPool(inPoolObj);
                return inPoolObj;
            }
        }

        return null;
    }

    protected virtual void RemoveFromPool(T prefab)
    {
        this.inPoolObjs.Remove(prefab);
    }

    public virtual void Despawn(T prefab)
    {
        if (prefab is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.inPoolObjs.Add(prefab);
        }
    }

    protected virtual void UpdateName(Transform prefab, Transform newObj)
    {
        newObj.name = prefab.name + "_" + this.spawnCount;
    }
}