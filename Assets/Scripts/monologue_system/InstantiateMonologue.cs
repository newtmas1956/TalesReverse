using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using System.Xml.Serialization;
public class InstantiateMonologue : MonoBehaviour
{
  public static InstantiateMonologue instance = null;

  public TextAsset[] assets;
  private int currentAsset;
  private int currentNode;
  private Monologue monologue;
  private bool firstStart = true;
  private Image introFont;
  private Image introWindow;
  private TextMeshProUGUI introText;
  private Image introCharacter;
  private Button introButton;
  private Button skipIntroButton;
  private TextMeshProUGUI skipIntroText;
  

  public void Start()
  {
    if (instance == null)
      instance = this;
    
    currentAsset = 0;
    currentNode = 0;
    introFont = GameObject.Find("MainScene").GetComponent<Image>();
    introWindow = introFont.transform.GetChild(0).gameObject.GetComponent<Image>();
    introButton = introWindow.transform.GetChild(1).gameObject.GetComponent<Button>();
    introText = introWindow.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    skipIntroButton = introFont.transform.GetChild(1).gameObject.GetComponent<Button>();
    skipIntroText = skipIntroButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    StartScene();
  }
  
  
  public static Monologue Load(TextAsset _xml)
  {
    XmlSerializer serializer = new XmlSerializer(typeof(Monologue));
    StringReader reader = new StringReader(_xml.text);
    Monologue mono = serializer.Deserialize(reader) as Monologue;
    return mono;
  }

  public void LoadAsset()
  {
    currentNode = 0;
    monologue = Load(assets[currentAsset]);
  }

  public void StartScene()
  {
    if (firstStart)
    {
      introButton.onClick.AddListener(NextIntroNode);
      skipIntroButton.onClick.AddListener(HideImportantScene);
      firstStart = false;
    }
    LoadAsset();
    NextIntroNode();
  }

  public void ShowImportantScene()
  {
    introFont.enabled = true;
    introWindow.enabled = true;
    introText.enabled = true;
    introCharacter.enabled = true;
    introButton.enabled = true;
    skipIntroButton.enabled = true;
    skipIntroText.enabled = true;
  }

  public void HideImportantScene()
  {
    /*
    introFont.enabled = false;
    introWindow.enabled = false;
    introText.enabled = false;
    introCharacter.enabled = false;
    introButton.enabled = false;
    skipIntroButton.enabled = false;
    skipIntroText.enabled = false;
    */
    SceneManager.LoadScene((SceneManager.GetActiveScene()).buildIndex + 1);
  }

  public void NextIntroNode()
  {
    if (currentNode == monologue.nodes.Length)
    {
      HideImportantScene();
    }

    else
    {
      introText.text = "";

      StartCoroutine(
        PrintMachineEffect.printMachineEffect(introText, monologue.nodes[currentNode].Npctext, introButton));
      //Debug.Log(introText.text);
      //Debug.Log(monologue.nodes[currentNode].Npctext);
      currentNode++;
    }
  }
}
