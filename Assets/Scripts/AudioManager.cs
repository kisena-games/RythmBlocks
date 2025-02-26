using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixer audioMixer;

    public const string MusicVolumeKey = "MusicVolume";
    public const string SFXVolumeKey = "SFXVolume";

    private AudioSource _audioSource;
    private AudioClip _defaultMusic;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _audioSource.Stop();

        LevelSO currentLevel = GameManager.Instance.CurrentLevel;
        _audioSource.clip = currentLevel != null ? currentLevel._music : _defaultMusic;
        
        _audioSource.Play();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
        _defaultMusic = _audioSource.clip;
    }

    private void Start()
    {
        LoadVolumeSettings();
    }

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        audioMixer.SetFloat(MusicVolumeKey, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    public void SetSFXVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        audioMixer.SetFloat(SFXVolumeKey, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    }

    private void LoadVolumeSettings()
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);
        float sfxVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.75f);

        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }
}
