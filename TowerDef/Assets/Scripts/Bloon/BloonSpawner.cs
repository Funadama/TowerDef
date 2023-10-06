using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BloonSpawner : MonoBehaviour
{
    public GameObject prefab;
    private int wave;
    public float delay = 1;
    private float timer;
    private int BloonSpawnAmount;
    public GameObject HealthObject;
    public GameObject MoneyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        BloonSpawnAmount = 10;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject instantiatedPrefab = Instantiate(prefab, new Vector3(-15.17f, -1.02f, -1), Quaternion.identity);
            instantiatedPrefab.GetComponent<Bloon>().HealthObject = HealthObject;
            instantiatedPrefab.GetComponent<Bloon>().MoneyObject = MoneyGameObject;
        }


        if (Time.realtimeSinceStartup > timer)
        {
            SpawnBloon(((wave % 3) * wave / 3) + 1);
            BloonSpawnAmount -= 1;
            timer = Time.realtimeSinceStartup + delay ;
        }

    }

    void SpawnBloon(int health)
    {
        GameObject instantiatedPrefab = Instantiate(prefab, new Vector3(-15.17f, -1.02f, -1), Quaternion.identity);
        instantiatedPrefab.GetComponent<Bloon>().HealthObject = HealthObject;
        instantiatedPrefab.GetComponent<Bloon>().MoneyObject = MoneyGameObject;
    }
}
