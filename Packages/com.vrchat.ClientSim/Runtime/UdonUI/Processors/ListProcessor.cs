using Markdig.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ListProcessor : BlockProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(ListBlock);
    }

    public override RectTransform ProcessBlock(UIDisplaySettings settings, Block block)
    {
        ListBlock ListItem = (ListBlock)block;
        GameObject gameObject = GameObject.Instantiate(settings.prefabHolder.List);
        RectTransform transform = gameObject.GetComponent<RectTransform>();

        foreach (Block blockItem in ListItem )
        {
            UIGenerator.ProcessBlock(settings, blockItem).SetParent(transform);
        }

        return transform;
    }
}
