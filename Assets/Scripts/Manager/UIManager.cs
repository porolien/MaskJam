using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager Main;

    public UIInteract Interact;
    public ZoomInUI ZoomIn;
    public UICodeLock CodeLock;

    public GameObject PlayerAim;

    public void Init(GameManager main)
    {
        Main = main;

        if (Interact == null) Interact = GetComposantFromGameObject<UIInteract>.TryGetComposant<UIInteract>(gameObject);
        if (ZoomIn == null) ZoomIn = GetComposantFromGameObject<ZoomInUI>.TryGetComposant<ZoomInUI>(gameObject);
        if (CodeLock == null) CodeLock = GetComposantFromGameObject<UICodeLock>.TryGetComposant<UICodeLock>(gameObject);

        Interact.Init(this);
        ZoomIn.Init(this);
        CodeLock.Init(this);
    }
}