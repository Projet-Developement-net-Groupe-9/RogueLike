using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = this.gameObject;
    }

    private void InitVars()
    {
        floatingTexts = new List<FloatingText>();
    }

    private void InitGmVars()
    {
        gm.floatingTextManager = this;
    }

    private void InitAll()
    {
        InitObjects();
        InitVars();
        InitGmVars();
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        Text txt = floatingText.text;
        txt.text = msg;
        txt.fontSize = fontSize;
        txt.color = color;
        txt.transform.position = Camera.main.WorldToScreenPoint(position);

        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText floatingText = floatingTexts.Find(t => !t.active);

        if (floatingText == null)
        {
            floatingText = go.AddComponent<FloatingText>();

            floatingText.go = Instantiate(textPrefab, go.transform);
            floatingText.text = floatingText.go.GetComponent<Text>();
            floatingTexts.Add(floatingText);
        }

        return floatingText;
    }

    private void UpdateFloatingTexts()
    {
        foreach (FloatingText floatingText in floatingTexts)
            floatingText.UpdateFloatingText();
    }

    private void Start()
    {
        InitAll();
    }

    private void Update()
    {
       UpdateFloatingTexts();
    } 
}
