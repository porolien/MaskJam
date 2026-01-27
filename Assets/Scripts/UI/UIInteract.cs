using TMPro;
using UnityEngine;

public class UIInteract : MonoBehaviour
{
    public UIManager Main;

    public TextMeshProUGUI InteractTxt;

    public void Init(UIManager main)
    {
        Main = main;
    }
}