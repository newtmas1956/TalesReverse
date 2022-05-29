using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorController : MonoBehaviour
{
   public bool isOpened = false;
   float rotationAmount = -0.2f;
   float delaySpeed = 0.001f;

  
   
  
   IEnumerator SlowSpin()
   {
      float count = 0;
      while (count <= 90)
      {
         this.transform.Rotate(new Vector3(0, rotationAmount, 0));
         count -= rotationAmount;
         yield return new WaitForSeconds(delaySpeed);
      }
   }

   public void Open()
   {
      Debug.Log("O");
      if (!isOpened)
      {
         StartCoroutine(SlowSpin());
         isOpened = true;
      }
      
   }
   
}
