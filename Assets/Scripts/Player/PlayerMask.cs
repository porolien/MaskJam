using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMask : MonoBehaviour
{
    public PlayerMain Main;
    private bool _isWearingFirstMask;

    public void Init(PlayerMain main)
    {
        Main = main;
        _isWearingFirstMask = true;
    }

    public void ChangeMask()
    {
        if (_isWearingFirstMask)
        {
            _isWearingFirstMask = false;
        }
        else
        {
            _isWearingFirstMask = true;
        }

        GameManager.Instance.Light.SetGlobalVolumeColor(_isWearingFirstMask);
    }
}