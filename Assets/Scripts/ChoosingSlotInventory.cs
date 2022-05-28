
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosingSlotInventory : MonoBehaviour
{
    public Inventory inv;
    public Transform quickslotParent;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    //public Transform Destination;
    public GameObject _prefab;
    public bool isChosen = false;
    public GameObject currentWeapon;



    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw > 0.1)
        {
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            if (currentQuickslotID >= quickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                currentQuickslotID++;
            }
            
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;

        }

        if (mw < -0.1)
        {
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount - 1;
            }
            else
            {
                currentQuickslotID--;
            }
            
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;

        }
        PickUp();
        /*
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
        */
    }

    public void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameObjectExtension.Find("InventoryBack").active)
            {
                if (!quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().isEmpty
                    && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite &&
                Convert.ToInt32(quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmount) > 0
                    )
                {
                    if (quickslotParent.GetChild(currentQuickslotID)
                        .GetComponent<InventorySlot>().item.prefab.tag == "TaskList")
                    {
                        GameObjectExtension.Find("TaskList").SetActive(true);
                    }
                    else
                    {
                        if (!isChosen)
                        {
                        Debug.Log( Convert.ToInt32(quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmount));
                            DisplayItem();
                            isChosen = true;
                        }
                        else
                        {
                            Destroy(_prefab);
                            DisplayItem();
                            isChosen = true;
                        }
                    }
                }
            }


        }
    }
    void DisplayItem()
    {
        ItemScriptableObject item = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item;
        _prefab = item.prefab;
        _prefab.GetComponent<Collider>().enabled = false;
        _prefab.AddComponent(typeof(Rigidbody));
        _prefab.GetComponent<Rigidbody>().isKinematic = true;
        GameObject hands = GameObject.Find("Hands");
        _prefab = Instantiate(_prefab);
        /*
        if (_prefab.CompareTag("ALohomora") | item.prefab.CompareTag("Totalus"))
        {
            //   Destination.position = new Vector3(0.77f, -0.76f, 0.55f);
            //_prefab.transform.position = Destination.position;
            _prefab.transform.position = hands.transform.position;
            _prefab.transform.parent = hands.transform;
           _prefab.transform.eulerAngles = item.rotateAngle;
           currentWeapon = _prefab;
        }
        */
        
        {
           // _prefab.transform.position = Destination.position;
           _prefab.transform.position = hands.transform.position;
            _prefab.transform.parent = hands.transform;
            currentWeapon = null;

        }
        isChosen = true;
        }
    
    /*
    void Drop()
    {
        ItemScriptableObject item = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item;
        _prefab = item.prefab;
        _prefab = Instantiate(_prefab);
        if (!_prefab.CompareTag("ALohomora") && !_prefab.CompareTag("Totalus"))
        {
            _prefab.GetComponent<Collider>().enabled = true;
            _prefab.GetComponent<Rigidbody>().isKinematic = false;
            _prefab.GetComponent<Rigidbody>().useGravity = true;
            _prefab.transform.parent = null;
        }
        inv.RemoveItem(_prefab);
    }
    */
}
