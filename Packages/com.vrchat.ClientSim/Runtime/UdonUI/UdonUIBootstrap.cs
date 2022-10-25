using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor.Callbacks;
#endif
using UnityEngine;

namespace VRC.UdonUI
{
    [ExecuteInEditMode]
    public class UdonUIBootstrap : MonoBehaviour
    {

#if UNITY_EDITOR
        [DidReloadScripts(0)]
        public static void OnDomainReload()
        {
            UdonUIGenerator.TMPRefrence = new TMPRefrence();
            UdonUIGenerator.CanvasRefrence = new CanvasGroupRefrence();
        }
#endif
    }
}
