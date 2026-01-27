using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager Main;

    public UIInteract Interact;

    public void Init(GameManager main)
    {
        Main = main;

        if (Interact == null) Interact = GetComposantFromGameObject<UIInteract>.TryGetComposant<UIInteract>(gameObject);

        Interact.Init(this);
    }
}