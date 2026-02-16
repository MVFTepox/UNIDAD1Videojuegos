using UnityEngine;

public class EnemyBullet2Scrip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 bullet_Velocity;

    void Start()
    {
        if (transform.position.y > 0)
        {
            bullet_Velocity.y = -0.1f;
        }
        else
        {
            bullet_Velocity.y = 0.1f;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += bullet_Velocity;
    }



 void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Disparo" || collision.gameObject.tag == "DisparoE2")
        {
            Destroy(gameObject);
        }
    }
}
