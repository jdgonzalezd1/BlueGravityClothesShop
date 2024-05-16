using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private Image shirtIcon;

    [SerializeField]
    private string[] lines;

    [SerializeField]
    private float textSpeed;

    private int index;

    #region singleton
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
        gameObject.SetActive(false);
    }

    #endregion

    private void OnEnable()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    #region dialog box behaviour
    public void EnableDialogueBox()
    {        
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);            
        }        
    }

    public void EnableClothingIcon() 
    { 
        shirtIcon.gameObject.SetActive(true);
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
            shirtIcon.gameObject.SetActive(false);
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
    #endregion

    public void SetClothingProperties(string argClothingName, string argClothingPrice, Sprite argClothingIcon)
    {
        StopAllCoroutines();        
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = string.Empty;
        }
        lines[0] = argClothingName;
        lines[1] =$"Price: ${argClothingPrice}";
        shirtIcon.sprite = argClothingIcon;
    }

}
