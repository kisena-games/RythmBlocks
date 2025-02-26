using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public System.Action[] OnBlockPressedActions = new System.Action[9];

    [SerializeField] private TextMeshProUGUI _text;

    private Vector3 _mousePosition = Vector3.zero;

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

    #region Keyboard
    public void OnBlock1(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 0);
    }
    public void OnBlock2(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 1);
    }
    public void OnBlock3(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 2);
    }
    public void OnBlock4(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 3);
    }
    public void OnBlock5(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 4);
    }
    public void OnBlock6(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 5);
    }
    public void OnBlock7(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 6);
    }
    public void OnBlock8(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 7);
    }
    public void OnBlock9(InputAction.CallbackContext context)
    {
        TryHandleBlock(context.performed, 8);
    }

    private void TryHandleBlock(bool isHandle, int index)
    {
        if (isHandle)
        {
            OnBlockPressedActions[index]?.Invoke();
        }
    }
    #endregion

    #region Mouse

    public void OnMouseInput(InputAction.CallbackContext context)
    {
        _mousePosition = Mouse.current.position.ReadValue();
    }

    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray ray = Camera.main.ScreenPointToRay(_mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Block block))
                {
                    block.Click();
                }
            }
        }
    }

    #endregion

    #region Touch

    #endregion

    private void Update()
    {
        _text.text = string.Format("({0}, {1}, {2})", _mousePosition.x, _mousePosition.y, _mousePosition.z);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out RaycastHit hitInfo))
        //    {
        //        if (hitInfo.collider.TryGetComponent(out Block block))
        //        {
        //            block.Click();
        //        }
        //    }
        //}
    }
}
