using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    private Transform mainCameraTransform;

    [Header("Settings")]
    [SerializeField] private bool lockVerticalRotation = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCameraTransform == null) return;

        if (lockVerticalRotation)
        {
            Vector3 cameraRotation = mainCameraTransform.rotation.eulerAngles;

            transform.rotation = (Quaternion.Euler(0f, cameraRotation.y, 0f));
        }
        else
        { 
            transform.forward = mainCameraTransform.forward;
        }
    }
}
