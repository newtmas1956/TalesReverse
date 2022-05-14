using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    [SerializeField]
    [TextArea]
    private string[] dialogue;
    [SerializeField]
    private Response[] responses;

    public string[] Dialogue => dialogue;

    public bool HasResponses => Responses != null && Responses.Length > 0;
    public Response[] Responses => responses;
}
