using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{

    float speed = 10.0f;
    float zLimit = 20.0f;
    float RezLimit = -1.0f;
    bool BallOnMovingCube;

    bool PlusLimit = true;

    public GameObject Player;
    public GameObject MovingCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < zLimit && PlusLimit == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
        else if (transform.position.z > RezLimit && PlusLimit == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
        else
        {
            PlusLimit = !PlusLimit; //Changing PlusLimit into false
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /* player
            collision.gameObject
            */
            /* moving cube
            gameObject
            */

            collision.gameObject.transform.parent = gameObject.transform;

            //transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
