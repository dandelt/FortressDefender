using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    public float speed = 10f;

    protected void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        transform.parent.Translate(Vector2.up * (this.speed * Time.deltaTime));
    }
}
