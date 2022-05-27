using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGO;
    public TextMeshProUGUI itemAmount;

    private void Start()
    {
        iconGO = transform.GetChild(0).gameObject;
        itemAmount = iconGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void SetIcon(Sprite icon)
    {
       // iconGO.GetComponent<Image>().color = new Color(1, 1, 1);
       iconGO.GetComponent<Image>().enabled = true;
        iconGO.GetComponent<Image>().sprite = icon;
    }
}
