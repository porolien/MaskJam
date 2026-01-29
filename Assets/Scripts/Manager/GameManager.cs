using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    public UIManager UI;
    public LightManager Light;
    public SoundManager Sound;

    [Header("Settings")]
    public float DelayDeath;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);

        if (UI == null) UI = GetComposantFromGameObject<UIManager>.TryGetComposant<UIManager>(gameObject);
        if (Light == null) Light = GetComposantFromGameObject<LightManager>.TryGetComposant<LightManager>(gameObject);
        if (Sound == null) Sound = GetComposantFromGameObject<SoundManager>.TryGetComposant<SoundManager>(gameObject);

        UI.Init(this);
        Light.Init(this);
        Sound.Init(this);
    }

    private void Update()
    {
        if (DelayDeath > 0f)
        {
            DelayDeath -= Time.deltaTime;
        }
        else
        {
            DelayDeath = 0f;
            Debug.Log("Délai terminé !");
        }
    }
}
