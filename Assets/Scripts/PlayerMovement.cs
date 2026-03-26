using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    bool sprinting;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (sprinting == true)
        {
            rb.AddForce(moveDirection * moveSpeed * 2f, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(moveDirection * moveSpeed, ForceMode.Impulse);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        MyInput();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
}
