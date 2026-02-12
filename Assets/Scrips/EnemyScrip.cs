using UnityEngine;

public class EnemyScrip : MonoBehaviour
{

    Vector2 Velocity;
    float next_mov_time;
    int par_impar;

    int hits;

    float next_spawn_bullet_time;
    public GameObject Bullet;

    void Start()
    {
        next_mov_time = Time.time;
        par_impar = Random.Range(1, 2);
        Velocity.y = -0.02f;
        hits = 0;
        next_spawn_bullet_time = Time.time + Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > next_spawn_bullet_time)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            next_spawn_bullet_time += Random.Range(1f, 5f);
        }
        if (Time.time > next_mov_time)
        {
            if (par_impar % 2 == 0)
            {
                Velocity.x = .1f;

            }
            else
            {
                Velocity.x = -.1f;

            }

            
            par_impar++;
            next_mov_time += Random.Range(1f, 5f); 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Disparo")
        {
            hits += 1;
            Destroy(collision.gameObject);
            if (hits == 3)
            {
                Destroy(gameObject);
            }
        }
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += Velocity;
    }
}
