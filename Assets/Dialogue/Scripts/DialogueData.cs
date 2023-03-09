using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "My Game/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    [TextArea(3, 10)]
    public List<string> textList;
}
