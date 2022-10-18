using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace VRC.UdonUI
{
    public class UdonUIBootstrap : MonoBehaviour
    {
        public void Awake()
        {
            UdonUIGenerator.TMPRefrence = new TMPRefrence();
            UdonUIGenerator.CanvasRefrence = new CanvasGroupRefrence();
        }
    }
}
