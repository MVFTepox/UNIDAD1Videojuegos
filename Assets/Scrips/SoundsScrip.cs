using System.Collections.Generic;
using UnityEngine;

public class SoundsScrip : MonoBehaviour
{
    public List<AudioClip> audioList;
    public AudioSource audio_disparo;
    public AudioSource audio_meteoro;
    public AudioSource audio_CargaSismica;

    public AudioSource audio_disparo2;

    public AudioSource powerUpSound;

    public AudioSource recoverySound;

    public AudioSource hitSound;

    public void PlaySonidoDisparo()
    {
        audio_disparo.PlayOneShot(audioList[0]);
    }

    public void PlaySonidoExpolsion()
    {
        audio_meteoro.PlayOneShot(audioList[1]);
    }

    public void PlaySonidoCargaSismica()
    {
        audio_CargaSismica.PlayOneShot(audioList[2]);
    }

    public void PlaySonidoDisparo2()
    {
        audio_disparo2.PlayOneShot(audioList[3]);
    }

    public void PlaySonidoPowerUp()
    {
        powerUpSound.PlayOneShot(audioList[4]);
    }

    public void PlaySonidoRecovery()
    {
        recoverySound.PlayOneShot(audioList[5]);
    }

    public void PlaySonidoHit()
    {
        hitSound.PlayOneShot(audioList[6]);
    }


}
