using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using VRC.SDK3.ClientSim;

public class UdonUI : MonoBehaviour
{
    [SerializeField]
    private TextAsset textAsset;
    [SerializeField]
    private UIDisplaySettings displaySettings;
    private RectTransform rectTransform;

    private Coroutine currentAnimation;
    private bool isVisible = true;

    void Start()
    {
        rectTransform = UIGenerator.GenerateUIFromSettingAndText(displaySettings, textAsset.text);
        rectTransform.SetParent(transform, true);
        rectTransform.position += transform.position;
    }

    public void Update()
    {
        if (displaySettings.displayType != UIDisplaySettings.DisplayType.World) return;

        Vector3 playerPos = ClientSimMain.GetInstance().GetClientSimPlayerManager().LocalPlayer().GetPosition();

        if ((playerPos - transform.position).magnitude < displaySettings.rangeToShow && !isVisible)
        {
            Toggle(true);
        }
        else if((playerPos - transform.position).magnitude > displaySettings.rangeToShow && isVisible)
        {
            Toggle(false);
        }

        if (displaySettings.billboard && isVisible)
        {
            Vector3 playerLocalPos = playerPos;
            Vector3 rectPosition = rectTransform.position;
            playerLocalPos.y = rectPosition.y;
            rectTransform.rotation = Quaternion.LookRotation(rectPosition - playerLocalPos, Vector3.up);
        }
    }


    public void Toggle(bool visible)
    {
        if(visible) rectTransform.gameObject.SetActive(true);

        isVisible = visible;

        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
            currentAnimation = null;
        }

        currentAnimation = StartCoroutine(HideShowAnimation(visible));
    }


    private IEnumerator HideShowAnimation(bool visible)
    {
        CanvasGroup canvasGroup = rectTransform.gameObject.GetComponent<CanvasGroup>();

        float time = displaySettings.transitionTime;
        float value = (visible ? 0 : 1);
        while ( time > 0)
        {

            canvasGroup.alpha = Mathf.Lerp(value, 1-value, 1 - time / displaySettings.transitionTime);
            time -= Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = (visible ? 1 : 0);

        if (!visible) rectTransform.gameObject.SetActive(false);
    }


#if UNITY_EDITOR
    public void Reset()
    {
        displaySettings = new UIDisplaySettings();
        displaySettings.prefabHolder = (UIPrefabHolder)AssetDatabase.LoadAssetAtPath("Packages/com.vrchat.clientsim/Runtime/Resources/ClientSim/UdonUI/PrefabHolderBase.asset", typeof(UIPrefabHolder));
    }
#endif

}
