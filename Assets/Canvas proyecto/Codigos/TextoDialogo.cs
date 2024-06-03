using System.Collections;
using UnityEngine;
using TMPro;

public class TextoDialogo : MonoBehaviour
{
    [SerializeField] private GameObject dialogeMark;
    [SerializeField] private GameObject dialogePanel;
    [SerializeField] private GameObject teclaAccion;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private float typingTime = 0.09f;

    private bool isPlayedInRange;
    private bool didDialogueStart;
    private int lineIndex;


    void Update()
    {
        if(isPlayedInRange && Input.GetKeyDown(KeyCode.N))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialogePanel.SetActive(true);
        dialogeMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialogePanel.SetActive(false);
            dialogeMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayedInRange = true;
            dialogeMark.SetActive(true);
            teclaAccion.SetActive(true);
            //Debug.Log("Se puede iniciar un dialogo");
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayedInRange = false;
            dialogeMark.SetActive(false);
            teclaAccion.SetActive(false);
            //Debug.Log("No se puede iniciar un dialogo");
        }
    }
}
