using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float HeatlhPlayer;
    public TMP_Text txt;
    public Canvas Dead;

    void Start()
    {
        txt.text = "Health - " + HeatlhPlayer;
    }

    public void RemoveHealth(float Hp)
    {
        HeatlhPlayer -= Hp;
        txt.text = "Health - " + HeatlhPlayer;
        if (HeatlhPlayer < 0)
        {
            Debug.Log("dead");
            Dead.gameObject.SetActive(true);
        }
    }
}