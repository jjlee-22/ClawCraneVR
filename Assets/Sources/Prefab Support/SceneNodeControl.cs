using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class borrowed and modified from Kelvin's examples

public class SceneNodeControl : MonoBehaviour
{
    public Dropdown TheMenu;
    public SceneNode TheRoot;
    public XfromControl XformControl;
    private SceneNode mCurrentSelected;
    private const string kChildSpace = "  ";
    private List<Dropdown.OptionData> mSelectMenuOptions = new List<Dropdown.OptionData>();
    private List<Transform> mSelectedTransform = new List<Transform>();

    private void Start()
    {
        mSelectMenuOptions.Add(new Dropdown.OptionData(TheRoot.transform.name));
        mSelectedTransform.Add(TheRoot.transform);
        GetChildrenNames("", TheRoot.transform);
        TheMenu.AddOptions(mSelectMenuOptions);
        TheMenu.onValueChanged.AddListener(SelectionChange);

        mCurrentSelected = TheRoot;
        SelectionChange(0);
    }

    private void GetChildrenNames(string blanks, Transform node)
    {
        string str = blanks + kChildSpace;
        for (int i = node.childCount - 1; i >= 0; --i)
        {
            Transform child = node.GetChild(i);
            if (child.GetComponent<SceneNode>() != null)
            {
                mSelectMenuOptions.Add(new Dropdown.OptionData(str + child.name));
                mSelectedTransform.Add(child);
                GetChildrenNames(blanks + kChildSpace, child);
            }
        }
    }

    private void SelectionChange(int index)
    {
        mCurrentSelected = mSelectedTransform[index].GetComponent<SceneNode>();
        XformControl.SetSelectedObject(mSelectedTransform[index]);
    }
}
