using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    bool isJumping = false;
    bool isGrounded = true;
    public int walkSpeed = 5;
    public int TurningSpeed = 10;
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
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * TurningSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;

        transform.Rotate(0, horizontal, 0);
        transform.Translate(0, 0, vertical);



        if (isJumping == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                anim.Play("Walk Cycle");
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                anim.Play("Idle");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Jump());           
            }
            
        }
    }

   private IEnumerator Jump()
   {
        rb.AddForce(forceVector, ForceMode.Impulse);
        anim.Play("Jump");
        isJumping = true;
        Debug.Log("I have Started My Coroutine");
        isGrounded = false;

        yield return  new WaitForSeconds(1.5f);

        if (isGrounded)
        {
            Debug.Log("I have ENDED My Coroutine");
            isJumping = false;
        }
        else StartCoroutine(Jump());
   }

}