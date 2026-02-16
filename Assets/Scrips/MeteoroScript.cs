using System.Collections.Generic;
using UnityEngine;

public class MeteoroScript : MonoBehaviour
{
    Vector2 meteoro_velocity;

    public List<Sprite> sprites;
    int vida = 4;

    SoundsScrip sound;

    void Start()
    {
        float scaleX = Random.Range(0.2f, 0.5f);

        meteoro_velocity.x = 0f;

        // Detectamos si está arriba o abajo
        if (transform.position.y > 0)
        {
            meteoro_velocity.y = -0.02f; // si está arriba, baja
        }
        else
        {
            meteoro_velocity.y = 0.02f; // si está abajo, sube
        }

        transform.localScale = new Vector3(scaleX, scaleX, scaleX);
        sound = GameObject.Find("Sounds").GetComponent<SoundsScrip>();
    }

    void Update()
    {
        transform.Rotate(Vector3.back);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Disparo")
        {
            vida -= 1;
            Destroy(collision.gameObject);

            if (vida == 3)
                GetComponent<SpriteRenderer>().sprite = sprites[0];

            if (vida == 2)
                GetComponent<SpriteRenderer>().sprite = sprites[1];

            if (vida == 1)
                GetComponent<SpriteRenderer>().sprite = sprites[2];

            int Score = PlayerPrefs.GetInt("Score");
            int Record = PlayerPrefs.GetInt("Record");

            if (Score > Record)
                PlayerPrefs.SetInt("Record", Score);

            if (vida == 0)
            {
                sound.PlaySonidoExpolsion();
                Score += 1;
                PlayerPrefs.SetInt("Score", Score);
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "DisparoE2")
        {
            sound.PlaySonidoExpolsion();
            int Score = PlayerPrefs.GetInt("Score");
            Score += 1;
            PlayerPrefs.SetInt("Score", Score);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += meteoro_velocity;
    }
}
