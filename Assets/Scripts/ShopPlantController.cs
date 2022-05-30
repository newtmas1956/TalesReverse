using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPlantController : MonoBehaviour
{
    public GameObject player;
    public float reachDistance = 5f;


  
    private void Update()
    {
        
        if (this.CompareTag("Shop"))
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < reachDistance)
            
            {
                Debug.Log("подошли");
               
               GameObjectExtension.Find("ShopButton").SetActive(true); 
                GameObjectExtension.Find("SpeakButton").SetActive(true); 

            }
            else
            {
                GameObjectExtension.Find("ShopButton").SetActive(false); 
                GameObjectExtension.Find("SpeakButton").SetActive(false); 
            }
        }
       
    }

    public void DisplayShop()
    {
        Debug.Log("открыто");
       // GameObjectExtension.FindGameObjectWithTag("ShopPanel").SetActive(true);
        GameObjectExtension.Find("Shop").SetActive(true);
    }
}
