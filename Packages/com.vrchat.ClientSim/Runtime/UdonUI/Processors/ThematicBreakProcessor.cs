using Markdig.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThematicBreakProcessor : BlockProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(ThematicBreakBlock);
    }

    public override RectTransform ProcessBlock(UIDisplaySettings settings, Block block)
    {
        GameObject gameObject = GameObject.Instantiate(settings.prefabHolder.Line);
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        return transform;
    }
}
