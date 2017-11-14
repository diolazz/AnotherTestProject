using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 10;
    //[SerializeField] private LayerMask collisionLayerMask;

    private float lifeTime = 3f;
    private float timer;


    void Start()
    {
        timer = lifeTime;
    }

    void Update()
    {
        if (timer <= 0)
        {
            Destroy();
        }

        float moveDistance = Time.deltaTime*speed;
        transform.Translate(Vector2.up*moveDistance);
        timer -= Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var hit = collider.gameObject;
        var polygon = hit.GetComponent<IDamageable>();

        if (polygon != null)
        {
            polygon.TakeDamage(damage);
            Destroy();
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public override void OnObjectReuse()
    {
        timer = lifeTime;
    }
}
