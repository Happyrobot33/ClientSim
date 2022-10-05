using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
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

#if UNITY_EDITOR
    public void Reset()
    {
        displaySettings = new UIDisplaySettings();
        displaySettings.prefabHolder = (UIPrefabHolder)AssetDatabase.LoadAssetAtPath("Packages/com.vrchat.clientsim/Runtime/Resources/ClientSim/UdonUI/PrefabHolderBase.asset", typeof(UIPrefabHolder));
    }
#endif

}
