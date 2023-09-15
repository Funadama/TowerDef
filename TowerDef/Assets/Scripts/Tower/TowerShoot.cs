using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
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

        distance = TowerRange;
        foreach (GameObject Bloon in Bloons)
        {
            if (distance > Vector3.Distance(gameObject.transform.position, Bloon.transform.position))
            {
                distance = Vector3.Distance(gameObject.transform.position, Bloon.transform.position);
                Target = Bloon;
            }
        }
        if (distance != TowerRange)
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

        Object.Destroy(bullet, (TowerRange + 1.0f ) / FireSpeed );
    }
}