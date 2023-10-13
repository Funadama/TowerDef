using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTower : MonoBehaviour
{
    public TowerSelect towerselect;

    public GameObject TowerUI;

    public void SellTowerF()
    {
        Destroy(towerselect.tower);
        TowerUI.SetActive(false);
    }
}
