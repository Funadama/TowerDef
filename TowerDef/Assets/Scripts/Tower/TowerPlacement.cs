using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject gameObjectToMove;
    RaycastHit hit;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = -2;
        gameObjectToMove.transform.position = worldPosition;

        if (Input.GetMouseButtonDown(0))
            if (Physics.Raycast(worldPosition, new Vector3(0, 0, 1), out hit))
                if (hit.transform.tag == "Map")
                {
                    Instantiate(prefab, worldPosition - new Vector3(0, 0, -1), Quaternion.identity);
                }


    }
}
