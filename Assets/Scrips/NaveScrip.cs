

using System.Collections.Generic;
using UnityEngine;

public class NaveScrip : MonoBehaviour
{
    Vector2 nave_position;
    public GameObject disparo;
    public GameObject disparo2;
    public GameObject disparo3;


    public GameObject buttonNewGame;
    public GameObject RecordText;

    public GameObject buttonReturnToMenu;
    public List<GameObject> vidas;

    float angulo_incial;
    public Camera maincamera;

    int tipo_arma;
    float time_powerup;

    int num_vidas;

    public SoundsScrip sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tipo_arma = 0;
        maincamera = Camera.main;
        angulo_incial = 270;
        num_vidas = vidas.Count;
        time_powerup = Time.time;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mausePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mausePos - transform.position;
        direction.z = 0;

        float angleRad = Mathf.Atan2(direction.y, direction.x);

        float angleGrad = angleRad * Mathf.Rad2Deg;

        angleGrad += angulo_incial;
        // 
        transform.rotation = Quaternion.Euler(0, 0, angleGrad);
        if (Input.GetKeyDown(KeyCode.A))
        {
            nave_position.x = -0.1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            nave_position.x = 0.1f;
        }
        if ((Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.D)))
        {
            nave_position.x = 0f;

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            nave_position.y = 0f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            nave_position.y = 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            nave_position.y = -0.1f;
        }


        if (Input.GetMouseButtonDown(0))
        {

            PlayerPrefs.SetInt("tipo_arma", tipo_arma);
            float angulo = transform.rotation.eulerAngles.z;
            if (angulo >= 0 && angulo <= 90)
            {
                float fuerza1 = angulo / 90;
                float fuerza2 = 1 - fuerza1;
                PlayerPrefs.SetFloat("fuerzaX", -fuerza1);
                PlayerPrefs.SetFloat("fuerzaY", fuerza2);
            }
            if (angulo >= 90 && angulo <= 180)
            {
                float fuerza1 = (angulo - 90) / 90;
                float fuerza2 = 1 - fuerza1;

                PlayerPrefs.SetFloat("fuerzaX", -fuerza2);
                PlayerPrefs.SetFloat("fuerzaY", -fuerza1);
            }
            if (angulo >= 180 && angulo <= 270)
            {
                float fuerza1 = (angulo - 180) / 90;
                float fuerza2 = 1 - fuerza1;

                PlayerPrefs.SetFloat("fuerzaX", fuerza1);
                PlayerPrefs.SetFloat("fuerzaY", -fuerza2);
            }
            if (angulo >= 270 && angulo <= 360)
            {
                float fuerza1 = (angulo - 270) / 90;
                float fuerza2 = 1 - fuerza1;

                PlayerPrefs.SetFloat("fuerzaX", fuerza2);
                PlayerPrefs.SetFloat("fuerzaY", fuerza1);
            }

            if (tipo_arma == 0)
            {
                Instantiate(disparo, transform.position, transform.rotation);
                sound.PlaySonidoDisparo();

            }
            else if (tipo_arma == 1)
            {
                Instantiate(disparo2, transform.position, transform.rotation);
                sound.PlaySonidoDisparo2();

            }
            else if (tipo_arma == 2)
            {
                Instantiate(disparo3, transform.position, transform.rotation);
                sound.PlaySonidoCargaSismica();

            }

            // Control del tiempo del powerup
            if (tipo_arma != 0 && Time.time > time_powerup)
            {
                tipo_arma = 0;
            }


        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "METEORO" || collision.gameObject.tag == "DisparoE" || collision.gameObject.tag == "naveEnemiga")
        {
            num_vidas -= 1;
            sound.PlaySonidoHit();
            vidas[num_vidas].SetActive(false);
            Destroy(collision.gameObject);
            tipo_arma = 0;
            if (num_vidas == 0)
            {
                transform.position = new Vector3(0, 0, 0);
                Destroy(gameObject);
                buttonNewGame.SetActive(true);
                RecordText.SetActive(true);
                buttonReturnToMenu.SetActive(true);
            }

        }

        if (collision.gameObject.tag == "POWERUP")
        {
            Destroy(collision.gameObject);
            tipo_arma = 1;
            time_powerup = Time.time + 5f;
            PlayerPrefs.SetInt("tipo_arma", tipo_arma);
            sound.PlaySonidoPowerUp();
        }

        if (collision.gameObject.tag == "POWERUP2")
        {
            Destroy(collision.gameObject);
            tipo_arma = 2;
            time_powerup = Time.time + 3f;
            PlayerPrefs.SetInt("tipo_arma", tipo_arma);
            sound.PlaySonidoPowerUp();
        }

        if (collision.gameObject.CompareTag("Recover"))
        {
            foreach (GameObject vida in vidas)
            {
                vida.SetActive(true);
            }
            num_vidas = 5;
            Destroy(collision.gameObject);
            sound.PlaySonidoRecovery();
        }


    }



    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += nave_position;
    }
}
