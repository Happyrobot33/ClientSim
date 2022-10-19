using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRC.UdonUI
{
    public class CanvasGroupRefrence : ICanvasGroupRefrence
    {
        public ICanvasGroup GetCanvasGroupFromGameObject(GameObject gameObject)
        {
            CanvasGroupRefreceObject canvasGroupRefreceObject = new CanvasGroupRefreceObject();
            canvasGroupRefreceObject.CanvasGroup = gameObject.GetComponent<CanvasGroup>();

            return canvasGroupRefreceObject;
        }
    }

    public class CanvasGroupRefreceObject : ICanvasGroup
    {
        public CanvasGroup CanvasGroup;

        public void SetAlpha(float alpha)
        {
            CanvasGroup.alpha = alpha;
        }
    }
}