using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private bool isDragging = false;
    private int touchID = -1;

    void Start()
    {
        // Get the main camera to convert screen to world position
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Handle dragging with touch input
        if (isDragging)
        {
            // Get the touch position from the first touch or the assigned touchID
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(touchID).position.x, Input.GetTouch(touchID).position.y, mainCamera.nearClipPlane));

            // Apply the offset so the object follows the touch
            transform.position = touchPosition + offset;
        }

        // Check for touch start
        if (Input.touchCount > 0)
        {
            // Loop through all touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check if the touch is on the object
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == transform)
                    {
                        // Start dragging this object if it's the one that was touched
                        isDragging = true;
                        touchID = i;  // Assign the touch ID
                        offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, 0, mainCamera.nearClipPlane));
                    }
                }
            }
        }

        // Check for touch end
        if (isDragging && Input.GetTouch(touchID).phase == TouchPhase.Ended)
        {
            isDragging = false;  // Stop dragging when touch ends
            touchID = -1;  // Reset touch ID
        }
    }
}
