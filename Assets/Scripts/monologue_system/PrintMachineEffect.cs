using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class PrintMachineEffect : MonoBehaviour
{
    public static PrintMachineEffect instance = null;
    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    public static IEnumerator printMachineEffect(TextMeshProUGUI textUI, String text, Button introButton)
    {
        introButton.enabled = false;
        float time = 0.01f;

        for (int i = 0; i < text.Length; i++)
        {
            time = 0.01f;
            textUI.text += text[i];
                /*
            //Debug.Log(text[i]);
            if (text[i] == '.')
                time = 0.5f;
            if (text[i] == ',')
                time = 0.05f; 
                */
               
        } 
        Debug.Log(textUI.text);
   //yield return new WaitForSeconds(time);
        yield return null;    
        introButton.enabled = true;
    }
}