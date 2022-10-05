using Markdig.Syntax.Inlines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmphasisProcessor : InlineProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(EmphasisInline);
    }

    public override string ProcessInline(Inline inline)
    {
        EmphasisInline emphasis = (EmphasisInline)inline;

        string text = UIGenerator.GenerateUIFromInlineContainer(emphasis);

        string pre = "";
        string post = "";

        if(emphasis.DelimiterChar == '*')
        {
            if(emphasis.DelimiterCount == 2)
            {
                pre = "<b>";
                post = "</b>";
            }
            else
            {
                pre = "<i>";
                post = "</i>";
            }
        }

        return pre + text + post;
    }
}
