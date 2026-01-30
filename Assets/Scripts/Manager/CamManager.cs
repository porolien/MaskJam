using Unity.Cinemachine;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public GameManager Main;

    public CinemachineCamera Cam;
    [SerializeField] private float _amplitudeDefault = 0.045f;
    [SerializeField] private float _frequencyDefault = 10f;

    private float _lastAmplitude;
    private float _lastFrequency;
    private float bobTimer = 0;
    private Vector3 startPos;

    public void Init(GameManager main)
    {
        Main = main;
    }

    /// <summary>
    /// Give a "headbobbing" effect to the camera when walking
    /// </summary>
    /// <param name="amplitude"></param>
    /// <param name="frequency"></param>
    public void HeadBobbingWalking()
    {
        float frequency = _frequencyDefault;
        float amplitude = _amplitudeDefault;

        bobTimer += Time.deltaTime * frequency;
        float bobOffsetY = Mathf.Sin(bobTimer) * amplitude;
        float bobOffsetX = Mathf.Cos(bobTimer * 0.5f) * amplitude * 0.5f;

        Cam.Target.TrackingTarget.transform.localPosition = startPos + new Vector3(bobOffsetX, bobOffsetY + 1, 0);
    }

    /// <summary>
    /// Give a "headbobbing" effect to the camera when player stop walking
    /// </summary>
    /// <param name="amplitude"></param>
    /// <param name="frequency"></param>
    public void HeadBobbingStop()
    {
        Cam.Target.TrackingTarget.transform.localPosition = Vector3.Lerp(Cam.Target.TrackingTarget.transform.localPosition, startPos + new Vector3(0, 1, 0), Time.deltaTime * 5f);
        bobTimer = 0;
    }
}
