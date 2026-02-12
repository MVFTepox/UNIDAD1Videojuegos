using UnityEngine;

public class PowerUpScrip : MonoBehaviour
{
    float time_delete;
    void Start()
    {
        time_delete = Time.time + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time_delete)
        {
            Destroy(gameObject);
        }
    }
}
