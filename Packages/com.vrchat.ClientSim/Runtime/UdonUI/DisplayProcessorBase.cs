using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DisplayProcessorBase
{
    public GeneratedDisplay GenerateDisplay(UIDisplaySettings settings)
    {
        if (!AllowedToProces(settings))
            return null;

        return GenerateDisplayInternal(settings);
    }

    protected virtual bool AllowedToProces(UIDisplaySettings Settings) => true;

    protected abstract GeneratedDisplay GenerateDisplayInternal(UIDisplaySettings Settings);

    public class GeneratedDisplay
    {
        public RectTransform MainObject;
        public RectTransform Content;
    }
}

