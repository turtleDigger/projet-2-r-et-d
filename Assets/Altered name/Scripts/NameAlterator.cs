using UnityEngine;
using UnityEngine.UI;

public class NameAlterator : MonoBehaviour
{
    private Text greetingText;
    private string _nameToAlter;

    private void Start()
    {
        greetingText = GameObject.Find("Greeting Text").GetComponent<Text>();
    }

    public void AlterName()
    {
        string alteredName = _nameToAlter = GameObject.Find("Name InputField").GetComponent<InputField>().text;

        alteredName = alteredName.Replace("th", "f").Replace("Th", "F");
        alteredName = alteredName.Replace("u", "yu").Replace("U", "Yu");
        alteredName = alteredName.Replace("an", "èn").Replace("An", "Èn");
        alteredName = alteredName.Replace('é', 'è').Replace('É', 'È');
        alteredName = alteredName.Replace('r', 'w').Replace('R', 'W');

        greetingText.text = "Greeting to you " + alteredName + ".";

        if(alteredName != _nameToAlter)
        {
            Debug.Log("Name has been altered");
        }
    }
}
