using UnityEngine;
using System.Collections.Generic;

public class PlayerSound : MonoBehaviour
{
    public PlayerMain Main;

    public enum AudioPlayerType
    {
        footstep,
        cough,
        breathing
    }

    [Header("List of Audio clips")]
    [SerializeField] private List<AudioClip> _footsteps = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _breathing = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _coughs = new List<AudioClip>();

    [Header("Events")]
    [SerializeField] private Vector2 _delayBreathCoughEvent;
    [SerializeField] private float _minDelayCough;
    [SerializeField] private float _delayFootsteps;

    public void Init(PlayerMain main)
    {
        Main = main;
        StartEventPlayerBreathCough();
    }

    private void PlayAudioType(AudioPlayerType audioType)
    {
        List<AudioClip> audioListToPlay = null;
        switch (audioType)
        {
            case AudioPlayerType.footstep:
                audioListToPlay = _footsteps;
                break;
            case AudioPlayerType.cough:
                audioListToPlay = _coughs;
                break;
            case AudioPlayerType.breathing:
                audioListToPlay = _breathing;
                break;
        }

        if (audioListToPlay.Count == 0) return;
        int index = Random.Range(0, audioListToPlay.Count);
        GameManager.Instance.Sound.PlaySound(audioListToPlay[index]);
    }

    private void StartEventPlayerBreathCough()
    {
        Invoke("MakePlayerBreathCough", Random.Range(_delayBreathCoughEvent.x, _delayBreathCoughEvent.y));
    }

    private void MakePlayerBreathCough()
    {
        AudioPlayerType audioType = (Random.value > 0.5f && GameManager.Instance.DelayDeath <= _minDelayCough) ? AudioPlayerType.cough : AudioPlayerType.breathing;
        PlayAudioType(audioType);

        StartEventPlayerBreathCough();
    }

    public void PlayFootstep()
    {
        PlayAudioType(AudioPlayerType.footstep);
        Invoke("PlayFootstep", _delayFootsteps);
    }

    public void StopFootstep()
    {
        CancelInvoke("PlayFootstep");
    }
}
