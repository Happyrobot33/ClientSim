using Markdig.Syntax.Inlines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteralInlineProcessor : InlineProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(LiteralInline);
    }

    public override string ProcessInline(Inline inline)
    {
        return inline.ToString();
    }
}
