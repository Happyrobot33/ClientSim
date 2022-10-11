using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UIPrefabHolder",menuName ="VRChat/UdonUI")]
public class UIPrefabHolder : ScriptableObject
{
    public GameObject WorldContainer;
    public GameObject Text;
    public GameObject FencedCode;
    public GameObject List;
    public GameObject ListItem;
    public GameObject Line;
    public GameObject EmptyLine;
}
