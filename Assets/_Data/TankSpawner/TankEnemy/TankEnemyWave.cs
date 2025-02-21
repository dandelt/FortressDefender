using System;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyWave : DanMonoBehaviour
{
    [SerializeField] protected TankSpawnerCtrl ctrl;
    [SerializeField] protected float speedSpawn = 3f;
    [SerializeField] protected int maxSpawn = 3;
    [SerializeField] protected List<TankCtrl> spawnedEnemies = new();
    [SerializeField] protected EffectCode summonCode = EffectCode.Summon;
    //private EffectCtrl currentEffect;


    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Spawning), this.speedSpawn);
    }

    protected void FixedUpdate()
    {
        if (spawnedEnemies == null || spawnedEnemies.Count == 0) return;
        RemoveDeadOne();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    // private void Update()
    // {
    //     if (isDespawning)
    //     {
    //         despawnTimer -= Time.deltaTime;
    //         if (despawnTimer <= 0f)
    //         {
    //             EffectSpawnerCtrl.Instance.Spawner.Despawn(currentEffect);
    //             isDespawning = false;
    //         }
    //     }
    // }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = this.GetComponent<TankSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.speedSpawn);
        if (this.spawnedEnemies.Count >= maxSpawn) return;
        Transform pos = FirePointSpawnEnemy.Instance.RandomPos();
        //this.SpawnSummon(pos);
        TankCtrl prefab = this.ctrl.Prefabs.GetRandom();
        TankCtrl newTankEnemy = this.ctrl.Spawner.Spawn(prefab, pos.position, pos.rotation);
        newTankEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newTankEnemy);
    }

    // protected virtual void SpawnSummon(Transform pos)
    // {
    //     EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.summonCode.ToString());
    //     currentEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, pos.position, pos.rotation);
    //     currentEffect.gameObject.SetActive(true);
    //
    //     isDespawning = true;
    //     despawnTimer = 0.5f;
    // }

    protected virtual void RemoveDeadOne()
    {
        foreach (TankCtrl child in spawnedEnemies)
        {
            if (child.EnemyReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(child);
                return;
            }
        }
    }
}