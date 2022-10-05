using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UIGenerator
{
    private static DisplayProcessorBase[] displayProcessors =  {
        new WorldBoxProcessor()
    };

    private static BlockProcessorBase[] blockProcessors =  {
        new HeadingProcessor(),
        new FencedCodeProcessor(),
        new TextProcessor()
    };

    private static InlineProcessorBase[] inlineProcessors =  {
        new CodeProcessor(),
        new LiteralInlineProcessor(),
        new LineBreakProcessor(),
        new EmphasisProcessor()
    };

    public static RectTransform GenerateUIFromSettingAndText(UIDisplaySettings displaySettings, string text)
    {
        DisplayProcessorBase.GeneratedDisplay display = null;
        foreach (DisplayProcessorBase baseProcessor in displayProcessors)
        {
            display = baseProcessor.GenerateDisplay(displaySettings);
            if (display != null)
            {
                break;
            }
        }

        if (display == null) return null;

        display.MainObject.sizeDelta = displaySettings.size;
        display.MainObject.Rotate(Vector3.up, displaySettings.rotation);

        List<RectTransform> rectTransforms = new List<RectTransform>();

        MarkdownPipeline markdownPipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        MarkdownDocument document = Markdown.Parse(text, markdownPipeline);

        for (int i = 0; i < document.Count; i++)
        {
            Block block = document[i];

            Type type = block.GetType();
            Debug.Log($"Block type: {type}");
            foreach(BlockProcessorBase blockProcessor in blockProcessors)
            {
                if (blockProcessor.IsTypeOf(type))
                {
                    rectTransforms.Add(blockProcessor.ProcessBlock(displaySettings, block));
                    break;
                }
            }
        }

        // add objects to content
        RectTransform contentTransform = display.Content;
        foreach(RectTransform transform in rectTransforms)
            transform.SetParent(contentTransform, false);

        display.MainObject.position += displaySettings.offset;

        return display.MainObject;
    }

    public static string GenerateUIFromInlineContainer(ContainerInline inlineContainer)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach(Inline inline in inlineContainer)
        {

            Type type = inline.GetType();
            Debug.Log($"Inline type: {type}");

            foreach (InlineProcessorBase inlineProcessor in inlineProcessors)
            {
                if (inlineProcessor.IsTypeOf(type))
                {
                    stringBuilder.Append(inlineProcessor.ProcessInline(inline));
                    break;
                }
            }
        }

        return stringBuilder.ToString();
    }
}
