using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public bool canLook;

    public Transform orientation;
    Quaternion targetRotation;

    float xRotation;
    float yRotation;
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        canLook = true;
        //locks cursor to centre of screena and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canLook == true)
        {
            //get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            //sets the rotation value based on the mouse input, looks wrong
            //but the x and y rotation of the player will be dictated by the opposite
            //mouse roatation.
            yRotation += mouseX;
            xRotation -= mouseY;

            //Stops player looking above or below 90 degrees from the horizon.
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate the camera
            targetRotation = Quaternion.Euler(xRotation, yRotation, 0);
            transform.rotation = targetRotation;
            //rotate the player around the y axis
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}