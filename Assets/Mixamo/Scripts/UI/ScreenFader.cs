using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ScreenFader : MonoBehaviour
{
    private CanvasGroup _cg;

    private void Awake()
    {
        if (GetComponent<CanvasGroup>() == null)
            gameObject.AddComponent<CanvasGroup>();

        _cg = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        StartCoroutine(FadeTo(1.0f, 1.0f));
    }




    public void FadeToBlack()
    {
        //StartCoroutine(FadeOut());
        StartCoroutine(FadeTo(1.0f, 0.0f));
    }
    public void FadeToFullOpacity()
    {
        //StartCoroutine(FadeIn());
        StartCoroutine(FadeTo(0.0f, 1.0f));
    }

    private IEnumerator FadeIn()
    {

        _cg.alpha = 0;
        yield return new WaitForSeconds(1);
    }
    private IEnumerator FadeOut()
    {

        _cg.alpha = 1;
        yield return new WaitForSeconds(1);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            StartCoroutine(FadeTo(0.0f, 1.0f));
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(FadeTo(1.0f, 1.0f));
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = _cg.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            float newColor = Mathf.Lerp(alpha, aValue, t);
            _cg.alpha = newColor;
            yield return null;
        }
    }

}
