using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse : MonoBehaviour
{
    private void OnMouseOver()
    {
      //  Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShowCursor();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            HideCursor();
        }
    }


    public void ShowCursor()
    {
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }
    public void HideCursor()
    {
        Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    }
}