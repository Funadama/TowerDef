using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonSpawner : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(prefab, new Vector3(-15.17f, -1.02f, -1), Quaternion.identity);
        }
    }
}
