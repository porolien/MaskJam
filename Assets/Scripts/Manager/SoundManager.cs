using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameManager Main;

    [SerializeField] private GameObject _prefabSound2D;
    [SerializeField] private GameObject _prefabSound3D;

    public float GlobalVolume = 1f;

    public void Init(GameManager main)
    {
        Main = main;
    }

    public void PlaySoundAtPosition(AudioClip clip, Vector3 position)
    {
        if (clip == null) return;
        GameObject soundObject = Instantiate(_prefabSound3D, position, Quaternion.identity);
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = GlobalVolume;
        audioSource.Play();
        Destroy(soundObject, clip.length);
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        GameObject soundObject = Instantiate(_prefabSound2D);
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = GlobalVolume;
        audioSource.Play();
        Destroy(soundObject, clip.length);
    }
}
