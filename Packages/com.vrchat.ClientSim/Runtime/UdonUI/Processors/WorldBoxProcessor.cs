using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldBoxProcessor : DisplayProcessorBase
{
    protected override bool AllowedToProces(UIDisplaySettings Settings)
    {
        return Settings.displayType == UIDisplaySettings.DisplayType.World;
    }

    protected override GeneratedDisplay GenerateDisplayInternal(UIDisplaySettings Settings)
    {
        GeneratedDisplay display = new GeneratedDisplay
        {
            MainObject = GameObject.Instantiate(Settings.prefabHolder.WorldContainer).GetComponent<RectTransform>(),
        };
        
        display.Content = (RectTransform)display.MainObject.Find("Scroll View/Viewport/Content").transform;
        return display;
    }
}
