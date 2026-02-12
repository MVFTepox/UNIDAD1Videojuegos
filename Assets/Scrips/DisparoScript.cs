
using UnityEngine;

public class DisparoScript : MonoBehaviour
{
    Vector2 disparo_Velocity;
    public float forceX;
    public float forceY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ///Siempre tiene que sumar 1 
        
      

        forceX = PlayerPrefs.GetFloat("fuerzaX");
        
        forceY = PlayerPrefs.GetFloat("fuerzaY");
        disparo_Velocity.y = forceY;
        disparo_Velocity.x = forceX;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += disparo_Velocity;
    }
}
