using UnityEngine;

public class ZoomInUI : MonoBehaviour
{
    public UIManager Main;

    public GameObject ActualZoomInObj;
    public GameObject CanvasZoomIn;

    public void Init(UIManager main)
    {
        Main = main;
    }

    public void OpenZoomIn(GameObject ObjToZoomIn)
    {
        CanvasZoomIn.SetActive(true);
        ObjToZoomIn.SetActive(true);
        ActualZoomInObj = ObjToZoomIn;
        Main.Main.Player.DesactivatePlayer(true);
    }

    public void CloseZoomIn()
    {
        CanvasZoomIn.SetActive(false);
        ActualZoomInObj.SetActive(false);
        ActualZoomInObj = null;
        Main.Main.Player.ActivatePlayer();
    }
}