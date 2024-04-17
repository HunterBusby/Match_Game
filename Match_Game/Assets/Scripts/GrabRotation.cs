using UnityEngine;

public class GrabRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public bool isRotatable = true; // Toggle rotation behavior

    private bool isRotating = false;
    private Vector2 lastTouchPosition;

    private void OnMouseDown()
    {
        if (isRotatable) // Check if rotation is allowed
        {
            isRotating = true;
            lastTouchPosition = Input.mousePosition;
        }
    }

    private void OnMouseUp()
    {
        isRotating = false;
    }

    private void OnMouseDrag()
    {
        if (isRotating)
        {
            Vector2 currentTouchPosition = Input.mousePosition;
            Vector2 touchDelta = currentTouchPosition - lastTouchPosition;

            float rotationX = -touchDelta.y * rotationSpeed * Time.deltaTime;
            float rotationY = touchDelta.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationY, Space.World); 
            transform.Rotate(Vector3.right, rotationX, Space.World); 

            lastTouchPosition = currentTouchPosition;
        }
    }
}