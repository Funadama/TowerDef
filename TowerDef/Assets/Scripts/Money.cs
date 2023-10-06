using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int AmountMoney;
    public TMP_Text txt;

    void Start()
    {
        txt.text = "Money - " + AmountMoney;
    }

    public void AddMoney(int AddMoney)
    {
        //Debug.Log(AddMoney);
        AmountMoney += AddMoney;
        txt.text = "Money - " + AmountMoney;
    }
}