using Markdig.Syntax.Inlines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBreakProcessor : InlineProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(LineBreakInline);
    }

    public override string ProcessInline(Inline inline)
    {
        return "\n";
    }
}
