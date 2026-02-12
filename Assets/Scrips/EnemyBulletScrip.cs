using UnityEngine;

public class EnemyBulletScrip : MonoBehaviour
{

    Vector2 bullet_Velocity;

    void Start()
    {
        bullet_Velocity.y = -0.1f;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += bullet_Velocity;
    }
    void Update()
    {

    }
}
