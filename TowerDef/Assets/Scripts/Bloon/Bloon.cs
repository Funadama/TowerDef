using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bloon : MonoBehaviour
{
    private Animator animator;
    private float normalizedTime;
    public float BloonHealth;
    public bool AtEnd;
    public GameObject HealthObject;
    public GameObject MoneyObject;


    void Start()
    {
        animator = GetComponent<Animator>();
        AtEnd = false;
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        normalizedTime = stateInfo.normalizedTime;
        if (AtEnd)
        {
            HealthObject.GetComponent<Health>().RemoveHealth(BloonHealth);
            Destroy(gameObject);
        }
        //Debug.Log("Normalized Time: " + normalizedTime);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().tag == "Bullet")
        {
            MoneyObject.GetComponent<Money>().AddMoney(Mathf.RoundToInt(collision.GetComponent<TowerBullet>().Damage));
            
            BloonHealth -= collision.GetComponent<TowerBullet>().Damage;
            

            if (!collision.GetComponent<TowerBullet>().penetrating)
            {
                Destroy(collision.gameObject);
            }

            if (BloonHealth <= 0)
            {
                Object.Destroy(gameObject);
            }
        }
    }


}