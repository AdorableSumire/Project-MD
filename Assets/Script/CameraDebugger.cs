using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraDebugger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Stanrt()
    {
        
        
        if (TryGetComponent<Camera>(out Camera cam))
        {
            Debug.LogError("No Camera component on " + gameObject.name);
            return;
        }

        Debug.Log("Camera enabled: " + cam.enabled);
        Debug.Log("Culling Mask: " + cam.cullingMask);
        Debug.Log("Clear Flags: " + cam.clearFlags);
        Debug.Log("Depth: " + cam.depth);
        Debug.Log("Near Clip: " + cam.nearClipPlane);
        Debug.Log("Far Clip: " + cam.farClipPlane);
        
        if (cam.cullingMask == 0)
            {
                Debug.LogWarning("Culling Mask is Nothing! Setting to Everything.");
                cam.cullingMask = ~0;
            }

            if (cam.clearFlags == CameraClearFlags.Nothing)
            {
                Debug.LogWarning("Clear Flags set to Don't Clear. Changing to Skybox.");
                cam.clearFlags = CameraClearFlags.Skybox;
            }    
        }
}
