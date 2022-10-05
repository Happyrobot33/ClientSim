using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InlineProcessorBase
{

    public abstract bool IsTypeOf(Type type);
    public abstract string ProcessInline(Inline inline);
}
