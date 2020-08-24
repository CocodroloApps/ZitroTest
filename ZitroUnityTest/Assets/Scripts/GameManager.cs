using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    [Header("Prefabs")]
    public GameObject gamePrefab;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        //Referenciamos el audio manager creado en la escena MainMenu
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        //Instanciamos el juego en el centro de la pantalla
        Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    
    public void BackToMenu()
    {
        audioManager.ClickBackAudio();
        SceneManager.LoadScene("MainMenu");
    }

}
