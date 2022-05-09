using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    private Transform uTransform;

    private float scale;
    private bool increment;
 
    void Start()
    {
        uTransform = GetComponent<Transform>();
        scale = 0f;
        increment = true;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(scale) > 1f) increment = !increment;

        if (increment) scale += (1 / 5f) / 6f;
        else scale -= (1 / 5f) / 6f;

        uTransform.localScale = new Vector3 (scale, 1, 1);
    }
}
