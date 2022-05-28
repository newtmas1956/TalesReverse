using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
public class ItemScriptableObject : ScriptableObject
{

    public ItemType itemType;
    public string name;
    public int maximumAmount;
    [Multiline(5)]
    public String description;

    public Sprite icon;
    public GameObject prefab;
    public Vector3 rotateAngle;
}