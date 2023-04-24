using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.UdonUI.Interfaces;

public class ClientSimUdonUI : MonoBehaviour, IQuickMenuReference
{
    private struct UdonUISortObject
    {
        public int index;
        public RectTransform transform;
    }

    [SerializeField]
    private RectTransform Content;

    private List<UdonUISortObject> udonUISortObjects = new List<UdonUISortObject>();

    public void AddPanelToMenu(RectTransform transform, int index)
    {
        transform.SetParent(Content, false);

        udonUISortObjects.Add(new UdonUISortObject()
        {
            index = index,
            transform = transform
        });
        Sort();
    }

    public Vector2 GetSizeOfPanel()
    {
        return Content.rect.size;
    }

    public void Sort()
    {
        udonUISortObjects.Sort((a, b) => a.index.CompareTo(b.index));

        for (int i = 0; i < udonUISortObjects.Count; i++)
        {
            if (udonUISortObjects[i].transform != null)
            {
                udonUISortObjects[i].transform.SetAsLastSibling();
            }
            else
            {
                udonUISortObjects.RemoveAt(i);
                i--;
            }
        }
    }
}
