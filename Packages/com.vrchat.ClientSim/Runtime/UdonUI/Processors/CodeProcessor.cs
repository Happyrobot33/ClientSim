using Markdig.Syntax.Inlines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeProcessor : InlineProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(CodeInline);
    }

    public override string ProcessInline(Inline inline)
    {
        CodeInline code = (CodeInline)inline;
        return $"<style=\"Code\">" + new string(code.ContentSpan.ToArray()) + "</style>";
    }
}
