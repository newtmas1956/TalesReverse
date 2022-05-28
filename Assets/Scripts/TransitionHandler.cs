using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    private Animator animator;
    public string nextScene ="";
    [SerializeField] public bool disableFadeInAnimation = false;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        if (disableFadeInAnimation)
        {
            Debug.Log(animator);
            animator.Play("FadeIn", 0 , 1);
        }
    }

    public void Update()
    {
       
        if (SceneManager.GetActiveScene().name.Equals("Cabinet") &&  GameObjectExtension.Find("OpenBookButton").activeInHierarchy)
        {
            nextScene = "Puzzle";
        }
        /*
        else 
        if (SceneManager.GetActiveScene().name.Equals("HallScene") && GameObjectExtension.Find("CookButton").activeInHierarchy)
        {
           Debug.Log("Yeee");
            nextScene = "Menu";
        }
        else if (SceneManager.GetActiveScene().name.Equals("HogwartsScene"))
        {
            nextScene = "HallScene";
        }
        */
    }

    public void LoadNextScene()
    {
      
     
        animator.Play("FadeOut", -1, 0);
     

    }
    public void FadeOutFinished()
    {
  
        SceneManager.LoadScene(nextScene);
    }
}