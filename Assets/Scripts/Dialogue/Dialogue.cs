using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Variables
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialoguelines;

    private float typingTime = 0.05f;
    private bool playerinRange;
    private bool didDialogueStart;
    private int lineIndex;

    //Codigo Ejecutable
     void Update()
    {
        if(playerinRange && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart) {
                StartDialogue();
            }
           
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialoguelines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinRange = true;
            dialogueMark.SetActive(true);
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinRange = false;
            dialogueMark.SetActive(false);
        }
        
    }
}
