using System;
using UnityEngine;

public class InputManager : DanSingleton<InputManager>
{
    [SerializeField] protected Vector2 moveDirection;
    public Vector2 MoveDirection => moveDirection;

    [SerializeField] protected bool isShootPressed = false;
    public bool IsShootPressed => isShootPressed;

    [SerializeField] protected bool isPause = false;
    public bool IsPause => isPause;
    [SerializeField] protected bool isContinue = false;
    public bool IsContinue => isContinue;


    protected void Update()
    {
        this.HandleMovementInput();
        this.HandleShootingInput();
        this.TogglePause();
        this.ToggleContinue();
    }

    protected virtual void HandleMovementInput()
    {
        this.moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    protected virtual void HandleShootingInput()
    {
        this.isShootPressed = Input.GetKeyDown(KeyCode.Space);
    }

    protected virtual void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.GamePause();
        }
    }

    protected virtual void ToggleContinue()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.Instance.ResumeGame();
        }
    }
}