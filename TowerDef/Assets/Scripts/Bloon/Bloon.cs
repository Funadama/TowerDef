using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloon : MonoBehaviour
{
    private Animator animator;
    private float normalizedTime;
    public float Heath;
    public bool AtEnd;
    public GameObject Health;


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
            Health.GetComponent<Health>().RemoveHealth(Heath);
            Destroy(gameObject);
        }
        //Debug.Log("Normalized Time: " + normalizedTime);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().tag == "Bullet")
        {
            Heath -= collision.GetComponent<TowerBullet>().Damage;

            if (!collision.GetComponent<TowerBullet>().penetrating)
            {
                Destroy(collision.gameObject);
            }

            if (Heath <= 0)
            {
                Object.Destroy(gameObject);
            }
        }
    }


}