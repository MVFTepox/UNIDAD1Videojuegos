using UnityEngine;

public class RecoverScrip : MonoBehaviour
{

    float time_delete;
    void Start()
    {
        time_delete = Time.time + 5f;
    }


    void Update()
    {
        if (Time.time > time_delete)
        {
            Destroy(gameObject);
        }
    }
}
