// using UnityEngine;
//
// public abstract class TankCtrl : PoolObj
// {
//     [SerializeField] protected TankEnemyDamageReceiver enemyReceiver;
//     public TankEnemyDamageReceiver EnemyReceiver => enemyReceiver;
//     [SerializeField] protected TankPlayerDamageReceiver playerReceiver;
//     public TankPlayerDamageReceiver PlayerReceiver => playerReceiver;
//
//     protected override void LoadComponents()
//     {
//         base.LoadComponents();
//         this.LoadEnemyDamageReceiver();
//         this.LoadPlayerDamageReceiver();
//     }
//
//     protected virtual void LoadEnemyDamageReceiver()
//     {
//         if (this.enemyReceiver != null) return;
//         this.enemyReceiver = transform.GetComponentInChildren<TankEnemyDamageReceiver>();
//         Debug.Log(transform.name + " LoadEnemyDamageReceiver", gameObject);
//     }
//
//     protected virtual void LoadPlayerDamageReceiver()
//     {
//         if (this.playerReceiver != null) return;
//         this.playerReceiver = transform.GetComponentInChildren<TankPlayerDamageReceiver>();
//         Debug.Log(transform.name + " LoadEnemyDamageReceiver", gameObject);
//     }
// }

