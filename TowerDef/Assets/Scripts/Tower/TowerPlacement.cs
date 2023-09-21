using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject prefab;

    public void PlaceTower(Vector3 worldPosition)
    {
        Instantiate(prefab, worldPosition + new Vector3(0, 0, 9), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
