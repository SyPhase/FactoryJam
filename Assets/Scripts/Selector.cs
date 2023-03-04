using UnityEngine;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Checks for mouse click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastSelection();
        }
    }

    // Does a raycast where the mouse is to select what is clicked on
    void RaycastSelection()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) { return; }

        print("Raycast hit: " + hit.collider.name + ", Tag:" + hit.collider.tag);

        // If a resource is hit, then it calls SelectResource(), which triggers the OnResourceSelected event
        if (hit.collider.tag == "Resource")
        {
            hit.collider.GetComponent<Resource>().SelectResource();
        }
    }
}