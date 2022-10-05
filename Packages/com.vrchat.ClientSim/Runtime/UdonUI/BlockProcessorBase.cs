using Markdig.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockProcessorBase
{
    public abstract bool IsTypeOf(Type type);
    public abstract RectTransform ProcessBlock(UIDisplaySettings settings, Block block);
}
