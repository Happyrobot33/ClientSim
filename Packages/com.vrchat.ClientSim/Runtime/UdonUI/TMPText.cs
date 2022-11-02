using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.UdonUI;
using VRC.UdonUI.Interfaces;

public class TMPText : ITMPText
{

    public TMPro.TMP_Text textField;

    public void SetText(string text)
    {
        textField.SetText(text);
    }
}
