using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public PlayerMain Main;

    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _layerMask;

    public void Init(PlayerMain main)
    {
        Main = main;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Main.Movement.VerticalHead.position, Main.Movement.VerticalHead.TransformDirection(Vector3.forward), out hit, _raycastDistance, _layerMask))
        {
            if (hit.transform.GetComponent<InteractableMain>())
            {
                InteractableMain interactableMain = hit.transform.GetComponent<InteractableMain>();
                GameManager.Instance.UI.Interact.InteractTxt.text = interactableMain.Interactables[interactableMain.ActualInteractableIndex].GetText();
            }
            else
            {
                GameManager.Instance.UI.Interact.InteractTxt.text = hit.transform.GetComponent<Interactable>().GetText();
            }
        }
        else
        {
            GameManager.Instance.UI.Interact.InteractTxt.text = "";
        }
    }

    public void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(Main.Movement.VerticalHead.position, Main.Movement.VerticalHead.TransformDirection(Vector3.forward), out hit, _raycastDistance, _layerMask))
        {
            if (hit.transform.GetComponent<InteractableMain>())
            {
                InteractableMain interactableMain = hit.transform.GetComponent<InteractableMain>();
                interactableMain.Interactables[interactableMain.ActualInteractableIndex].GetInteract(Main);
            }
            else
            {
                hit.transform.GetComponent<Interactable>().GetInteract(Main);
            }

            
        }
    }
}
