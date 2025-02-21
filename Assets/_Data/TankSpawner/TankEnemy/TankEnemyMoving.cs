using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankEnemyMoving : TankEnemyAbstract
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float stuckTime = 0f;
    [SerializeField] protected Vector2 moveDirection;
    [SerializeField] protected float positionUpdateTime = 0.5f;
    [SerializeField] protected Vector2 lastPosition;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeChangeDirection = 5f;
    [SerializeField] protected List<Vector2> directions = new();
    [SerializeField] protected LayerMask obstacleLayer = 1;
    [SerializeField] protected bool isStopped = false;
    [SerializeField] protected Transform firePoint1;
    [SerializeField] protected Transform firePoint2;

    protected override void Start()
    {
        this.lastPosition = transform.parent.position;
        this.ChangeDirection();
    }

    protected void FixedUpdate()
    {
        this.Ctrl.Rigid.linearVelocity = this.speed * this.moveDirection;
    }

    protected void Update()
    {
        this.FlipToDirection();
        this.MoveByTime();
        this.CheckIsStuck();
        this.CheckingCollisions();
    }

    protected virtual void MoveByTime()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeChangeDirection) return;
        this.ChangeDirection();
        this.timer = 0f;
    }

    protected virtual void CheckIsStuck()
    {
        if (Vector2.Distance(transform.parent.position, lastPosition) < 0.5f)
        {
            this.stuckTime += Time.deltaTime;
            if (this.stuckTime >= 0.5f)
            {
                ChangeDirection();
                this.stuckTime = 0f;
            }
        }
        else
        {
            this.stuckTime = 0f;
        }

        this.positionUpdateTime += Time.deltaTime;
        if (this.positionUpdateTime >= 0.5f)
        {
            this.lastPosition = transform.parent.position;
            this.positionUpdateTime = 0f;
        }
    }

    protected virtual void CheckingCollisions()
    {
        Vector2 rayOrigin1 = (Vector2)transform.position + moveDirection * 0.5f;
        Vector2 rayOrigin2 = (Vector2)firePoint1.transform.position + moveDirection * 0.5f;
        Vector2 rayOrigin3 = (Vector2)firePoint2.transform.position + moveDirection * 0.5f;

        RaycastHit2D hit1 = Physics2D.Raycast(rayOrigin1, moveDirection, 0.005f, obstacleLayer);
        Debug.DrawRay(transform.position, moveDirection * 1f, Color.red);
        RaycastHit2D hit2 = Physics2D.Raycast(rayOrigin2, moveDirection, 0.005f, obstacleLayer);
        Debug.DrawRay(firePoint1.transform.position, moveDirection * 1f, Color.red);
        RaycastHit2D hit3 = Physics2D.Raycast(rayOrigin3, moveDirection, 0.005f, obstacleLayer);
        Debug.DrawRay(firePoint2.transform.position, moveDirection * 1f, Color.red);

        if (hit1.collider != null || hit2.collider != null || hit3.collider != null)
        {
            this.Ctrl.Rigid.linearVelocity = Vector2.zero;
            this.ChangeDirection();
        }
    }

    protected virtual void ChangeDirection()
    {
        this.timer = 0;
        if (directions == null || directions.Count == 0)
        {
            directions = new List<Vector2> { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        }

        moveDirection = directions[Random.Range(0, directions.Count)];
    }


    protected virtual void FlipToDirection()
    {
        float angle = 0f;
        if (moveDirection.x > 0) angle = -90f;
        else if (moveDirection.x < 0) angle = 90f;
        else if (moveDirection.y > 0) angle = 0f;
        else if (moveDirection.y < 0) angle = 180f;

        this.ctrl.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}