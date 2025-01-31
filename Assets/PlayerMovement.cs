using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public GameObject Player;
    public int JumpsLeft;
    public bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.right * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += -transform.forward * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.right * Time.deltaTime * 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpsLeft > 0)
            {
                Player.GetComponent<Rigidbody>().AddForce( 0,5 / 2 * 3,0, ForceMode.Impulse);
                //transform.position += transform.up * Time.deltaTime * 50 * 5f;
                JumpsLeft--;
            }
            else
            {
                Debug.Log("Can't jump! Out of jumps!");
            }
        }
        // Player movement end

        // Player jumping mechanic & grounded checking
        if (Player.GetComponent<Rigidbody>().velocity.y != 0 && IsGrounded)
        {
            IsGrounded = false;
            Debug.Log("Player left ground!");
        }

        if (Player.GetComponent<Rigidbody>().velocity.y == 0 && !IsGrounded)
        {
            IsGrounded = true;
            Debug.Log("Player made contact with ground!");
        }

        if (IsGrounded && JumpsLeft < 3 && Player.GetComponent<Rigidbody>().velocity.y == 0)
        {
            JumpsLeft = 3;
            Debug.Log("Refilled jumps!");
        }

        float mouseXMovement = Input.GetAxis("Mouse X"); // move character based on camera movement
        transform.Rotate(0, mouseXMovement * 10, 0);
        //Debug.Log(mouseXMovement);
    }
}
