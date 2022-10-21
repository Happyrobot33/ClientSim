using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Callbacks;
using UnityEngine;

namespace VRC.UdonUI
{
    [ExecuteInEditMode]
    public class UdonUIBootstrap : MonoBehaviour
    {

        [DidReloadScripts(0)]
        public static void OnDomainReload()
        {
            UdonUIGenerator.TMPRefrence = new TMPRefrence();
            UdonUIGenerator.CanvasRefrence = new CanvasGroupRefrence();
        }
    }
}
