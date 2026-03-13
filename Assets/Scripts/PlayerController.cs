using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody chassis;
    float horizontalInput, verticalInput;
    public float thrust;
    public float spin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        CamFollow();
    }

    void FixedUpdate()
    {
        float drivePower = Input.GetAxis("Vertical") * thrust;
        float turnPower = Input.GetAxis("Horizontal") * spin;
        chassis.AddForce(chassis.transform.forward * drivePower * Time.fixedDeltaTime, ForceMode.Force);
        chassis.AddTorque(chassis.transform.up * turnPower * Time.fixedDeltaTime, ForceMode.Force);
        
    }

    private void CamFollow()
    {
        //transform.position = chassis.transform.position;
    }
}
