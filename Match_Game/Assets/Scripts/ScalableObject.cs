using UnityEngine;

public class ScalableObject : MonoBehaviour
{
    public bool isInteractable = true; // Toggle interaction behavior
    public float scaleSpeed = 0.1f; // Adjust scaling speed

    private bool isScaling = false;
    private Vector2 lastTouchPosition;

    // Update is called once per frame
    void Update()
    {
        if (!isInteractable)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isScaling = true;
                    lastTouchPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    if (isScaling)
                    {
                        // Calculate scaling delta based on touch delta position
                        float touchDeltaX = touch.position.x - lastTouchPosition.x;
                        float delta = touchDeltaX * scaleSpeed * Time.deltaTime;

                        // Scale the object
                        Vector3 newScale = transform.localScale + Vector3.one * delta;
                        transform.localScale = newScale;

                        // Update last touch position
                        lastTouchPosition = touch.position;
                    }
                    break;
                case TouchPhase.Ended:
                    isScaling = false;
                    break;
            }
        }
    }
}