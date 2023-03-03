using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform playerCameraTransform = null;

    [SerializeField] float speed = 10f;
    [SerializeField] float screenBorderThickness = 10f;

    [SerializeField] Vector2 screenXLimits = Vector2.zero;
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