using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsPanel : MonoBehaviour
{
    public void HideLevels()
    {
        gameObject.SetActive(false);
    }

    public void LoadLevel(int index)
    {
        GameManager.Instance.LoadLevel(index);
    }
}
