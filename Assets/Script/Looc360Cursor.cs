/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looc360Cursor : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}*/


using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Looc360Cursor : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 5f;
    public float zoomSpeed = 5f; // Added zoom speed

    // Reference to the main camera
    public Camera mainCamera;

    private Vector3 originalCameraPosition; // Added for storing the original camera position

    // Target position for camera movement
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        Cursor.visible = true;
        originalCameraPosition = mainCamera.transform.position; // Store the original camera position
    }

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        // Check if camera should move
        if (isMoving)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * zoomSpeed); // Smooth camera zoom
        }
    }

    // Function to set the target position for camera movement
    public void MoveCameraToPosition(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    // Function to reset the camera to its original position
    public void ResetCameraPosition()
    {
        targetPosition = originalCameraPosition;
        isMoving = true;
    }


    #region WebGL in on Mobile check

    [DllImport(dllName: "__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        return IsMobile();
#endif

        return false;
    }
    #endregion
}