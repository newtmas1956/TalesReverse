using UnityEngine;
[System.Serializable]
public class Response
{
    [SerializeField]
    private string responseText;
    [SerializeField]
    private DialogueObject dialogueObj;

    public string ResponseText => responseText;
    public DialogueObject dialogueObject => dialogueObj;
}
