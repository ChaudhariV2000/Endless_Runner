using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardspeed = 5;
    private int desiredlane = 1;
    public float laneDistance = 2;
    public float jumpForce;

    public float gravity = -20;
    // Start is called befre the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StaeManager.isgamestarted)
            return;

        direction.z = forwardspeed;

        forwardspeed += 0.3f * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredlane++;
            if (desiredlane == 3)
            { desiredlane = 2; }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredlane--;
            if (desiredlane == -1)
                desiredlane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredlane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredlane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        // transform.position = Vector3.Lerp(transform.position, targetPosition, 100 * Time.deltaTime);
        transform.position = targetPosition;
        controller.center = controller.center;
    }
    private void FixedUpdate()
    {
        if (!StaeManager.isgamestarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            StaeManager.gameover = true;
        }
    }


}
