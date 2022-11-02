using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRC.UdonUI;
using VRC.UdonUI.Interfaces;
using static TMPro.TMP_InputField;

public class TMPInput : ITMPInput
{
    public TMPro.TMP_InputField inputField;

    public void AddCallback(UnityAction call)
    {
        inputField.onSubmit.AddListener((v) => call());
    }

    public string GetText()
    {
        return inputField.text;
    }

    public void SetText(string text)
    {
        inputField.text = text;
    }
}
