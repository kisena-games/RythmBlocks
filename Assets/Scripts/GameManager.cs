using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private LevelSO[] levels;

    public LevelSO CurrentLevel { get; private set; }

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
    }

    public void LoadLevel(int index)
    {
        CurrentLevel = levels[index - 1];
        SceneManager.LoadScene(index);
    }

    public void LoadMainMenu()
    {
        CurrentLevel = null;
        SceneManager.LoadScene(0);
    }
}
