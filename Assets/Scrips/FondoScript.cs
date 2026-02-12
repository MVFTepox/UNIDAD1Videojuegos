using UnityEngine;
using UnityEngine.SceneManagement;

public class FondoScript : MonoBehaviour
{

    float next_time_spawn;
    public float spawn_rate;

    public GameObject meteoro;

    /// 
    /// ////////////////////////////////////////
    /// 
    /// 
    /// 
    float next_time_powerup;

    public GameObject powerup;

    float next_time_recover;
    public GameObject recover;


    float next_time_NaveEnemiga;

    public GameObject naveEnemiga;
    public void newGameInit()
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
        next_time_recover = Time.time + 6f;
        next_time_NaveEnemiga = Time.time + 5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_time_spawn)
        {
            Instantiate(meteoro, new Vector2(Random.Range(-7, 8f), 3.5f), Quaternion.identity);
            next_time_spawn = Time.time + spawn_rate;
        }
        if (Time.time > next_time_NaveEnemiga)
        {
            Instantiate(naveEnemiga, new Vector2(Random.Range(-7, 8f), 3.5f), Quaternion.identity);
            next_time_NaveEnemiga  = Time.time + spawn_rate;
        }


        if (Time.time > next_time_powerup)
        {
            Instantiate(powerup, new Vector2(Random.Range(-7, 8f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);
            next_time_powerup = Time.time + Random.Range(5f, 15f);
        }
        if (Time.time > next_time_recover)
        {
            Instantiate(recover, new Vector2(Random.Range(-7, 8f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);
            next_time_recover = Time.time + Random.Range(5f, 15f);
        }
    }
}
