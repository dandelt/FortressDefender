using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankPlayerWave : DanMonoBehaviour
{
    [SerializeField] protected TankPlayerSpawnerCtrl ctrl;
    [SerializeField] protected float speedSpawn = 3f;
    [SerializeField] protected int maxSpawn = 1;
    [SerializeField] protected List<TankPCtrl> spawnedPlayers = new();
    [SerializeField] protected EffectCode summonCode = EffectCode.Summon;
    //private EffectCtrl currentEffect;


    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Spawning), this.speedSpawn);
    }

    protected void FixedUpdate()
    {
        if (spawnedPlayers == null || spawnedPlayers.Count == 0) return;
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
        this.ctrl = this.GetComponent<TankPlayerSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.speedSpawn);
        if (this.spawnedPlayers.Count >= maxSpawn) return;

        //this.SpawnSummon(pos);
        TankPCtrl prefab = this.ctrl.Prefabs.GetRandom();
        TankPCtrl newTankEnemy = this.ctrl.Spawner.Spawn(prefab, prefab.transform.position, prefab.transform.rotation);
        newTankEnemy.gameObject.SetActive(true);
        this.spawnedPlayers.Add(newTankEnemy);
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
        foreach (TankPCtrl child in spawnedPlayers)
        {
            if (child.PlayerReceiver.IsDead())
            {
                this.spawnedPlayers.Remove(child);
                return;
            }
        }
    }
}