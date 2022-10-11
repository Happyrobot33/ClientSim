using Markdig.Helpers;
using Markdig.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using static Markdig.Syntax.CodeBlock;

public class FencedCodeProcessor : BlockProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(FencedCodeBlock);
    }

    public override RectTransform ProcessBlock(UIDisplaySettings settings, Block block)
    {
        FencedCodeBlock fencedCode = (FencedCodeBlock)block;
        GameObject gameObject = GameObject.Instantiate(settings.prefabHolder.FencedCode);
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        TextMeshProUGUI textMeshPro = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        StringBuilder builder = new StringBuilder();

        foreach(StringLine line in fencedCode.Lines.Lines)
        {
            builder.AppendLine(line.ToString());
        }

        textMeshPro.text = builder.ToString();

        return transform;
    }
}
