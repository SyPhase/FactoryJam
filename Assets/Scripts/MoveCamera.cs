using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform playerCameraTransform = null;

    [Tooltip("Speed at which the camera will move")]
    [SerializeField] float speed = 10f;
    [Tooltip("number of pixels thick the border will be for the mouse to trigger camera movement")]
    [SerializeField] float screenBorderThickness = 10f;

    [Tooltip("Clamps the camera from going to the left or above this bound")]
    [SerializeField] Vector2 screenXLimits = Vector2.zero;
    [Tooltip("Clamps the camera from going to the right or below this bound")]
    [SerializeField] Vector2 screenZLimits = Vector2.zero;

    void Update()
    {
        ReadCameraInput();
    }

    void ReadCameraInput()
    {
        if (!Application.isFocused) { return; }

        Vector3 position = playerCameraTransform.position;

        Vector3 cursorMovement = Vector3.zero;

        Vector2 cursorPosition = Mouse.current.position.ReadValue();

        if (cursorPosition.y >= Screen.height - screenBorderThickness)
        {
            cursorMovement.z += 1;
        }
        else if (cursorPosition.y <= screenBorderThickness)
        {
            cursorMovement.z -= 1;
        }
        if (cursorPosition.x >= Screen.width - screenBorderThickness)
        {
            cursorMovement.x += 1;
        }
        else if (cursorPosition.x <= screenBorderThickness)
        {
            cursorMovement.x -= 1;
        }

        position += cursorMovement.normalized * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, screenXLimits.x, screenXLimits.y);
        position.z = Mathf.Clamp(position.z, screenZLimits.x, screenZLimits.y);

        playerCameraTransform.position = position;
    }
}