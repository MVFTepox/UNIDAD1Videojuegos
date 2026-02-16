using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
