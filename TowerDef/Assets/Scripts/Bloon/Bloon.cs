using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloon : MonoBehaviour
{
    private Animator animator;
    private float normalizedTime;
    public float Heath;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        normalizedTime = stateInfo.normalizedTime;
        //Debug.Log("Normalized Time: " + normalizedTime);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponent<Collider>().tag == "Bullet")
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
