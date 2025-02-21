using System;
using UnityEngine;

public class TankPlayerMoving : TankPlayerAbstract
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected Vector2 playerInput;


    protected void Update()
    {
        this.Moving();
        this.FlipToDirection();
    }

    protected virtual void Moving()
    {
        this.playerInput = InputManager.Instance.MoveDirection;
        if (playerInput.x != 0) playerInput.y = 0;
        this.ctrl.Rigid.linearVelocity = playerInput.normalized * speed;
    }


    protected virtual void FlipToDirection()
    {
        if (playerInput == Vector2.zero) return;

        float angle = 0f;

        if (playerInput.x > 0) angle = -90f;
        else if (playerInput.x < 0) angle = 90f;
        else if (playerInput.y > 0) angle = 0f;
        else if (playerInput.y < 0) angle = 180f;

        this.ctrl.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}