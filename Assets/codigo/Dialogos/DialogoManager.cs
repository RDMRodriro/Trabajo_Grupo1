using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text NameText;
    public Text DialogueText;
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(dialogue dialogo)
    {
        NameText.text = dialogo.name;
        sentences.Clear();
        foreach (string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNetSentence();
    }

    public void DisplayNetSentence()
    {
        if (sentences.Count == 0)
        {
            return;
        }
        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
    }
}
