using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    bool isWalking = false;
    public int walkSpeed = 5;
    Rigidbody rb;
    public Vector3 forceVector = new Vector3(0,10,0);
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            anim.SetBool("isJumping", false);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.Play("Walk Cycle");
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.A))
        {
            anim.Play("Walk Cycle");
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.S))
        {
            anim.Play("Walk Cycle");
            transform.Translate(Vector3.back * Time.deltaTime * walkSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.D))
        {
            anim.Play("Walk Cycle");
            transform.Translate(Vector3.right * Time.deltaTime * walkSpeed, Space.Self);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            anim.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(forceVector, ForceMode.Impulse);
            anim.Play("Jump");
        }

    }
}