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

    public TMP_Text WaveText;

    // Start is called before the first frame update
    void Start()
    {
        BloonSpawnAmount = 0;
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
        

        if (Time.realtimeSinceStartup > timer && BloonSpawnAmount > 0)
        {
            SpawnBloon(((wave % 3 + 1) * wave / 3) + 1 + (wave / 10 * 5) + (wave / 20 * 10));
            BloonSpawnAmount -= 1;
            timer = Time.realtimeSinceStartup + delay ;
        }
        else if (0 == GameObject.FindGameObjectsWithTag("Bloon").Length)
        {
            
            wave ++;

            MoneyGameObject.GetComponent<Money>().AddMoney(25);

            WaveText.text = string.Format("Wave - {0}", wave.ToString());
            BloonSpawnAmount = wave * 3 / wave % 5 + wave / 3;

            Debug.Log("Wave done");
            Debug.Log(string.Format("Amount: {0}", BloonSpawnAmount));
            Debug.Log(string.Format("Hp: {0}", ((wave % 3 + 1) * wave / 3) + 1 + (wave / 10 * 5) + (wave / 20 * 10)));
        }

    }

    void SpawnBloon(int health)
    {
        GameObject instantiatedPrefab = Instantiate(prefab, new Vector3(-15.17f, -1.02f, -1), Quaternion.identity);
        instantiatedPrefab.GetComponent<Bloon>().HealthObject = HealthObject;
        instantiatedPrefab.GetComponent<Bloon>().BloonHealth = health;
        instantiatedPrefab.GetComponent<Bloon>().MoneyObject = MoneyGameObject;
    }
}
