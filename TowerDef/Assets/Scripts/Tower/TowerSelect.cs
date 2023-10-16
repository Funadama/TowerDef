using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class TowerSelect : MonoBehaviour
{
    private TowerShoot TowerScript;

    public GameObject tower;
    public TowerUpgradesScript Cost;

    public Slider ModeSlider;
    public TMP_Text Stats;
    public TMP_Text Name;
    public TMP_Text ButtonUpgrade;

    public GameObject TowerUI;

    public void Select(GameObject Tower)
    {
        tower = Tower;
        TowerUI.SetActive(true);
        TowerScript = Tower.GetComponent<TowerShoot>();
        Name.text = TowerScript.TowerName;
        if (99999999 > Cost.towerUpgradesData.Upgrade[TowerScript.AtUpgrade].Cost)
        {
            ButtonUpgrade.text = string.Format("Upgrade\n{0}$", Cost.towerUpgradesData.Upgrade[TowerScript.AtUpgrade].Cost.ToString());
        }
        else
        {
            ButtonUpgrade.text = ("Upgrade\n-");
        }
        Stats.text = (string.Format("{0}\n{1}\n{2}\n{3}\n{4}", TowerScript.TowerRange.ToString(), TowerScript.FireRate.ToString(), TowerScript.FireSpeed.ToString(), TowerScript.Damage.ToString(), TowerScript.penetrating.ToString()));
        ModeSlider.value = TowerScript.TargetWhat;
    }
}
