using UnityEngine;

public class ShovelCtrl : ItemCtrl
{
    public override string GetName()
    {
        return "ShovelCtrl";
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