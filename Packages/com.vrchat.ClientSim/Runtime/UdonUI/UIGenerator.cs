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
        new ThematicBreakProcessor(),
        new ListProcessor(),
        new ListitemProcessor(),
        new FencedCodeProcessor(),
        new TextProcessor()
    };

    private static InlineProcessorBase[] inlineProcessors =  {
        new LinkInlineProcessor(),
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
        display.MainObject.localScale *= displaySettings.Scale;

        display.Tick.gameObject.SetActive(displaySettings.tickEnabled);
        display.Tick.anchoredPosition = GetRectangleBoundsPositionForAngle(displaySettings.size / 2,displaySettings.tickRotation);
        display.Tick.localRotation = Quaternion.Euler(0,0,GetRotationBoundsFromAngle(displaySettings.tickRotation));

        List<RectTransform> rectTransforms = new List<RectTransform>();

        MarkdownPipelineBuilder markdownPipeline = new MarkdownPipelineBuilder().UseEmphasisExtras();
        markdownPipeline.UseSoftlineBreakAsHardlineBreak();
        markdownPipeline.Use<UdonMarkdownExtention>();
        markdownPipeline.EnableTrackTrivia();

        MarkdownDocument document = Markdown.Parse(text, markdownPipeline.Build());

        for (int i = 0; i < document.Count; i++)
        {
            Block block = document[i];

            if (block.LinesBefore != null)
            {
                Debug.Log(block.LinesBefore.Count);
                AddEmptyLines(rectTransforms, displaySettings, block.LinesBefore.Count);
            }

            rectTransforms.Add(ProcessBlock(displaySettings, block));

            if (block.LinesAfter != null)
            {
                AddEmptyLines(rectTransforms, displaySettings, block.LinesAfter.Count);
                Debug.Log(block.LinesAfter.Count);
            }
        }

        // add objects to content
        RectTransform contentTransform = display.Content;
        foreach (RectTransform transform in rectTransforms)
        {
            if (!transform) continue;
            transform.SetParent(contentTransform, false);
        }

        display.MainObject.position += displaySettings.offset;

        return display.MainObject;
    }

    private static void AddEmptyLines(List<RectTransform> rectTransforms, UIDisplaySettings displaySettings, int count)
    {
        for(int i = 0; i < count; i++)
            rectTransforms.Add(GameObject.Instantiate(displaySettings.prefabHolder.EmptyLine).GetComponent<RectTransform>());
    }

    public static RectTransform ProcessBlock(UIDisplaySettings displaySettings, Block block)
    {
        Type type = block.GetType();
        Debug.Log($"Block type: {type}");
        foreach (BlockProcessorBase blockProcessor in blockProcessors)
        {
            if (blockProcessor.IsTypeOf(type))
            {
                return blockProcessor.ProcessBlock(displaySettings, block);
            }
        }

        return null;
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

    private static Vector2 GetRectangleBoundsPositionForAngle(Vector2 bounds, float angle)
    {
        bounds += new Vector2(32, 32);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector2 position = new Vector2();

        if(Mathf.Abs(x) < Mathf.Abs(y))
        {
            position.x = x * bounds.x;
            position.y = (y > 0 ? 1 : -1) * bounds.y;
        }
        else
        {
            position.y = y * bounds.y;
            position.x = (x > 0 ? 1 : -1) * bounds.x;
        }

        return position;
    }

    private static float GetRotationBoundsFromAngle(float angle)
    {
        angle -= 90;
        angle /= 90;
        int angleConverted = (int)angle;
        return angleConverted * 90;
    }
}
