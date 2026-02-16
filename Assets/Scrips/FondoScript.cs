using UnityEngine;
using UnityEngine.SceneManagement;

public class FondoScript : MonoBehaviour
{
    float next_time_spawn;
    public float spawn_rate;

    public GameObject meteoro;

    float next_time_powerup;
    public GameObject powerup;

    float next_time_powerup2;   // segundo power
    public GameObject powerup2; // segundo power

    float next_time_recover;
    public GameObject recover;

    float next_time_NaveEnemiga;
    public GameObject naveEnemiga;

    float next_time_NaveEnemiga2;
    public GameObject naveEnemiga2;

    public void newGameInit()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        if (!PlayerPrefs.HasKey("Record"))
        {
            PlayerPrefs.SetInt("Record", 0);
        }

        next_time_spawn = Time.time;
        next_time_powerup = Time.time + 5f;
        next_time_powerup2 = Time.time + 7f; // segundo power
        next_time_recover = Time.time + 6f;
        next_time_NaveEnemiga = Time.time + 5f;
        next_time_NaveEnemiga2 = Time.time + 10f;
    }

    void Update()
    {
        // METEORO arriba o abajo
        if (Time.time > next_time_spawn)
        {
            float yPos = Random.value > 0.5f ? 3.5f : -3.5f;
            Instantiate(meteoro, new Vector2(Random.Range(-7, 8f), yPos), Quaternion.identity);
            next_time_spawn = Time.time + spawn_rate;
        }

        // NAVE ENEMIGA arriba o abajo
        if (Time.time > next_time_NaveEnemiga)
        {
            float yPos = Random.value > 0.5f ? 3.5f : -3.5f;

            Quaternion rotation = Quaternion.identity;

            if (yPos < 0)
            {
                rotation = Quaternion.Euler(0f, 0f, 180f); // la gira al revés
            }

            Instantiate(naveEnemiga, new Vector2(Random.Range(-7, 8f), yPos), rotation);

            next_time_NaveEnemiga = Time.time + Random.Range(2f, 5f);
        }


        // NAVE ENEMIGA 2 arriba o abajo
        if (Time.time > next_time_NaveEnemiga2)
        {
            float yPos = Random.value > 0.5f ? 3.5f : -3.5f;

            Quaternion rotation = Quaternion.identity;

            if (yPos < 0)
            {
                rotation = Quaternion.Euler(0f, 0f, 180f); // la gira al revés
            }

            Instantiate(naveEnemiga2, new Vector2(Random.Range(-7, 8f), yPos), rotation);

            next_time_NaveEnemiga2 = Time.time + Random.Range(4f, 8f);
        }


        // POWER 1
        if (Time.time > next_time_powerup)
        {
            Instantiate(powerup, new Vector2(Random.Range(-7, 8f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);
            next_time_powerup = Time.time + Random.Range(5f, 15f);
        }

        // POWER 2
        if (Time.time > next_time_powerup2)
        {
            Instantiate(powerup2, new Vector2(Random.Range(-7, 8f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);
            next_time_powerup2 = Time.time + Random.Range(5f, 15f);
        }

        // RECOVER
        if (Time.time > next_time_recover)
        {
            Instantiate(recover, new Vector2(Random.Range(-7, 8f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);
            next_time_recover = Time.time + Random.Range(5f, 15f);
        }
    }
}
