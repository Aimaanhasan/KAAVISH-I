using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialog dialog;
    bool isWaiting;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    public IEnumerator triggerDialogue()
    {
        while (isWaiting)
            yield return null;
        StopAllCoroutines();
        FindObjectOfType<DialogueManager>().startDialogue(dialog);
        
        
    }

    IEnumerator wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        isWaiting = false;
    }
    void Start()
    {
        StartCoroutine(wait());
        StartCoroutine(triggerDialogue());
    }

    public void trigger()
    {
        var playerName = inputField.text;
        if (playerName.Length != 0)
        {

            FindObjectOfType<DialogueManager>().changeName(playerName);
            FindObjectOfType<DialogueManager>().displaySentence();
        }
        
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
