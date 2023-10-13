using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class TowerUpgradesScript : MonoBehaviour
{
    public GameObject MoneyObject;
    public TowerSelect towerselect;

    public TowerUpgradesData towerUpgradesData;


    void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "TowerUpgrades.json");

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            towerUpgradesData = JsonUtility.FromJson<TowerUpgradesData>(jsonContent);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
        Debug.Log(towerUpgradesData.Upgrade[0].TowerSprite);
    }

    public void Upgrade()
    {
        TowerShoot Tower = towerselect.tower.GetComponent<TowerShoot>();
        if (MoneyObject.GetComponent<Money>().AmountMoney >= towerUpgradesData.Upgrade[Tower.AtUpgrade].Cost)
        {
            MoneyObject.GetComponent<Money>().AddMoney(-1 * towerUpgradesData.Upgrade[Tower.AtUpgrade].Cost);

            Debug.Log("Upgraded");
            Tower.AtUpgrade = Tower.AtUpgrade + 1;
            SetStats(towerselect.tower);
        }
        else
        {
            Debug.Log("No Money");
        }
    }

    public void SetStats(GameObject TowerObject)
    {
        TowerShoot Tower = TowerObject.GetComponent<TowerShoot>();
        Tower.TowerName = towerUpgradesData.Upgrade[Tower.AtUpgrade].TowerSprite;
        Tower.TowerRange = towerUpgradesData.Upgrade[Tower.AtUpgrade].TowerRange;
        Tower.FireRate = towerUpgradesData.Upgrade[Tower.AtUpgrade].FireRate;
        Tower.FireSpeed = towerUpgradesData.Upgrade[Tower.AtUpgrade].FireSpeed;
        Tower.Damage = towerUpgradesData.Upgrade[Tower.AtUpgrade].Damage;
        Tower.penetrating = towerUpgradesData.Upgrade[Tower.AtUpgrade].penetrating;

        towerselect.Select(TowerObject);
    }

    [System.Serializable]
    public class TowerUpgradesData
    {
        public TowerUpgrade[] Upgrade;
    }

    [System.Serializable]
    public class TowerUpgrade
    {
        public string TowerSprite;
        public string BulletSprite;
        public int Cost;
        public float TowerRange;
        public float FireRate;
        public float FireSpeed;
        public float Damage;
        public bool penetrating;
    }


}
