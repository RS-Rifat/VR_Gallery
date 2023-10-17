/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject pic1;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.black;
    }
}
*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject pic1;

    private Renderer renderer;
    private Looc360Cursor cameraController;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent <Renderer>();
        cameraController = Camera.main.GetComponent<Looc360Cursor>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    private void OnMouseUpAsButton()
    {
        if (pic1 != null && cameraController != null)
        {
            cameraController.MoveCameraToPosition(pic1.transform.position);
        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.black;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject picObject;  // Reference to the corresponding picture object
    private Renderer renderer;
    private Looc360Cursor cameraController;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent <Renderer>();
        cameraController = Camera.main.GetComponent<Looc360Cursor>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    private void OnMouseUpAsButton()
    {
        if (picObject != null && cameraController != null)
        {
            cameraController.MoveCameraToPosition(picObject.transform.position);
        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.black;
    }
}