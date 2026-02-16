using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisparoScript : MonoBehaviour
{
    public List<Sprite> sprites;
    int tipo_arma;

    Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        tipo_arma = PlayerPrefs.GetInt("tipo_arma");

        if (tipo_arma == 0)
        {
            img.sprite = sprites[0];
        }
        else if (tipo_arma == 1)
        {
            img.sprite = sprites[1];
        }
        else if (tipo_arma == 2)
        {
            img.sprite = sprites[2];
        }
    }
}
