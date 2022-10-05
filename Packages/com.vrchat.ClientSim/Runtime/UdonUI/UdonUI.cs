using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdonUI : MonoBehaviour
{
    [SerializeField]
    private TextAsset textAsset;
    [SerializeField]
    private UIDisplaySettings displaySettings;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = UIGenerator.GenerateUIFromSettingAndText(displaySettings, textAsset.text);
        rectTransform.SetParent(transform, true);
        rectTransform.position += transform.position;
    }


}
