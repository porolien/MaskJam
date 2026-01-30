using UnityEngine;

public class InteratableZoomIn : Interactable
{
    public GameObject ObjToZoomIn;
    public override void GetInteract(PlayerMain player)
    {
        base.GetInteract(player);
        GameManager.Instance.UI.ZoomIn.OpenZoomIn(ObjToZoomIn);
    }
}