using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private AudioClip _music;
    private int _bpm;

    private void Awake()
    {
        _music = GameManager.Instance.CurrentLevel.music;
        _bpm = GameManager.Instance.CurrentLevel.bpm;
    }
}
