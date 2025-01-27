using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Player's Transform
    public float followSpeed = 5f; // Speed at which the camera follows the player
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the player
    public float rotationSpeed = 5f; // Speed at which the camera rotates
    public float angleOffset = 45f; // Angle offset in degrees (Y-axis)
    public float xRotationOffset = 10f; // X rotation offset in degrees

    private void Start()
    {
        player = GameManager.Instance.bulls[Constants.CurrentTruck].transform;
    }

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned to the camera script!");
            return;
        }

        // Calculate the target position for the camera
        Vector3 targetPosition = player.position + player.TransformDirection(offset);

        // Use SmoothDamp to smoothly interpolate between current position and target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Calculate the target rotation (considering the player's forward direction and the angle offset)
        Quaternion targetRotation = Quaternion.LookRotation(player.forward, Vector3.up) * Quaternion.Euler(xRotationOffset, angleOffset, 0);

        // Smoothly interpolate the camera's rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
