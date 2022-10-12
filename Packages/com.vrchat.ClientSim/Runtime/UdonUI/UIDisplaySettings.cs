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

    public Vector3 offset = Vector3.zero;
    public Vector2 size = new Vector2(500,500);
    public float Scale = 1;

    public float rotation = 0;
    public bool billboard = false;

    public float rangeToShow = 8;
    public float transitionTime = 0.5f;
    public bool tickEnabled = false;
    public float tickRotation = 0;

    public UIPrefabHolder prefabHolder;
}
