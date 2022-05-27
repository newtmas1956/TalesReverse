using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool wasPicked;

    public void Awake()
    {
        if (wasPicked)
        {
            Debug.Log("удалено");
            Destroy(this.gameObject);
        }
    }
}
