using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

    public float playerSpeed = 5f;
    public float horizontalSpeed = 4f;
    public float rightLimit = 3.5f;
    public float leftLimit = -3.5f;
    public float jumpHeight = 6.5f;
    
    public bool isGrounded;
    private Rigidbody rb;

    public static int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            if (this.gameObject.transform.position.x > leftLimit) 
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        } 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            if (this.gameObject.transform.position.x < rightLimit) 
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }      
}
