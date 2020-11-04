using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declaration

    float gravityModifer = 2.0f;
    float speed = 10.0f;
    bool OnMovingCube;
    Rigidbody playerRb;

    public GameObject MovingCube;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifer;

        playerRb = GetComponent<Rigidbody>(); //Make use of "Rigidbody"
    }

    // Update is called once per frame
    void Update()
    {
        //Declare and Init variables to erference to User Interaction inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Jump();

        //Move Player (GameOject) according to user interactions
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (OnMovingCube == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, MovingCube.transform.position.z);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moving Cube"))
        {
            OnMovingCube = true;
        }
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            OnMovingCube = false;
        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);

            OnMovingCube = false;
        }
    }
}
