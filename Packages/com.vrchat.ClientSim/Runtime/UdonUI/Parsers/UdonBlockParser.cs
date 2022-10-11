using Markdig.Parsers;
using Markdig.Syntax;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdonBlockParser : BlockParser
{
    public UdonBlockParser()
    {
        OpeningCharacters = new [] { 'U' };
    }

    public override BlockState TryOpen(BlockProcessor processor)
    {
        Debug.Log("TryOpen debug");
        processor.NewBlocks.Push(new UdonBlock(this));
        return BlockState.Continue;
    }

    public override bool CanInterrupt(BlockProcessor processor, Block block)
    {
        Debug.Log("empty line interrupt debug");
        return true;
    }

    public override BlockState TryContinue(BlockProcessor processor, Block block)
    {
        processor.Close(block);
        return BlockState.None;
    }
}
