using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI mushroomName;
    [SerializeField]
    public TextMeshProUGUI mushroomDescription;
    [SerializeField]
    public TextMeshProUGUI mushroomPrice;
    [SerializeField]
    public Image mushroomImage;

    public void DisplaySpell(Mushroom mushroom)
    {
        mushroomName.text = mushroom.name;
        mushroomDescription.text = mushroom.description;
        mushroomPrice.text = mushroom.spellPrice.ToString();
        mushroomImage.sprite = mushroom.icon;
    }

    
}
