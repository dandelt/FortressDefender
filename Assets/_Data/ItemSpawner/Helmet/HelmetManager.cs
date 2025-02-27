using UnityEngine;

public class HelmetManager : DanSingleton<HelmetManager>
{
    [SerializeField] protected float invincibilityDuration = 5.0f;
    [SerializeField] protected float invincibilityTimer = 0f;
    [SerializeField] protected bool checkInvincible;


    public void ActivateHelmet()
    {
        TankPlayerDamageReceiver isInvincible = FindAnyObjectByType<TankPlayerDamageReceiver>();
        this.checkInvincible = isInvincible.isImmotal = true;
        invincibilityTimer = invincibilityDuration;
        //GetComponent<Renderer>().material.color = Color.yellow;
    }

    void Update()
    {
        if (checkInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            if (invincibilityTimer <= 0)
            {
                TankPlayerDamageReceiver isInvincible = FindAnyObjectByType<TankPlayerDamageReceiver>();
                this.checkInvincible = isInvincible.isImmotal = false;
            }
        }
    }

    public bool IsInvincible()
    {
        return checkInvincible;
    }
}