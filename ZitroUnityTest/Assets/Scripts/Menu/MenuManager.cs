using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        //Referenciamos el audio manager creado en la escena MainMenu
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void PlayGame1()
    {
        audioManager.ClickButtonAudio();
        StartCoroutine(Play1_Delay());
    }
    
    private IEnumerator Play1_Delay()
    {
        yield return new WaitForSeconds(1f);
        //cargamos la escena del juego a través del Slider.
        GetComponent<LoadingBar>().loadingSceneName = "Game1";
        GetComponent<LoadingBar>().Loading();
    }

    public void PlayGame2()
    {
        audioManager.ClickButtonAudio();
        StartCoroutine(Play2_Delay());
    }

    private IEnumerator Play2_Delay()
    {
        yield return new WaitForSeconds(1f);
        //cargamos la escena del juego a través del Slider.
        GetComponent<LoadingBar>().loadingSceneName = "Game2";
        GetComponent<LoadingBar>().Loading();
    }

    public void PlayGame3()
    {
        audioManager.ClickButtonAudio();
        StartCoroutine(Play3_Delay());
    }

    private IEnumerator Play3_Delay()
    {
        yield return new WaitForSeconds(1f);
        //cargamos la escena del juego a través del Slider.
        GetComponent<LoadingBar>().loadingSceneName = "Game3";
        GetComponent<LoadingBar>().Loading();
    }
}
