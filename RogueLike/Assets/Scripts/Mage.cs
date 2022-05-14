using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject shop;

    void Start()
    {
        shop = GetComponentInChildren<ShopMenu>().gameObject;
        shop.SetActive(false);
    }
}
