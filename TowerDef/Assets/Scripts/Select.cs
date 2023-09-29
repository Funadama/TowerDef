using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject gameObjectToMove;
    RaycastHit hit;

    
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = -10;
        gameObjectToMove.transform.position = worldPosition;

        if (Input.GetMouseButtonDown(0))
            if (Physics.Raycast(worldPosition, new Vector3(0, 0, 1), out hit))
            {
                if (hit.transform.tag == "Tower")
                {
                    gameObject.GetComponent<TowerSelect>().Select(hit.collider.gameObject);
                }
                else if (hit.transform.tag == "Map")
                {
                    hit.collider.gameObject.GetComponent<TowerPlacement>().PlaceTower(worldPosition);
                }
            }

    }
}
