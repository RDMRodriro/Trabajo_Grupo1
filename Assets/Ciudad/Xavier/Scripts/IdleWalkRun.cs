using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalkRun : MonoBehaviour
{
    public CharacterController controller;
    float speed;
    public float speedW = 3f;
    public float speedR = 10f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Transform cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = speedR;
            }
            else
            {
                speed = speedW;
            }

            Vector3 moverDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moverDir.normalized * speed * Time.deltaTime);


        }
    }
}
