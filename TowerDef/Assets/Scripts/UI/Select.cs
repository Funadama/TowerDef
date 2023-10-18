using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    RaycastHit hit;
    public GameObject TowerUI;
    private Vector3 worldPosition;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = -10;
       

        if (Input.GetMouseButtonDown(0))
            if (Physics.Raycast(worldPosition, new Vector3(0, 0, 1), out hit))
            {
                
                if (hit.transform.tag == "Tower")
                {
                    TowerUI.SetActive(true);
                    gameObject.GetComponent<TowerSelect>().Select(hit.collider.gameObject);
                }
                else if (hit.transform.tag == "Map")
                {
                    TowerUI.SetActive(true);
                    Debug.Log("test");
                    Invoke("Place", 0.01f);

                }
            }

    }
    void Place()
    {
        hit.collider.gameObject.GetComponent<TowerPlacement>().PlaceTower(worldPosition);
    }
}
