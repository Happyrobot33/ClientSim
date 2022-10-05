using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UIDisplaySettings
{
    public enum DisplayType
    {
        World,
        //UI
    }

    public DisplayType displayType;
    public Vector3 offset;
    public Vector2 size = new Vector2(500,500);

    public UIPrefabHolder prefabHolder;
}
