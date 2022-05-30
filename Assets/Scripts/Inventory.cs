using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public bool isActive;
    public Transform inventoryPanel; 
    public List<InventorySlot> slots = new List<InventorySlot>();
 //   private Camera mainCamera;
    private GameObject point;
    public float richDistance = 15f;
    public ItemScriptableObject Mushroom1;
    public ItemScriptableObject Mushroom2;
    public ItemScriptableObject Apple;
    public int questMushrooms = 0;
     
    void Start()
    {
       // mainCamera = Camera.main;
        point = GameObject.FindGameObjectWithTag("point");
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inventory.SetActive(true);
                            isActive = true;
        }
        Ray ray = Camera.main.ScreenPointToRay(point.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, richDistance))
        {
          if (Input.GetKeyDown(KeyCode.F))
          {
              //Debug.Log("Кнопка нажата)");
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    //Debug.Log("Луч работает");
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                   
                }
          }

        }
        HasMushroom();
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                slot.itemAmount.text = slot.amount.ToString();
                return;
            }
            
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmount.text = slot.amount.ToString();
                break;
            }
            
        }
    }

    public void AddItemToSlot(ItemScriptableObject _item, int _amount, int slotId)
    {
        InventorySlot slot = slots[slotId];
        slot.item = _item;
        Debug.Log(_item);
        slot.isEmpty = false;
        slot.iconGO.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        slot.SetIcon(_item.icon);
        if (_amount <= _item.maximumAmount)
        {   
            slot.amount += _amount;
            if (slot.item.maximumAmount != 1)
            {
                slot.itemAmount.text = slot.amount.ToString();
            }
        }
        else{
            slot.amount = _item.maximumAmount;
            _amount -= _item.maximumAmount;
            if (slot.item.maximumAmount != 1)
            {
                slot.itemAmount.text = slot.amount.ToString();
            }
        }
    }

    public void RemoveItemFromSlot(int slotId)
    {
        InventorySlot slot = slots[slotId];
        slot.item = null;
        slot.isEmpty = true;
        slot.amount = 0;
        slot.iconGO.GetComponent<Image>().sprite = null;
        slot.iconGO.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        slot.itemAmount.text = "";
    }

    public void RemoveItem(GameObject prefab)
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (slots[i].item.prefab.Equals(prefab))
            {
                slots[i].item = null;
                slots[i].isEmpty = true;
                slots[i].amount = 0;
                slots[i].iconGO.GetComponent<Image>().sprite = null;
                slots[i].itemAmount.text = "";
            }
        }
    }

    public void HasMushroom()
    {
        questMushrooms = 0;   
        for (int i = 0; i < 5; i++)
        {
            /*
            if (slots[i].amount >= 5)
            {
                questMushrooms = 2;
            }
            */
            if ((slots[i].item == Mushroom1) || (slots[i].item == Mushroom2))
            {
                questMushrooms++;
                Debug.Log("грибобас найден");
            }
        }

        if (questMushrooms >= 2)
        {
            GameObject.Find("Shop").SetActive(false);
            GameObject.Find("ShopButton").SetActive(false);
            GameObject.Find("SpeakButton").SetActive(false);
            GameObjectExtension.Find("HasMushs").SetActive(true);
            Debug.Log("ААААААААА");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        GameObjectExtension.Find("HasMushs").SetActive(true);
        
    }

}
