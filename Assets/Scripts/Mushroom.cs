using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Mushroom", menuName = "ScriptableObjects/Mushroom")]
public class Mushroom : ItemScriptableObject
{
  
    [Header("Stats")]
    public int spellPrice;

    void Start()
    {
        itemType = ItemType.Mushroom;
    }
    
}

