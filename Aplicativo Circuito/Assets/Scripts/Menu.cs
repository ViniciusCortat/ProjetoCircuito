using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI ContinueText;
    
    void Start()
    {
        InvokeRepeating("BlinkText",0.0f,1f);
    }

    void Update() 
    {
        if(Input.GetMouseButtonDown(0) || Input.touchCount > 0) {
            SceneManager.LoadScene("SelectScene", LoadSceneMode.Single);
        }
    }

    private void BlinkText() {
        Debug.Log(ContinueText.color.a);
        if(ContinueText.color.a >= 0.99f) {
            StartCoroutine(FadeTextToZeroAlpha(1.75f,ContinueText));
        }
        if(ContinueText.color.a <= 0.01f) {
            StartCoroutine(FadeTextToFullAlpha(1.75f,ContinueText));
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

}
