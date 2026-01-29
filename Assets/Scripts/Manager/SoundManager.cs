using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameManager Main;

    [SerializeField] private GameObject _prefabSound;

    public void Init(GameManager main)
    {
        Main = main;
    }

    public void PlaySoundAtPosition(AudioClip clip, Vector3 position, float volume = 1f)
    {
        if (clip == null) return;
        GameObject soundObject = Instantiate(_prefabSound, position, Quaternion.identity);
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(soundObject, clip.length);
    }
}
