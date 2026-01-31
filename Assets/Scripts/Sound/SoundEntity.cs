using UnityEngine;
using System.Collections.Generic;

public class SoundEntity : MonoBehaviour
{
    public List<AudioClip> PrincipaleAudio = new List<AudioClip>();
    public int CurrentAudioIndex = 0;

    public void ChangePhaseAudio()
    {
        if (CurrentAudioIndex < PrincipaleAudio.Count - 1)
        {
            CurrentAudioIndex++;
        }
        else 
        {         
            CurrentAudioIndex = 0;
        }
    }
}
