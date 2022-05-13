using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Vars
    public float velocity;

    // Ressources 
    public List<Sprite> coinSprites = new List<Sprite>();
    public List<Sprite> weaponSprites = new List<Sprite>();

    public GameObject coinPrefab;
    public GameObject healPrefab;

    // References
    public Player player = null;
    public FloatingTextManager floatingTextManager = null;
    public GameObject shop;

    // Logic
    public string scene;
    public int health;
    public int coins;
    public float speed;
    public int damage;
    public int maxHealth;
    public int dodge;

    public int roomCpt;

    /*
     * WHAT TO SAVE :
     *  - INT health
     *  - INT coins
     */

    public void ShowFloatingText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);     
    }

    public int GetEnemyHealthDamage()
    {
        return (int)Mathf.Round(Mathf.Sqrt(roomCpt * 2));
    }

    public float GetEnemySpeed()
    {
        return 1 + Mathf.Abs(roomCpt / 50f - 1);
    }

    public int GetEnemyAccuracy()
    {
        return (int)Mathf.Pow(GetEnemyHealthDamage() * 2, 2);
    }

    public int[] GetUpgradePrices()
    {
        int[] result = new int[3];
        result[0] = (int)Mathf.Pow(player.maxHealth, 2); // Vie
        result[1] = (int)Mathf.Pow(player.damage, 2);    // Dégat
        result[2] = (int)Mathf.Pow(player.dodge, 2);     // Esquive

        return result;
    }

    public void UpdateState()
    {
        instance.health = player.health;
        instance.coins = player.coins;
        instance.speed = player.speed;
        instance.damage = player.damage;
        instance.maxHealth = player.maxHealth;
        instance.dodge = player.dodge;
    }

    public void SaveState()
    {
        if (PlayerPrefs.HasKey("SaveState")) PlayerPrefs.DeleteKey("SaveState");

        string s = "";
        s += instance.scene + "|";
        s += instance.health.ToString() + "|";
        s += instance.coins.ToString() + "|";
        s += instance.speed.ToString() + "|";
        s += instance.damage.ToString() + "|";
        s += instance.maxHealth.ToString() + "|";
        s += instance.dodge.ToString() + "|";

        print(s);

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState()
    {
        if (PlayerPrefs.HasKey("SaveState"))
        {
            string[] data = PlayerPrefs.GetString("SaveState").Split('|');

            instance.health = int.Parse(data[1]);
            instance.coins = int.Parse(data[2]);
            instance.speed = float.Parse(data[3]);
            instance.damage = int.Parse(data[4]);
            instance.maxHealth = int.Parse(data[5]);

            SceneManager.LoadScene(data[0], LoadSceneMode.Single);
        }
    }

    public void DestroyState()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Awake()
    {
        roomCpt = 0;
        velocity = 0.7f;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadState();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
}
