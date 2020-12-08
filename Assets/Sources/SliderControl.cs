using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Again, thanks for Kelvin's examples

public class SliderControl : MonoBehaviour
{
    public Text infoLabel;
    public Slider sliderControl;
    public Text numLabel;
    
    private SliderControl.SliderCallbackDelegate m_cDelegate;

    public float GetSliderValue() => sliderControl.value; // microsoft offical doc for lamba operators

    // Set initial slider ranges for xformcontrol class
    public void SetRangeSlider(float min, float max, float v)
    {
        sliderControl.minValue = min;
        sliderControl.maxValue = max;
        ChangeSliderValue(v);
    }

    public void changeListener(SliderControl.SliderCallbackDelegate listener)
    {
        m_cDelegate = listener;
    }

    // Upon changing the transform, update the slider label
    public void ChangeSliderValue(float v)
    {
        sliderControl.value = v;

        numLabel.text = v.ToString("0");
        if (m_cDelegate == null) return;
        this.m_cDelegate(v);
    }

    private void Start()
    {
        sliderControl.onValueChanged.AddListener(new UnityAction<float>(ChangeSliderValue)); // Add listener for any changes in slider control
    }

    // Help from: https://answers.unity.com/questions/887199/how-to-assign-callback-function-to-slideronvaluech.html
    public delegate void SliderCallbackDelegate(float v);
}