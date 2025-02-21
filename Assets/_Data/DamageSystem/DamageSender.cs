using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class DamageSender : DanMonoBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected Collider2D _collider;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        this.Send(other);
    }

    protected virtual void Send(Collider2D other)
    {
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        damageReceiver.Receive(this.damage, this);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadCollider();
    }

    protected virtual void LoadRigid()
    {
        if (this.rigid != null) return;
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.rigid.bodyType = RigidbodyType2D.Kinematic;
        Debug.Log(transform.name + " LoadRigid", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = this.GetComponent<Collider2D>();
        this._collider.isTrigger = true;
    }
}