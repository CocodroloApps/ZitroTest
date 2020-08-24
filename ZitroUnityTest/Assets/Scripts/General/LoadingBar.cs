using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour {

    [Header("Params")]
    public bool autoLoad;               //Carga la escena destino automaticamente. 
    public string loadingSceneName;     //Nombre de la escena de destino
    public float waitSecondsPrev;       //Segundos de espera antes de cargar la escena destino
    public float waitSecondsPost;
    public Slider sliderBar;

    private bool loadScene = false;

    // Use this for initialization
    void Start ()
    {
        if (autoLoad== true)
        {
            sliderBar.gameObject.SetActive(false);
            Invoke("Loading", waitSecondsPrev);
        }        
    }
	
	// Update is called once per frame
	public void Loading()
    {
	    if(loadScene == false)
        {
            loadScene = true;
            sliderBar.gameObject.SetActive(true);
            StartCoroutine("LoadNewScene");
        }
	}

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(waitSecondsPost);
        AsyncOperation async = SceneManager.LoadSceneAsync(loadingSceneName);

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            yield return null;
        }
    }
}
