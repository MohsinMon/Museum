using Unity.VisualScripting;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public string targetTag = "Interact"; // Tag for target objects

    private ObjectDetail storedScript; // Variable to store the script reference

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the desired tag
        if (other.CompareTag(targetTag))
        {
            // Enable the UI object
            if (UIManager.Instance.eButton != null)
            {
                UIManager.Instance.eButton.SetActive(true);
                Debug.Log($"Enabled UI object: {UIManager.Instance.eButton.name}");
            }

            // Try to get a script from the target object
            storedScript = other.GetComponent<ObjectDetail>(); // Replace 'YourScriptName' with your script's name
            if (storedScript != null)
            {
                Debug.Log($"Stored script from {other.gameObject.name}");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object has the desired tag
        if (other.CompareTag(targetTag))
        {
            // Disable the UI object
            if (UIManager.Instance.eButton != null)
            {
                UIManager.Instance.eButton.SetActive(false);
                Debug.Log($"Disabled UI object: {UIManager.Instance.eButton.name}");
            }

            // Clear the stored script
            if (storedScript != null)
            {
                Debug.Log($"Clearing stored script from {other.gameObject.name}");
                storedScript.Camera.SetActive(false);
                storedScript = null;
            }
        }
    }
    private void Update()
    {
        if (storedScript!=null&&Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.eButton.SetActive(false);
            UIManager.Instance.InfoPanelStatus(true, storedScript.header, storedScript.description);
            storedScript.Camera.SetActive(true);

        } if (storedScript!=null&&Input.GetKeyDown(KeyCode.Escape))
        {
            storedScript.Camera.SetActive(false);
        }
    }
}
