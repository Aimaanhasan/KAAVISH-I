using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public Animator animator;
    bool waiting;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
        
    }

    public void changeName(string playerName)
    {
        string sentence = "Hi, " + playerName + "! " + sentences.Dequeue();
        sentences.Enqueue(sentence);
        
    }

    public void startDialogue(Dialog dialog)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();
        foreach (string sentence in dialog.sentences)
            sentences.Enqueue(sentence);
        displaySentence();
    }

    public void displaySentence()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(waitForDialogBox());
        StartCoroutine(typeSentence(sentence));
    }

    IEnumerator waitForDialogBox()
    {
        waiting = true;
        yield return new WaitForSeconds(1f);
        waiting = false;
    }
    IEnumerator typeSentence(string sentence)
    {
        while (waiting)
            yield return null;
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            
            dialogText.text += letter;
            yield return new WaitForSeconds(0.02f); ;
        }
    }

    private void endDialogue()
    {
        animator.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
