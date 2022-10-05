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
        GameObject gameObject = GameObject.Instantiate(settings.prefabHolder.Text);
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        TextMeshProUGUI textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();

        Debug.Log(fencedCode.ProcessInlines);
        StringBuilder builder = new StringBuilder();

        foreach(CodeBlockLine line in fencedCode.CodeBlockLines)
        {
            builder.Append(line.ToString());
        }

        textMeshPro.text = fencedCode.Info;

        return transform;
    }
}
