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
        if (processor.IsCodeIndent)
        {
            return BlockState.None;
        }

        var column = processor.Column;
        var line = processor.Line;
        char c = line.CurrentChar;
        int titleBegin = line.Start;
        int titleEnd = titleBegin;

        int leadingCount = 0;

        while (c != '\n')
        {
            c = processor.NextChar();
            titleEnd++;
            leadingCount++;
            if (c == ']')
            {
                break;
            }
        }

        if(c == '\n')
        {
            return BlockState.None;
        }

        leadingCount++;
        c = processor.NextChar();

        if (c != '(')
        {
            return BlockState.None;
        }

        int PathBegin = titleEnd+1;
        int PathEnd = PathBegin;

        while (c != '\n')
        {
            c = processor.NextChar();
            PathEnd++;
            leadingCount++;
            if (c == ')')
            {
                break;
            }
        }

        if (c == '\n')
        {
            return BlockState.None;
        }

        UdonBlock udon = new UdonBlock(this)
        {
            title = " "
        };

        if (processor.TrackTrivia)
        {
            udon.LinesBefore = processor.UseLinesBefore();
            udon.NewLine = processor.Line.NewLine;
        }
        else
        {
            processor.GoToColumn(column + leadingCount + 1);
        }

        processor.NewBlocks.Push(udon);



        return BlockState.Break;
    }
}
