using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public string spName;

    private void InitVars()
    {
        spName = "SpawnPoint";
    }

    private void InitAll()
    {
        InitVars();
    }

    private void TeleportPlayer()
    {
        Vector3 teleportation = GameObject.Find(spName).transform.position;
        transform.position = teleportation;
    }

    private void Awake()
    {
        InitVars();
        TeleportPlayer();
    }
}
