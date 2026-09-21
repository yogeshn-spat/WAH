using UnityEngine;

[CreateAssetMenu(fileName = "TextContent", menuName = "Content/TextContent")]
public class NEUR_TextContent : ScriptableObject
{
    [TextArea(3, 10)]
    public string tamilContent;

    [TextArea(3, 10)]
    public string englishContent;

    [TextArea(3, 10)]
    public string hindiContent;
}
