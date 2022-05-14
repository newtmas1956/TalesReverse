using TMPro;
using UnityEngine;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textLabel;
    private TypeWriter typewriter;
    [SerializeField]
    private GameObject dialogueBox;

    [SerializeField]
    private DialogueObject testDialogue;

    private ResponseHandler responseHandler;

    private void Start()
    {
        typewriter = GetComponent<TypeWriter>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogue();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObj)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughtDialogue(dialogueObj));
    }

    private IEnumerator StepThroughtDialogue(DialogueObject dialogueObj)
    {

        for (int i = 0; i < dialogueObj.Dialogue.Length; i++)
        {
            string dialogue = dialogueObj.Dialogue[i];
            yield return typewriter.Run(dialogue, textLabel);

            if (i == dialogueObj.Dialogue.Length - 1 && dialogueObj.HasResponses)
                break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        }
        if (dialogueObj.HasResponses)
            responseHandler.ShowResponses(dialogueObj.Responses);
        else
            CloseDialogue();
    }

    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
