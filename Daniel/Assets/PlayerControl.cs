using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    bool isWalking = false;
    public int walkSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.A))
        {
            isWalking = true;
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.S))
        {
            isWalking = true;
            transform.Translate(Vector3.back * Time.deltaTime * walkSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            transform.Translate(Vector3.right * Time.deltaTime * walkSpeed, Space.Self);
        }
    }
}