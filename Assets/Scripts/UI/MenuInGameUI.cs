using UnityEngine;
using UnityEngine.UI;

public class MenuInGameUI : MonoBehaviour
{
    public UIManager Main;

    [Header("Menu Parts")]
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _settings;

    [Header("Menu Buttons")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _settingsBackButton;

    [Header("Menu Sliders")]
    [SerializeField] private Slider _globalVolume;

    public void Init(UIManager main)
    {
        Main = main;
        _resumeButton.onClick.AddListener(OnResumeClicked);
        _settingsButton.onClick.AddListener(OnSettingsClicked);
        _settingsBackButton.onClick.AddListener(OnSettingsBackClicked);
        _quitButton.onClick.AddListener(OnQuitClicked);

        _globalVolume.value = Main.Main.Sound.GlobalVolume;
        _globalVolume.onValueChanged.AddListener(delegate {SetGlobalVolume();});
    }

    public void ShowMenu()
    {
        _menu.SetActive(true);
        Main.Main.Player.DesactivatePlayer(false);
    }

    private void OnResumeClicked()
    {
        Main.Main.Player.ActivatePlayer();
        _menu.SetActive(false);
    }

    private void OnSettingsClicked()
    {
        _menu.SetActive(false);
        _settings.SetActive(true);
    }

    private void OnSettingsBackClicked()
    {
        _menu.SetActive(true);
        _settings.SetActive(false);
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }

    private void SetGlobalVolume()
    {
        Main.Main.Sound.GlobalVolume = _globalVolume.value;
    }
}