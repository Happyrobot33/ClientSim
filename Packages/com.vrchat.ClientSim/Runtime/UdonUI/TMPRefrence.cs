using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace VRC.UdonUI
{
    public class TMPRefrence : ITMPRefrence
    {
        public ITMPInput GetInputFromGameobject(GameObject gameObject)
        {
            TMPInput input = new TMPInput();
            input.inputField = gameObject.GetComponent<TMP_InputField>();
            return input;
        }

        public ITMPText GetTextFromGameobject(GameObject gameObject)
        {
            TMPText text = new TMPText();
            text.textField = gameObject.GetComponent<TMP_Text>();
            return text;
        }

        public void TPMSetText(GameObject gameObject, string text)
        {
            TextMeshProUGUI textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
            textMeshPro.text = text;
        }
    }
}
