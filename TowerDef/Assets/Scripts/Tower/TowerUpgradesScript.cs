using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class TowerUpgradesScript : MonoBehaviour
{

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
        //towerSelected.tower.GetComponent<TowerShoot>().AtUpgrade
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
    }


}
