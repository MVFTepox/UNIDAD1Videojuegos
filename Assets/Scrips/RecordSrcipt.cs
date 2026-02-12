using UnityEngine;
using TMPro;
public class RecordSrcipt : MonoBehaviour
{
    public TextMeshProUGUI Texto_Record;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Texto_Record.SetText("Record: " + PlayerPrefs.GetInt("Record"));
    }
}
