using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*

public class Shop : MonoBehaviour
{
    public ScriptableObjectsChanger scriptableObjectsChanger;
    public Inventory inventory;
    public int appleAmount;
    public GameObject notifyPrefab;
    public GameObject notifyBuyPrefab;

    public MagicSpell magicSpell;

    

    public void Update()
    {
        magicSpell = (MagicSpell) scriptableObjectsChanger.scriptableObjects[scriptableObjectsChanger.currentIndex];
       
       
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
        if (magicSpell.spellPrice <= appleAmount)
        {
            inventory.AddItem(magicSpell, 1);
            
            foreach (InventorySlot _slot in inventory.slots)
            {
                if (_slot.item.itemType == ItemType.Apple)
                {
                    _slot.amount -= magicSpell.spellPrice;
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
}
*/