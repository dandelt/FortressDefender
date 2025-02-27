using System;
using UnityEngine;

public class ClockManager : DanSingleton<ClockManager>
{
    [SerializeField] protected float freezeDuration = 5.0f;
    [SerializeField] protected float freezeTimer = 0f;

    private void Update()
    {
        if (freezeTimer > 0)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                UnfreezeAllEnemies();
            }
        }
    }

    public void ActivateClock()
    {
        freezeTimer = freezeDuration;
        FreezeAllEnemies();
    }

    public virtual void FreezeAllEnemies()
    {
        foreach (TankEnemyCtrl enemy in FindObjectsByType<TankEnemyCtrl>(FindObjectsSortMode.None))
        {
            enemy.FreezeTank();
        }
    }

    public virtual void UnfreezeAllEnemies()
    {
        foreach (TankEnemyCtrl enemy in FindObjectsByType<TankEnemyCtrl>(FindObjectsSortMode.None))
        {
            enemy.UnfreezeTank();
        }
    }
}