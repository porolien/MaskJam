using UnityEngine;
using System.Collections.Generic;

public class InteractableMain : MonoBehaviour
{
    public int ActualInteractableIndex = 0;
    public List<Interactable> Interactables = new List<Interactable>();

    public void ChangeInteractable()
    {
        Interactables[ActualInteractableIndex].enabled = false;
        ActualInteractableIndex++;
        Interactables[ActualInteractableIndex].enabled = true;
    }
}