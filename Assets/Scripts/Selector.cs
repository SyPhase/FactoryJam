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
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastSelection();
        }
    }

    void RaycastSelection()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) { return; }

        print("Raycast hit: " + hit.collider.name + ", Tag:" + hit.collider.tag);

        if (hit.collider.tag == "Resource")
        {
            hit.collider.GetComponent<Resource>().SelectResource();
        }
    }
}