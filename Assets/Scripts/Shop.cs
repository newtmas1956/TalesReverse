using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ScriptableObjectsChanger scriptableObjectsChanger;
    public Inventory inventory;
    public int appleAmount;
    public GameObject notifyPrefab;
    public GameObject notifyBuyPrefab;

    public Mushroom mushroom;

    

    public void Update()
    {
        mushroom = (Mushroom) scriptableObjectsChanger.scriptableObjects[scriptableObjectsChanger.currentIndex];
       
       
    }

    public void BuyItem()
    {
        foreach (InventorySlot _slot in inventory.slots)
        {
            if (_slot.item != null && _slot.item.itemType == ItemType.Apple)
            {
                appleAmount = _slot.amount;
                break;  

            }
        }
        if (mushroom.spellPrice <= appleAmount)
        {
            inventory.AddItem(mushroom, 1);
            
            foreach (InventorySlot _slot in inventory.slots)
            {
                if (_slot.item.itemType == ItemType.Apple)
                {
                    _slot.amount -= mushroom.spellPrice;
                    _slot.itemAmount.text = _slot.amount.ToString();
                    Notify(notifyBuyPrefab);
                    break;
                }
            }
        }
        else
        {
            Notify(notifyPrefab);
        }
    }

    public void Notify(GameObject objPrefab)
    {
        GameObjectExtension.Find(objPrefab.name).SetActive(true);
    }
    
    public void DisplayShop()
    {
        Debug.Log("открыто");
        // GameObjectExtension.FindGameObjectWithTag("ShopPanel").SetActive(true);
        GameObjectExtension.Find("Shop").SetActive(true);
    }
}
