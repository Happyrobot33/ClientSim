using Markdig.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListitemProcessor : BlockProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(ListItemBlock);
    }

    public override RectTransform ProcessBlock(UIDisplaySettings settings, Block block)
    {
        ListItemBlock ListItem = (ListItemBlock)block;
        GameObject gameObject = GameObject.Instantiate(settings.prefabHolder.ListItem);
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        RectTransform transformContent = (RectTransform)transform.Find("Content");

        TextMeshProUGUI textMeshPro = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        textMeshPro.text = ListItem.Order == 0 ? "• " : ListItem.Order + ". ";

        foreach (Block blockItem in ListItem)
        {
            UIGenerator.ProcessBlock(settings, blockItem).SetParent(transformContent);
        }

        return transform;
    }
}
