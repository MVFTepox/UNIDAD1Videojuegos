using UnityEngine;
using TMPro;

public class ScoreScrip : MonoBehaviour
{

    public TextMeshProUGUI text_Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text_Score.SetText("Score: " + PlayerPrefs.GetInt("Score"));
        // esto es para el manejo del score dentro del juego
    }
}
