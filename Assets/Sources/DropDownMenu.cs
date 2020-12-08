using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    public Dropdown m_DropDownMenu;
    public WorldController world;

    // Create an indexed array of the primitive types
    private PrimitiveType[] pType = new PrimitiveType[4]
    {
        PrimitiveType.Cube,
        PrimitiveType.Cube,
        PrimitiveType.Sphere,
        PrimitiveType.Cylinder
    };

    // Since the dropdownmenu is indexed, we just select based on the index
    private void DropDownSelect(int index)
    {
        if (index == 0)
            return;
        m_DropDownMenu.value = 0;
        world.CreatePrimitive(pType[index]);
    }

    private void Start()
    {
        m_DropDownMenu.onValueChanged.AddListener(new UnityAction<int>(DropDownSelect)); // Add a dropdown menu that listens for any changes of its value
    }
}
