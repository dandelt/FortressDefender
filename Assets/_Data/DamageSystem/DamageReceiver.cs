using System;
using UnityEngine;

public abstract class DamageReceiver : DanMonoBehaviour
{
    [SerializeField] protected int currentHp = 10;
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] public bool isImmotal = false;

    public virtual void Receive(int damage, DamageSender damageSender)
    {
        if (!this.isImmotal) this.currentHp -= damage;
        if (this.currentHp < 0) this.currentHp = 0;

        if (this.IsDead()) this.OnDead();
        else OnHurt();
    }

    protected abstract void OnDead();

    protected abstract void OnHurt();

    public virtual bool IsDead()
    {
        return this.isDead = this.currentHp <= 0;
    }

    protected void OnEnable()
    {
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.currentHp = this.maxHp;
    }
}