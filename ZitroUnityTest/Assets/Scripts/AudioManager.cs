using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [Header("Clips")]
    public AudioClip clickButtonClip;
    public AudioClip clickBackClip;

    public static AudioManager instance = null;
    private AudioSource audioSource;    

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();

        //No quiero destruir este objecto para tener un solo controlador de audio en el juego
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //Sonido de selección del juego
    public void ClickButtonAudio()
    {
        audioSource.PlayOneShot(clickButtonClip, 1f);
    }

    //Sonido de Retorno al menu
    public void ClickBackAudio()
    {
        audioSource.PlayOneShot(clickBackClip, 1f);
    }
}
