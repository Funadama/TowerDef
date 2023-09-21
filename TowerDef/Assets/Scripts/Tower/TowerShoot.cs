using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public int TargetWhat;

    public float TowerRange;
    public float FireRate;
    public float FireSpeed;
    public float Damage;
    public bool penetrating;

    public GameObject RangeObject;

    private float scale;
    private float timestamp;
    private int Amount0;
    private int Amount1;

    private GameObject[] Bloons;
    private GameObject Target;

    public GameObject Bulletprefab;
    private float distance;



    void Start()
    {
        scale = TowerRange / 5;
        RangeObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {

        Bloons = GameObject.FindGameObjectsWithTag("Bloon");

        float distance = 999;
        float BloonAnimClosest = 0;
        float BloonAnimfarest = 999;
        Target = null;

        foreach (GameObject Bloon in Bloons)
        {
            if (TowerRange > Vector3.Distance(gameObject.transform.position, Bloon.transform.position))
            {
                if (TargetWhat == 0)
                {
                    if(BloonAnimClosest < Bloon.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime)
                    {
                        Target = Bloon;
                        BloonAnimClosest = Bloon.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
                        distance = Vector3.Distance(gameObject.transform.position, Bloon.transform.position);
                    }
                }
                else if (TargetWhat == 1)
                {
                    if (BloonAnimfarest > Bloon.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime)
                    {
                        Target = Bloon;
                        BloonAnimfarest = Bloon.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
                        distance = Vector3.Distance(gameObject.transform.position, Bloon.transform.position);
                    }
                }
                else
                {
                    if (distance > Vector3.Distance(gameObject.transform.position, Bloon.transform.position))
                    {
                        Target = Bloon;
                        distance = Vector3.Distance(gameObject.transform.position, Bloon.transform.position);
                    }
                }

            }
        }

        if (Target != null)
        {
            if (Time.time > timestamp)
            {
                timestamp = Time.time + 60/FireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector3 velocity = Target.GetComponent<Animator>().velocity / (FireSpeed / distance);
        Vector3 direction = (Target.transform.position + velocity )- gameObject.transform.position;
        GameObject bullet = Instantiate(Bulletprefab, gameObject.transform.position , Quaternion.identity);
        bullet.transform.forward = direction;

        bullet.GetComponent<TowerBullet>().FireSpeed = FireSpeed;
        bullet.GetComponent<TowerBullet>().Damage = Damage;
        bullet.GetComponent<TowerBullet>().penetrating = penetrating;

        Object.Destroy(bullet, (TowerRange + 1.0f ) / FireSpeed );
    }
}