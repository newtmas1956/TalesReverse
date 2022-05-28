using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
  //  public Sprite emptyHeart;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            /*
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            */

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cat")
        {
            health -= 1;
            
        }
    }
}