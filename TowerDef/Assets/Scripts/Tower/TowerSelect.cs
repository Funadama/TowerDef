using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class TowerSelect : MonoBehaviour
{
    private TowerShoot TowerScript;

    public Slider ModeSlider;
    public TMP_Text Stats;

    public void Select(GameObject Tower)
    {
        Debug.Log("test");
        TowerScript = Tower.GetComponent<TowerShoot>();
        Stats.text = (string.Format("{0}\n{1}\n{2}\n{3}\n{4}", TowerScript.TowerRange.ToString(), TowerScript.FireRate.ToString(), TowerScript.FireSpeed.ToString(), TowerScript.Damage.ToString(), TowerScript.penetrating.ToString()));
        ModeSlider.value = TowerScript.TargetWhat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
