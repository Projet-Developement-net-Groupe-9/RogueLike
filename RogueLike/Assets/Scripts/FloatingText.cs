using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;
    public Text text;

    public bool active;
    public float duration;
    public float lastShown;
    public Vector3 motion;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if (active)
        {
            if (Time.time - lastShown > duration)
                Hide();
        }
        else return;

        go.transform.position += motion * Time.deltaTime;
    }

    private void Start()
    {
        gm = GameManager.instance;
    }
}
