using UnityEngine;

public class ClockCtrl : ItemCtrl
{
    public override string GetName()
    {
        return "ClockCtrl";
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.Despawn.DoDespawn();
            ClockManager.Instance.ActivateClock();
        }
    }
}