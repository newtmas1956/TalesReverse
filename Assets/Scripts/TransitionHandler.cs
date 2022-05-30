using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    private Animator animator;
    private string nextScene;
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
        //if (SceneManager.GetActiveScene().name.Equals("Forest") &&  GameObjectExtension.Find("EnterButton").activeInHierarchy)
        if (SceneManager.GetActiveScene().name.Equals("Forest") && GameObjectExtension.Find("HasMushs").activeInHierarchy)
        {
            Debug.Log("HasMushs найден и мы в лесу!");
            nextScene = "Hut";
        }
        if (SceneManager.GetActiveScene().name.Equals("Puzzle"))
        {
            GameObjectExtension.Find("OpenBookButton").SetActive(false);
        }
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