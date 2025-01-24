using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // How fast the camera moves
    public float minX = -10f; // Minimum x position (left boundary)
    public float maxX = 10f;  // Maximum x position (right boundary)

    private float currentX = 0f;

    void Update()
    {
        // Get the mouse's X position relative to the screen
        float mouseX = Input.mousePosition.x;

        // If the mouse is at the left edge (0 to 10% of screen width)
        if (mouseX < Screen.width * 0.1f)
        {
            // Move the camera to the left until it reaches the left boundary
            currentX = Mathf.Clamp(transform.position.x - moveSpeed * Time.deltaTime, minX, maxX);
            transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
        }
        // If the mouse is at the right edge (90% to 100% of screen width)
        else if (mouseX > Screen.width * 0.9f)
        {
            // Move the camera to the right until it reaches the right boundary
            currentX = Mathf.Clamp(transform.position.x + moveSpeed * Time.deltaTime, minX, maxX);
            transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
        }
    }
}
