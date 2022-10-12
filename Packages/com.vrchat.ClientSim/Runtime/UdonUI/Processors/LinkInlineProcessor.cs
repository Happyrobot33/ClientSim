using Markdig.Syntax.Inlines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkInlineProcessor : InlineProcessorBase
{
    public override bool IsTypeOf(Type type)
    {
        return type == typeof(LinkInline);
    }

    public override string ProcessInline(Inline inline)
    {
        LinkInline link = (LinkInline)inline;

        return $"<style=\"link\"><link=\"{link.Url}\"> {link.Title}</link></style>";
    }
}
