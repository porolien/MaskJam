using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected bool _isLocked;

    [Header("Event Unlocking Settings")]
    [SerializeField] protected bool _needEventToUnlock;
    [SerializeField] protected Interactable _interactableToUnlock;

    [Header("Event Change Interactable Settings")]
    [SerializeField] protected bool _needEventToChange;
    [SerializeField] protected Interactable _interactableToChange;

    [Header("Object Unlocking Settings")]
    [SerializeField] protected bool _needObjectToUnlock;
    [SerializeField] protected GameObject _objectToUnlock;

    [Header("Text Settings")]
    [SerializeField] protected string _textWhenLock;
    [SerializeField] protected string _textWhenUnlock;

    public virtual void GetInteract(PlayerMain player)
    {
        if (_isLocked)
        {
            if (_needEventToUnlock)
            {
                GameManager.Instance.Sound.PlaySoundAtPosition(GetComponent<LockableSoundEntity>()?.LockedAudio, transform.position);
                return;
            }
            else if (_objectToUnlock)
            {
                if (player.Inventory.Inventory.Contains(_objectToUnlock))
                {
                    player.Inventory.Inventory.Remove(_objectToUnlock);
                    _isLocked = false;
                }
                else
                {
                    GameManager.Instance.Sound.PlaySoundAtPosition(GetComponent<LockableSoundEntity>()?.LockedAudio, transform.position);
                    return;
                }
            }
        }

        if (_interactableToUnlock)
        {
            UnlockInteractable();
        }

        if (GetComponent<SoundEntity>())
        {
            SoundEntity sound = GetComponent<SoundEntity>();
            GameManager.Instance.Sound.PlaySoundAtPosition(sound.PrincipaleAudio[sound.CurrentAudioIndex], transform.position);
            //GameManager.Instance.Sound.PlaySoundAtPosition(GetComponent<SoundEntity>()?.PrincipaleAudio, transform.position);
            sound.ChangePhaseAudio();
        }
    }

    public virtual string GetText()
    {
        return _isLocked ? _textWhenLock : _textWhenUnlock;
    }

    public void UnlockInteractable()
    {
        if (_interactableToUnlock)
        {
            _interactableToUnlock.UnlockByEvent();
        }
    }

    public void UnlockByEvent()
    {
        if (_needEventToUnlock)
        {
            _isLocked = false;
            _needEventToUnlock = false;
        }
    }

    public void UnlockChange()
    {
        if (_interactableToChange)
        {
            _interactableToChange.ChangeByEvent();
        }
    }

    public void ChangeByEvent()
    {
        if (_needEventToChange)
        {
            GetComponent<InteractableMain>()?.ChangeInteractable();
        }
    }
}