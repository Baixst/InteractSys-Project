using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;

    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position);
    public event EndTouchEvent OnEndTouch;
    public Vector2 touchStartedPosition;
    public Vector2 touchEndedPosition;    

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.DefaultControls.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.DefaultControls.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        touchStartedPosition = touchControls.DefaultControls.TouchPosition.ReadValue<Vector2>();
        Debug.Log("Touch started " + touchStartedPosition);
        if (OnStartTouch != null)
        {
            OnStartTouch(touchControls.DefaultControls.TouchPosition.ReadValue<Vector2>());
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        touchEndedPosition = touchControls.DefaultControls.TouchPosition.ReadValue<Vector2>();
        Debug.Log("Touch ended " + touchEndedPosition);
        if (OnEndTouch != null)
        {
            OnEndTouch(touchControls.DefaultControls.TouchPosition.ReadValue<Vector2>());
        }
    }
}
