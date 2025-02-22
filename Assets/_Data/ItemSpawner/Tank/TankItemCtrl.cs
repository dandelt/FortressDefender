using UnityEngine;

public class TankItemCtrl : ItemCtrl
{
    public override string GetName()
    {
        return "TankItemCtrl";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.Despawn.DoDespawn();
            ApplyEffect(other.gameObject);
        }
    }

    private void ApplyEffect(GameObject player)
    {
        Debug.Log(player.name + " nhận được item!");
    }
}