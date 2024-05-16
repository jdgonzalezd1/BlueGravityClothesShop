using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private string[] lines;

    [SerializeField]
    private float textSpeed;

    private int index;

    public static DialogueBox Instance
    {
        get;
        private set;
    }

    private void Awake()
    {        
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }           
        print(Instance.gameObject.name);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    public void EnableDialogueBox()
    {
        print("executing");
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);            
        }        
    }


    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void PassToNextLine()
    {
        if (dialogueText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }



}
