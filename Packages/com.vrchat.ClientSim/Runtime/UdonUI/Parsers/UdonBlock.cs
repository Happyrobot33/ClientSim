using Markdig.Parsers;
using Markdig.Syntax;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdonBlock : LeafBlock
{
    public string title;
    public string Path;

    public UdonBlock(BlockParser parser) : base(parser)
    {

        
    }
}
