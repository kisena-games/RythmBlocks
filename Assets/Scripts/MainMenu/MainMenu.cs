using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LevelsPanel _levelsPanel;
    [SerializeField] private SettingsPanel _settingsPanel;
    [SerializeField] private AuthorsPanel _authorsPanel;

    public void ShowLevels()
    {
        _levelsPanel.gameObject.SetActive(true);
    }

    public void ShowSettings()
    {
        _settingsPanel.gameObject.SetActive(true);
    }

    public void ShowAuthors()
    {
        _authorsPanel.gameObject.SetActive(true);
    }
}
