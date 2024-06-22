using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    [SerializeField]
    private Image image;
    void Start()
    {
        StartCoroutine("Transparent");
    }

    IEnumerator Transparent()
    {
        for (int i = 0; i < 255; i++)
        {
            image.color = image.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine("Transparents");
    }
    IEnumerator Transparents()
    {
        for (int i = 0; i < 255; i++)
        {
            image.color = image.color + new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine("Transparent");
    }
}
