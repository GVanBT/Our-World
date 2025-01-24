using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * Time.deltaTime * 50;
        }

        float mouseXMovement = Input.GetAxis("Mouse X");
        Debug.Log(mouseXMovement);
        transform.Rotate(0, mouseXMovement * 10, 0);
    }
}
