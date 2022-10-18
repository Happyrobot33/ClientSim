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
        public void TPMSetText(GameObject gameObject, string text)
        {
            TextMeshProUGUI textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
            textMeshPro.text = text;
        }
    }
}
