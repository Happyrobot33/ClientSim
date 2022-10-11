using Markdig;
using Markdig.Renderers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdonMarkdownExtention : IMarkdownExtension
{
    public void Setup(MarkdownPipelineBuilder pipeline)
    {
        Debug.Log("Debug");
        if (!pipeline.BlockParsers.Contains<UdonBlockParser>())
        {
            pipeline.BlockParsers.Insert(0, new UdonBlockParser());
        }
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {

    }
}
