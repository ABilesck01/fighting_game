using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    public void Initialize(int value)
    {
        Slider.maxValue = value;
        Slider.value = value;
    }

    public void SetValue(int value)
    {
        Slider.value = value;
    }
}
