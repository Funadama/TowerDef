using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloon : MonoBehaviour
{
    private Animator animator;
    private float normalizedTime;
    public int Heath;

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


    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            Debug.Log(collision.collider.tag);
        }
        Debug.Log(collision.collider.tag);
    }
}
