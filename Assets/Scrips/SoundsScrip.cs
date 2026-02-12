using System.Collections.Generic;
using UnityEngine;

public class SoundsScrip : MonoBehaviour
{
    public List<AudioClip> audioList;
    public AudioSource audio_disparo;
    public AudioSource audio_meteoro;

    public void PlaySonidoDisparo()
    {
        audio_disparo.PlayOneShot(audioList[0]);
    }

    public void PlaySonidoExpolsion()
    {
        audio_meteoro.PlayOneShot(audioList[1]);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
