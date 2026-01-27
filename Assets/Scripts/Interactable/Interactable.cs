using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected bool _isLocked;
    [SerializeField] protected GameObject _objectToUnlock;
    [SerializeField] protected string _textWhenLock;
    [SerializeField] protected string _textWhenUnlock;

    public virtual void GetInteract(PlayerMain player)
    {
        if (_isLocked)
        {
            if (player.Inventory.Inventory.Contains(_objectToUnlock))
            {
                player.Inventory.Inventory.Remove(_objectToUnlock);
                _isLocked = false;
            }
            else
            {
                return;
            }
        }
        
    }

    public virtual string GetText()
    {
        return _isLocked ? _textWhenLock : _textWhenUnlock;
    }
}