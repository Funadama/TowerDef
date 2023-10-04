using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChangeMode : MonoBehaviour
{
    public TowerSelect towersell;

    public void Change(float amount)
    {
        towersell.tower.GetComponent<TowerShoot>().TargetWhat = Mathf.RoundToInt(amount);
    }
}
