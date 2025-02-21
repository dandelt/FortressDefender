using System;
using UnityEngine;

public class InputManager : DanSingleton<InputManager>
{
    [SerializeField] protected Vector2 moveDirection;
    public Vector2 MoveDirection => moveDirection;
    
    [SerializeField] protected bool isShootPressed = false;
    public bool IsShootPressed => isShootPressed;

    protected void Update()
    {
        this.HandleMovementInput();
        this.HandleShootingInput();
    }

    protected virtual void HandleMovementInput()
    {
        this.moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    protected virtual void HandleShootingInput()
    {
        this.isShootPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
