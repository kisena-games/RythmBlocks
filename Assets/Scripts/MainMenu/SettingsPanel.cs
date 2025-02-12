using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MusicVolumeKey, 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFXVolumeKey, 0.75f);

        musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
    }

    public void HideSettings()
    {
        gameObject.SetActive(false);
    }
}
