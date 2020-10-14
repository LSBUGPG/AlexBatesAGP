using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    Material material;
    public float speed;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = new Material(renderer.material);
        renderer.material = material;
    }

    void Update()
    {
        Color color = material.color;
        color.a -= Time.deltaTime/speed;
        color.a = Mathf.Clamp01(color.a);
        material.color = color;
        if (color.a == 0.0f)
        {
            enabled = false;
        }
    }
}
