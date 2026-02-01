using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private List<string> _dialogLines = new List<string>();
    [SerializeField] private float _displayDuration = 5f;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private GameObject _dialogObj;
    private int _currentLineIndex = 0;

    private void Start()
    {
        GameManager.Instance.Player.DesactivatePlayer(false);
        _dialogObj.gameObject.SetActive(true);
        NewText();
    }

    private void NewText()
    {
        if (_currentLineIndex <= _dialogLines.Count - 1)
        {
            _dialogText.text = _dialogLines[_currentLineIndex];
            Invoke("NewText", _displayDuration);
            _currentLineIndex++;
        }
        else
        {
            _dialogObj.gameObject.SetActive(false);
            GameManager.Instance.Player.ActivatePlayer();
        }
    }
}