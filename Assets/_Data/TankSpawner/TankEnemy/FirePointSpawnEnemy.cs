using System.Collections.Generic;
using UnityEngine;

public class FirePointSpawnEnemy : DanSingleton<FirePointSpawnEnemy>
{
    [SerializeField] List<Transform> firePoints;
    public List<Transform> FirePoints => firePoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePointSpawn();
    }

    protected virtual void LoadFirePointSpawn()
    {
        if (this.firePoints.Count > 0) return;
        foreach (Transform child in transform)
        {
            Transform point = child.GetComponent<FirePointSpawn>().transform;
            if (point == null) continue;
            this.firePoints.Add(point);
        }

        Debug.Log(transform.name + ": LoadFirePointSpawn", gameObject);
    }

    public virtual Transform RandomPos()
    {
        int rand = Random.Range(0, this.firePoints.Count);
        return this.firePoints[rand];
    }
}