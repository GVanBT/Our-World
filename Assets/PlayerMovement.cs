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
    Animator playerAnim;
    // Start is called before the first frame update
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * 10;
            playerAnim.SetBool("running", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * 10;
            playerAnim.SetBool("running", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * 10;
            playerAnim.SetBool("running", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * 10;
            playerAnim.SetBool("running", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpsLeft > 0)
            {
                Player.GetComponent<Rigidbody>().AddForce( 0,5 / 2 * 3,0, ForceMode.Impulse);
                playerAnim.SetBool("jumping", true);
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
            playerAnim.SetBool("jumping", false);
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
