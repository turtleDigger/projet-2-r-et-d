using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private Text _dialogueText;
    private List<string> _textList;

    public List<string> TextList
    {
        set
        {
            if(value is List<string>)
            {
                _textList = value;
                _dialogueText.text = _textList[0];
                _textList.RemoveAt(0);
            }
            else
            {
                Debug.LogError("la variable passé n'est pas de type List<string>");
            }
        }
    }

    public void DisplayNextDialogue()
    {
        if(_textList.Count != 0)
        {
            _dialogueText.text = _textList[0];
            _textList.RemoveAt(0);
        }
        else
        {
            _dialogueText.text = "";
            gameObject.SetActive(false);
        }
    }
}
