using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    [SerializeField] private List<string> _textList;
    [SerializeField] private DialogueUI _dialogueScript;
    private void OnMouseDown()
    {
        List<string> textList = new List<string>(_textList) ;
        _dialogueScript.gameObject.SetActive(true);
        _dialogueScript.TextList = textList;
    }
}
