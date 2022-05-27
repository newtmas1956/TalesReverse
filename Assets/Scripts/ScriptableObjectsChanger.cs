using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class ScriptableObjectsChanger : MonoBehaviour
{
    [SerializeField] public ScriptableObject[] scriptableObjects; //сделать private и добавить геттер

    [SerializeField] public SpellDisplay spellDisplay;
    public int currentIndex;

    private void Awake()
    {
        ChangeScriptableObject(0);
    }
    
     public void ChangeScriptableObject(int change)
        {
            currentIndex += change;
            if (currentIndex < 0) currentIndex = scriptableObjects.Length - 1;
            else if (currentIndex > scriptableObjects.Length - 1) currentIndex = 0;

            if(spellDisplay != null) spellDisplay.DisplaySpell((MagicSpell)scriptableObjects[currentIndex]);
        }
}
*/
