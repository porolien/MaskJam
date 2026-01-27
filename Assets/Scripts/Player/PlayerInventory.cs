using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public PlayerMain Main;
    public List<GameObject> Inventory = new List<GameObject>();

    public void Init(PlayerMain main)
    {
        Main = main;
    }
}
