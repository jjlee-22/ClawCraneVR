using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Based on Kelvin's code example during the zoom lectures that helped me immensely
// Thank you!

public class XformControl : MonoBehaviour
{
    // Initialize all the UI elements for toggle buttons, sliders, and label objects
    public Text nameOfObject;
    private GameObject m_select;

    public SliderControl x_coord;
    public SliderControl y_coord;
    public SliderControl z_coord;

    public Toggle T_translate;
    public Toggle T_rotate;
    public Toggle T_scale;

    private void ChangeTranslate(bool a)
    {
        Vector3 selectedXformParameter = GetSelectedXformParameter();
        x_coord.SetRangeSlider(-10f, 10f, selectedXformParameter.x);
        y_coord.SetRangeSlider(-10f, 10f, selectedXformParameter.y);
        z_coord.SetRangeSlider(-10f, 10f, selectedXformParameter.z);
    }

    private void ChangeRotation(bool a)
    {
        Vector3 selectedXformParameter = GetSelectedXformParameter();
        x_coord.SetRangeSlider(-180f, 180f, selectedXformParameter.x);
        y_coord.SetRangeSlider(-180f, 180f, selectedXformParameter.y);
        z_coord.SetRangeSlider(-180f, 180f, selectedXformParameter.z);
    }

    private void ChangeScaling(bool a)
    {
        Vector3 selectedXformParameter = GetSelectedXformParameter();
        x_coord.SetRangeSlider(1f, 5f, selectedXformParameter.x);
        y_coord.SetRangeSlider(1f, 5f, selectedXformParameter.y);
        z_coord.SetRangeSlider(1f, 5f, selectedXformParameter.z);
    }

    // The three methods below modifies the slider params
    private void changeX(float x)
    {
        Vector3 selectedXformParameter = GetSelectedXformParameter();
        selectedXformParameter.x = x;
        SetSelectedXform(ref selectedXformParameter);
    }

    private void changeY(float y)
    {
        Vector3 selectedXformParameter = GetSelectedXformParameter();
        selectedXformParameter.y = y;
        SetSelectedXform(ref selectedXformParameter);
    }

    private void changeZ(float z)
    {
        Vector3 selectedXformParameter = GetSelectedXformParameter();
        selectedXformParameter.z = z;
        SetSelectedXform(ref selectedXformParameter);
    }

    public void cUI()
    {
        Vector3 selectedXformParameter = GetSelectedXformParameter();
        x_coord.ChangeSliderValue(selectedXformParameter.x);
        y_coord.ChangeSliderValue(selectedXformParameter.y);
        z_coord.ChangeSliderValue(selectedXformParameter.z);
    }

    public void SetSelectedObject(GameObject m_name)
    {
        m_select = m_name;
        nameOfObject.text = (m_name == null) ? "Selected Object: none" : "Selected Object: " + m_name.name;
        cUI();
    }

    private Vector3 GetSelectedXformParameter() => !T_translate.isOn ? (!T_scale.isOn ? ((m_select == null) ? Vector3.zero : m_select.transform.localRotation.eulerAngles) : ((m_select == null) ? Vector3.one : m_select.transform.localScale)) : ((m_select == null) ? Vector3.zero : m_select.transform.localPosition);

    private void SetSelectedXform(ref Vector3 p)
    {
        if (m_select == null) return;

        if (T_translate.isOn)
        {
            m_select.transform.localPosition = p;
        }
        else if (T_scale.isOn)
        {
            m_select.transform.localScale = p;
        }
        else
        {
            m_select.transform.localRotation = new Quaternion() { eulerAngles = p };
        }
            
    }

    private void Start()
    {
        // Set listeners to look out for changes in xyz values
        x_coord.changeListener(new SliderControl.SliderCallbackDelegate(changeX));
        y_coord.changeListener(new SliderControl.SliderCallbackDelegate(changeY));
        z_coord.changeListener(new SliderControl.SliderCallbackDelegate(changeZ));

        // Set listeners to look out for any transform changes
        T_translate.onValueChanged.AddListener(new UnityAction<bool>(ChangeTranslate));
        T_rotate.onValueChanged.AddListener(new UnityAction<bool>(ChangeRotation));
        T_scale.onValueChanged.AddListener(new UnityAction<bool>(ChangeScaling));
    }
}