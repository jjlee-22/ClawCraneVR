using UnityEngine;
using UnityEngine.UI;

// Class borrowed and modified from Kelvin's examples

public class SliderWithEcho : MonoBehaviour
{
    public Slider TheSlider;
    public Text TheEcho;
    public Text TheLabel;
    private SliderCallbackDelegate mCallBack;
    public delegate void SliderCallbackDelegate(float v);

    private void Start()
    {
        TheSlider.onValueChanged.AddListener(SliderValueChange);
    }


    public void SetSliderListener(SliderCallbackDelegate listener)
    {
        mCallBack = listener;
    }

    private void SliderValueChange(float v)
    {
        UpdateEcho();
        if (mCallBack == null)
            return;
        mCallBack(v);
    }
    public void SetSliderLabel(string l) => TheLabel.text = l;

    public void SetSliderValue(float v)
    {
        TheSlider.value = v;
        UpdateEcho();
    }

    public void InitSliderRange(float min, float max, float v)
    {
        TheSlider.minValue = min;
        TheSlider.maxValue = max;
        SetSliderValue(v);
    }

    private void UpdateEcho() => TheEcho.text = TheSlider.value.ToString("0.0000");

}