using Markdig.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeadingProcessor : BlockProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(HeadingBlock);
    }

    public override RectTransform ProcessBlock(UIDisplaySettings settings, Block block)
    {
        HeadingBlock heading = (HeadingBlock)block;
        GameObject gameObject = GameObject.Instantiate(settings.prefabHolder.Text);
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        TextMeshProUGUI textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();

        string text = UIGenerator.GenerateUIFromInlineContainer(heading.Inline);
        textMeshPro.text = $"<style=\"H{heading.HeaderCharCount+1}\">" + (string.IsNullOrEmpty(text) ? " " : text) + "</style>";

        return transform;
    }
}
