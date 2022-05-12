using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private string objId;

    private void PrintId() => print(objId);

    private void Awake()
    {
        objId = name + transform.position.ToString();
    }

    private void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                {
                    PrintId();
                    Destroy(gameObject);
                }                
            }   
        }
        
        DontDestroyOnLoad(gameObject);
    }
}
