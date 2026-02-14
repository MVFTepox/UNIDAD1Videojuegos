using System.Collections.Generic;
using UnityEngine;


public class MeteoroScript : MonoBehaviour
{
    Vector2 meteoro_velocity;

    public List<Sprite> sprites;
    int vida = 4;

    SoundsScrip sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float scaleX = Random.Range(0.2f, 1f);
        meteoro_velocity.y = Random.Range(-0.02f, 0.02f);
        transform.localScale = new Vector3(scaleX, scaleX,scaleX );
        sound = GameObject.Find("Sounds").GetComponent<SoundsScrip>();
    }

    // Update is called once per frame
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
            {
                GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
            if (vida == 2)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
            if (vida == 1)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[2];
            }
            int Score = PlayerPrefs.GetInt("Score");
            int Record = PlayerPrefs.GetInt("Record");
            if (Score > Record)
            {

                PlayerPrefs.SetInt("Record", Score);
            }

            if (vida == 0)
            {
                sound.PlaySonidoExpolsion();
                Score += 10;
                PlayerPrefs.SetInt("Score", Score);
                Destroy(gameObject);
            }
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
