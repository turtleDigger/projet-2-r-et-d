using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    [SerializeField] private List<DialogueData> _dialogueText;
    [SerializeField] private DialogueUI _dialogueScript;
    private void OnMouseDown()
    {
        List<string> textList = new List<string>(_dialogueText[0].textList) ;
        _dialogueScript.gameObject.SetActive(true);
        _dialogueScript.TextList = textList;

        if(_dialogueText.Count > 1)
        {
            _dialogueText.RemoveAt(0);
        }
    }
}
