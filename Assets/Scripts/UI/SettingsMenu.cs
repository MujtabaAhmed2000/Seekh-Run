using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float ExpandDuration;
    [SerializeField] float CollapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float ExpandFadeDuration;
    [SerializeField] float CollapseFadeDuration;

    Button mainButton;
    SettingsMenuItems[] menuItems;
    bool isExpanded = false;

    Vector2 MainButtonPosition;
    int itemCount;

    private void Start()
    {
        itemCount = transform.childCount - 1;
        menuItems = new SettingsMenuItems[itemCount];
        for(int i = 0; i< itemCount; i++)
        {
            menuItems[i] = transform.GetChild(i+1).GetComponent<SettingsMenuItems>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        MainButtonPosition = mainButton.transform.position;

        //Reset all new items position to MainButtonPosition
        ResetPositions();
    }

    void ResetPositions()
    {
        for(int i = 0; i < itemCount; i++)
        {
            menuItems[i].trans.position = MainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if(isExpanded)
        {
            //menu opened
            for(int i = 0; i < itemCount; i++)
            {
                //menuItems[i].trans.position = MainButtonPosition + spacing * (i + 1);
                menuItems[i].trans.DOMove(MainButtonPosition + spacing * (i + 1), ExpandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, ExpandFadeDuration).From(0f);
            }
        }
        else
        {
            //menu closed
            for(int i = 0; i < itemCount; i++)
            {
                //menuItems[i].trans.position = MainButtonPosition;
                menuItems[i].trans.DOMove(MainButtonPosition, CollapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(0f, CollapseFadeDuration);
            }
        }
        mainButton.transform.DORotate(Vector3.forward * 180f, rotationDuration).From(Vector3.zero).SetEase(rotationEase);
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
