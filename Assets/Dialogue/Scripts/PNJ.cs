using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    [SerializeField] private List<DialogueData> _dialogueText;
    private void OnMouseDown()
    {
        List<string> textList = new List<string>(_dialogueText[0].textList) ;
        DialogueUI.instance.gameObject.SetActive(true);
        DialogueUI.instance.TextList = textList;

        if(_dialogueText.Count > 1)
        {
            _dialogueText.RemoveAt(0);
        }
    }
}
