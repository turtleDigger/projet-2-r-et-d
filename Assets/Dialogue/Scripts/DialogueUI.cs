using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI instance;
    private float   _defaultPause = 1E-2f,
                    _commaPause = 1E-1f,
                    _periodPause = 5 * 1E-1f;

    [SerializeField] private Text _dialogueText;
    private List<string> _textList;
    private IEnumerator _dDR;

    public List<string> TextList
    {
        set
        {
            if(value is List<string>)
            {
                _textList = value;
                DisplayNextDialogue();
            }
            else
            {
                Debug.LogError("la variable passé n'est pas de type List<string>");
            }
        }
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueUI dans la scène");
            return;
        }
        instance = this;

        gameObject.SetActive(false);
    }

    private void DisplayNextDialogue()
    {
        if(PreviousDDRIsFinish())
        {
            if(_textList.Count != 0)
            {
                _dDR = DisplayDialogueRoutine(_textList[0]);
                StartCoroutine(_dDR);
                _textList.RemoveAt(0);
            }
            else
            {
                _dialogueText.text = "";
                gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator DisplayDialogueRoutine(string sentence)
    {
        int i = 0;

        _dialogueText.text = "";

        foreach(char character in sentence.ToCharArray())
        {
            _dialogueText.text += character;
            
            switch (character)
            {
                case '.':
                case '…':
                case '?':
                case '!':
                case '_':
                    if (i == sentence.Length - 1) break; // Ne pas attendre si il s'agit du dernier caractère
                    yield return new WaitForSeconds(_periodPause);
                    break;
                case ',':
                    yield return new WaitForSeconds(_commaPause);
                    break;
                default:
                    yield return new WaitForSeconds(_defaultPause);
                    break;
            }

            i++;
        }

        _dDR = null;
        SlowDownDDR();
    }

    private bool PreviousDDRIsFinish()
    {
        if(_dDR != null)
        {
            // StopCoroutine(_dDR);
            // _dDR = null;
            SpeedUpDDR();

            return false;
        }
        else
        {
            return true;
        }
    }

    private void SpeedUpDDR()
    {
        _periodPause = 1E-3f;
        _commaPause = 1E-3f;
        _defaultPause = 1E-3f;
    }

    private void SlowDownDDR()
    {
        _periodPause = 5 * 1E-1f;
        _commaPause = 1E-1f;
        _defaultPause = 1E-2f;
    }
}
