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

    [Header("Night Vision Settings")]
    [SerializeField] private bool _setFogInNightVision = false;
    [SerializeField] private float _fogDensityInNightVision = 0f;
    [SerializeField] private float _lightIntensityInNightVision = 1f;

    [Header("Ultraviolet Settings")]
    [SerializeField] private bool _setFogInUltraviolet = true;
    [SerializeField] private float _fogDensityInUltraviolet = 0.621f;
    [SerializeField] private float _lightIntensityInUltraviolet = 0.12f;


    public void Init(GameManager main)
    {
        Main = main;
    }

    public void SetGlobalVolumeColor(bool isNightVision)
    {
        if (isNightVision)
        {
            RenderSettings.ambientLight = Color.white;
            RenderSettings.reflectionIntensity = _lightIntensityInNightVision;
            RenderSettings.fog = _setFogInNightVision;
            RenderSettings.fogDensity = _fogDensityInNightVision;
            _globalVolume.profile = _nightVisionProfil;
            foreach (GameObject obj in _ultravioletObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            RenderSettings.ambientLight = Color.black;
            RenderSettings.reflectionIntensity = _lightIntensityInUltraviolet;
            RenderSettings.fog = _setFogInUltraviolet;
            RenderSettings.fogDensity = _fogDensityInUltraviolet;
            _globalVolume.profile = _ultravioletProfil;
            foreach (GameObject obj in _ultravioletObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}