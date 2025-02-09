using UnityEngine;
using UnityEngine.InputSystem;  // Required for new Input System

public class RotationAim : MonoBehaviour
{
    public Camera cam;
    public InputActionReference pointerPosition; // Reference for mouse position input

    private Vector2 mousePos;

    void Update()
    {
        // Read mouse position from Input System
        Vector2 screenMousePos = pointerPosition.action.ReadValue<Vector2>();

        // Convert screen position to world position
        mousePos = cam.ScreenToWorldPoint(screenMousePos);
    }

    void FixedUpdate()
    {
        // Get the parent's position
        Vector2 parentPos = transform.parent.position;

        // Calculate the direction from the parent to the mouse
        Vector2 lookDir = mousePos - parentPos;

        // Convert to angle (in degrees)
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        // Apply rotation (affects only the child, not the parent)
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

