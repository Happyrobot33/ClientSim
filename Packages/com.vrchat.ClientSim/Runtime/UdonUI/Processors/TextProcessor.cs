﻿using Markdig.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextProcessor : BlockProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(ParagraphBlock);
    }

    public override RectTransform ProcessBlock(UIDisplaySettings settings, Block block)
    {
        ParagraphBlock paragraph = (ParagraphBlock)block;
        GameObject gameObject = GameObject.Instantiate(settings.prefabHolder.Text);
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        TextMeshProUGUI textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();

        Debug.Log(paragraph.ProcessInlines);

        string text = UIGenerator.GenerateUIFromInlineContainer(paragraph.Inline);
        textMeshPro.text = string.IsNullOrEmpty(text) ? " ": text;

        return transform;
    }
}
