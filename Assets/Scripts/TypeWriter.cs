using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriter : MonoBehaviour
{
    [SerializeField]
    private float typeSpeed = 25f;
    public Coroutine Run(string text, TMP_Text textlabel)
    {
        return StartCoroutine(TypeText(text, textlabel));
    }

    private IEnumerator TypeText(string text, TMP_Text textlabel)
    {
        textlabel.text = string.Empty;

        float t = 0;
        int charIndex = 0;
        while (charIndex < text.Length)
        {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);
            textlabel.text = text.Substring(0, charIndex);

            yield return null;
        }

        textlabel.text = text;
    }
}
