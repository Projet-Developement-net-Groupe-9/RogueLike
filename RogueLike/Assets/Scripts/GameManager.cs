using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Ressources 
    public List<Sprite> coinSprites = new List<Sprite>();
    public List<Sprite> weaponSprites = new List<Sprite>();

    // References
    public Player player;
    public FloatingTextManager floatingTextManager;

    // Logic
    public string scene;
    public int health;
    public int coins;
    public float speed;
    public int maxHealth;

    public string _name;

    /*
     * WHAT TO SAVE :
     *  - INT health
     *  - INT coins
     */

    public void ShowFloatingText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);     
    }

    public void UpdateState()
    {
        instance.health = player.health;
        instance.coins = player.coins;
        instance.speed = player.speed;
        instance.maxHealth = player.maxHealth;
    }

    public void SaveState()
    {
        if (PlayerPrefs.HasKey("SaveState")) PlayerPrefs.DeleteKey("SaveState");

        string s = "";
        s += instance.scene + "|";
        s += instance.health.ToString() + "|";
        s += instance.coins.ToString() + "|";
        s += instance.speed.ToString() + "|";
        s += instance.maxHealth.ToString() + "|";

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
            instance.maxHealth = int.Parse(data[4]);

            SceneManager.LoadScene(data[0], LoadSceneMode.Single);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadState();
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
