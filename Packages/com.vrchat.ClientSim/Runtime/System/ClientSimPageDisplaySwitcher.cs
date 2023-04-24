using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VRC.SDK3.ClientSim.ClientSimMenu;

namespace VRC.SDK3.ClientSim {

    public class ClientSimPageDisplaySwitcher : MonoBehaviour
    {
        [SerializeField]
        private ClientSimMenu menu;

        [SerializeField]
        private ClientSimDisplayedPage page; 

        public void OnButtonClicked()
        {
            menu.SetDisplayedPage(page);
        }
    }
}