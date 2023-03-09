using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    public void FadeOut() 
    {
        Fade(0, 1);
    
    }

        public void FadeIn()
    {
        Fade(1, 0);
    }

   public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeCoroutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeCoroutine(float alphaIn, float alphaOut)
    {
        //start a timer at zero, and each frame, increase the timer value. once timer is
        ////over duration, end while loop and continue coroutine
        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;

            // when the third parameter = 0 , it is equal to alpha in. then,
            //when it is equal to one (after the loop), it returns alphaOut.
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null; //wait for one frame
        }

        Color newColor2 = fadeColor;

            //set the alpha channel to alpha out.
        newColor2.a = alphaOut;

        rend.material.SetColor("_Color", newColor2);
    }
}
