
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class ChoosingSlotInventory : MonoBehaviour
{
    public Transform quickslotParent;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    public Transform Destination;
    public GameObject prefab;
    public bool isChosen = false;



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
    }

    public void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameObject.Find("InventoryBack").active)
            {
                if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item != null
                    && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)
                {
                    if (quickslotParent.GetChild(currentQuickslotID)
                        .GetComponent<InventorySlot>().item.prefab.tag == "TaskList")
                    {
                        GameObject.Find("Canvas").transform.GetChild(0);
                        Resources.FindObjectsOfTypeAll(Panel);
                    }
                    else
                    {
                        if (!isChosen)
                        {
                            DisplayItem();
                            isChosen = true;
                        }
                        else
                        {
                            Destroy(prefab);
                            DisplayItem();
                        }
                    }
                }
            }


        }
    }
    void DisplayItem()
        {
            prefab = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item.prefab;
            prefab.GetComponent<Collider>().enabled = false;
            prefab.AddComponent(typeof(Rigidbody));
            prefab.GetComponent<Rigidbody>().isKinematic = true;
            prefab.GetComponent<Rigidbody>().useGravity = false;
            prefab.transform.position = Destination.position;
            GameObject hands = GameObject.Find("Hands");
            prefab = Instantiate(prefab);
            prefab.transform.parent = hands.transform;
            isChosen = true;
        }
}
*/