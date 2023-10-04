using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTower : MonoBehaviour
{
    public TowerSelect towersell;

    public void SellTowerF()
    {
        Destroy(towersell.tower);
    }
}
