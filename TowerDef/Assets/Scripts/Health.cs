using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float HeatlhPlayer;
    public TMP_Text txt;

    void Start()
    {
        HeatlhPlayer = 500;
        Debug.Log(HeatlhPlayer);
        txt.text = "Health - " + HeatlhPlayer;
    }

    void Update()
    {

    }
    public void RemoveHealth(float Hp)
    {
  
        Debug.Log(Hp);
        Debug.Log(HeatlhPlayer);

        txt.text = "Health - " + HeatlhPlayer;
        if (HeatlhPlayer < 0)
        {
            Debug.Log("dead");
        }
    }
}