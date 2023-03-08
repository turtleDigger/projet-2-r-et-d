using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "My Game/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public List<string> textList;
}
