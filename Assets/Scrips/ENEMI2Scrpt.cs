using UnityEngine;
using System.Collections;

public class ENEMI2Scrpt : MonoBehaviour
{
    // Velocidad del enemigo (movimiento en X y Y)
    Vector2 Velocity;

    // Controla el tiempo para cambiar dirección horizontal
    float next_mov_time;

    // Variable usada para alternar izquierda/derecha
    int par_impar;

    // Cantidad de disparos recibidos
    int hits;

    // Puntaje del jugador
    int Score;

    // Controla cuándo el enemigo dispara
    float next_spawn_bullet_time;

    // Prefab de la bala del enemigo
    public GameObject Bullet;

    // Referencia al script de sonidos
    SoundsScrip sound;

    // Sprite para efecto visual al recibir daño
    SpriteRenderer sprite;

    // Color original del sprite
    Color originalColor;

    // Color cuando recibe impacto
    public Color hitColor = Color.red;

    // Referencia al Rigidbody2D para movimiento físico
    Rigidbody2D rb;

    void Start()
    {
        // Obtener el Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Obtener el SpriteRenderer
        sprite = GetComponent<SpriteRenderer>();

        // Guardar el color original
        originalColor = sprite.color;

        // Inicializar tiempo de cambio de movimiento
        next_mov_time = Time.time;

        // Número aleatorio entre 1 y 2
        par_impar = Random.Range(1, 3);

        // Dirección vertical automática según posición inicial
        if (transform.position.y > 0)
        {
            Velocity.y = -0.02f; // Si está arriba, baja
        }
        else
        {
            Velocity.y = 0.02f; // Si está abajo, sube
            transform.rotation = Quaternion.Euler(0f, 0f, 180f); // Lo voltea
        }

        hits = 0; // Inicializa golpes

        // Tiempo inicial para disparar
        next_spawn_bullet_time = Time.time + Random.Range(0.6f, 1f);

        // Busca el objeto "Sounds" en la escena
        sound = GameObject.Find("Sounds").GetComponent<SoundsScrip>();
    }

    void Update()
    {
        // Disparo automático del enemigo
        if (Time.time > next_spawn_bullet_time)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            next_spawn_bullet_time = Time.time + Random.Range(1f, 2f);
        }



    }

    void FixedUpdate()
    {
        // Movimiento físico usando Rigidbody
        rb.position += Velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si recibe disparo normal
        if (collision.gameObject.CompareTag("Disparo"))
        {
            hits++; // Aumenta golpes

            StartCoroutine(HitEffect()); // Efecto visual

            Destroy(collision.gameObject); // Destruye bala

            if (hits >= 5)
            {
                // Suma puntos
                Score = PlayerPrefs.GetInt("Score");
                Score += 3;
                PlayerPrefs.SetInt("Score", Score);

                sound.PlaySonidoExpolsion(); // Sonido

                Destroy(gameObject); // Destruye enemigo
            }
        }

        // Si recibe disparo especial
        if (collision.gameObject.tag == "DisparoE2")
        {
            sound.PlaySonidoExpolsion();

            Score = PlayerPrefs.GetInt("Score");
            Score += 3;
            PlayerPrefs.SetInt("Score", Score);

            Destroy(gameObject);
        }
    }

    // Efecto visual cuando recibe daño
    IEnumerator HitEffect()
    {
        sprite.color = hitColor; // Cambia a rojo
        yield return new WaitForSeconds(0.1f); // Espera 0.1 segundos
        sprite.color = originalColor; // Regresa al color original
    }
}
