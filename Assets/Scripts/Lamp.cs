using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private Color startColor, endColor;
    [Range(0f, 10f), SerializeField] private float blinkSpeed;
    private Light light;

    private void Start()
    {
        light = GetComponent<Light>();
    }
    public void Blink(float num)
    {
        light.color = Color.Lerp(startColor, endColor, num);
        light.intensity = Mathf.Lerp(0, 1, Mathf.PingPong(Time.time * blinkSpeed, 0.7f));
    }
}
