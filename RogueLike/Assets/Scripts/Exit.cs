using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public GameObject[] ennemies;
    public GameObject exit;

    private void Update()
    {
        ennemies = GameObject.FindGameObjectsWithTag("enemy");
        if (ennemies.Length == 0)
        {
            GameObject door = gameObject.transform.Find("Door").gameObject;
            door.SetActive(false);
            exit.SetActive(true);
        }
    }

    private void Start()
    {
        exit = gameObject.transform.Find("Room").gameObject;
        exit.SetActive(false);
    }
}
