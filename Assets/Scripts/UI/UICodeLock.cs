using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UICodeLock : MonoBehaviour
{
    public UIManager Main;

    [SerializeField] private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    [SerializeField] private EventSystem m_EventSystem;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private TextMeshProUGUI _code;
    [SerializeField] private int _codeToVerify;

    [SerializeField] private Interactable _interactableToChange;

    public void Init(UIManager main)
    {
        Main = main;
    }

    public void EnterCode()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        foreach (RaycastResult result in results)
        {
            if ((_layerMask & (1 << result.gameObject.layer)) != 0)
            {
                TextMeshProUGUI text = result.gameObject.GetComponentInChildren<TextMeshProUGUI>();
                if (text.text == "V")
                {
                    if (_code.text == _codeToVerify + "")
                    {
                        _interactableToChange.ChangeByEvent();
                    }
                    else
                    {
                        _code.text = "";
                    }
                }
                else if (_code.text.Length <= 9)
                {
                    _code.text += text.text;
                }

            }
        }
    }
}