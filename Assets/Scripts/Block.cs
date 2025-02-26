using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _index = 0;
    [SerializeField] private float _timeToGlow = 1.0f;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private ColorsSO _colorsSO;

    private Material _material;
    private Color _defaultColor;

    private void OnEnable()
    {
        StartCoroutine(SubscribeToBlockPressedEvent());
    }

    private void OnDisable()
    {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.OnBlockPressedActions[_index] -= OnBlockPressed;
        }
    }

    private void Awake()
    {
        _material = _renderer.materials[1];
        _defaultColor = _material.color;
    }

    public void Click()
    {
        StartCoroutine(Glow());
    }

    private void OnBlockPressed()
    {
        StartCoroutine(Glow());
    }

    private IEnumerator SubscribeToBlockPressedEvent()
    {
        while (InputManager.Instance == null)
        {
            yield return null;
        }

        InputManager.Instance.OnBlockPressedActions[_index] += OnBlockPressed;
    }

    private IEnumerator Glow()
    {
        int randomColorIndex = Random.Range(0, _colorsSO.colors.Length);

        _material.color = _colorsSO.colors[randomColorIndex];

        yield return new WaitForSeconds(_timeToGlow);

        _material.color = _defaultColor;
    }
}
