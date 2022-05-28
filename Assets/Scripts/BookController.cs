using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public GameObject player;
    public float reachDistance = 5f;


  
    private void Update()
    {
        if (this.CompareTag("Book"))
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < reachDistance)
            
            {
                GameObjectExtension.Find("OpenBookButton").SetActive(true); 
                
            }
            else
            {
                GameObjectExtension.Find("OpenBookButton").SetActive(false);
            }
        }
       
    }
}