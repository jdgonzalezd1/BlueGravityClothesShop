using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentMoney;

    public int Money
    {
        get; private set;
    }
    #region singleton
    public static PlayerEconomy Instance
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
    }

    #endregion
    private void OnEnable()
    {
        Money = 150;
        UpdateMoney(Money);
    }

    public void TrySpendMoney(int argSpendingAmount)
    {
        if (argSpendingAmount < Money)
        {
            Money -= argSpendingAmount;
            UpdateMoney(Money);
        }
        else
        {
            DialogueBox.Instance.SetTextOnDialogueBox("You don't have enough money", "Come back another time");
            DialogueBox.Instance.EnableDialogueBox();
        }
    }

    public void TryObtainMoney(int argGainAmount)
    {
        if (argGainAmount != 0) 
        {
            Money += argGainAmount;
            UpdateMoney(Money);
        }
        else
        {
            DialogueBox.Instance.SetTextOnDialogueBox("I won't buy that", "It's old");
            DialogueBox.Instance.EnableDialogueBox();
        }

    }


    public void UpdateMoney(int argAmount)
    {
        currentMoney.text = argAmount.ToString();
    }
}
