using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class LightManager : MonoBehaviour
{
    public GameManager Main;

    [SerializeField] private Volume _globalVolume;

    [SerializeField] private VolumeProfile _nightVisionProfil;
    [SerializeField] private VolumeProfile _ultravioletProfil;

    [SerializeField] private List<GameObject> _ultravioletObjects = new List<GameObject>();

    public void Init(GameManager main)
    {
        Main = main;
    }

    public void SetGlobalVolumeColor(bool isNightVision)
    {
        if (isNightVision)
        {
            RenderSettings.ambientLight = Color.white;
            _globalVolume.profile = _nightVisionProfil;
            foreach (GameObject obj in _ultravioletObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            RenderSettings.ambientLight = Color.black;
            _globalVolume.profile = _ultravioletProfil;
            foreach (GameObject obj in _ultravioletObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}