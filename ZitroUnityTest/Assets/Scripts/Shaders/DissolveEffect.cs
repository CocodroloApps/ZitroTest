using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    public Material material;

    private float dissolveAmount;
    private bool isDissolving;
    private bool isWaiting;

    private void Start()
    {
        isDissolving = true;  //True - Aparece      False - Desaparece
        isWaiting = false;    
        dissolveAmount = 0;   //Parametro del material
    }

    private void Update()
    {
        if (isWaiting == false)
        {
            if (isDissolving)
            {
                //Animacion de aparecer a traves del Shader
                dissolveAmount = Mathf.Clamp01(dissolveAmount + Time.deltaTime);
                material.SetFloat("_DissolveAmount", dissolveAmount);
                if (dissolveAmount >= 1)
                {
                    isWaiting = true;
                    StartCoroutine(WaitAnimation());
                }
            }
            else
            {
                //Animacion de desaparecer a traves del Shader
                dissolveAmount = Mathf.Clamp01(dissolveAmount - Time.deltaTime);
                material.SetFloat("_DissolveAmount", dissolveAmount);
                if (dissolveAmount <= 0)
                {
                    isWaiting = true;
                    StartCoroutine(WaitAnimation());
                }
            }
        }        
    }

    private IEnumerator WaitAnimation()
    {
        //Tiempo de espera entre animaciones
        yield return new WaitForSeconds(1f);
        isDissolving = !isDissolving;
        isWaiting = false;
    }

}
