using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public float FireSpeed;
    public float Damage;
    public bool penetrating;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * FireSpeed * Time.deltaTime);
    }
}
