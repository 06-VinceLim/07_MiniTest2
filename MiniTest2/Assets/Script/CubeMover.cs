using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{

    float speed = 20.0f;
    float zLimit = 20.0f;
    float RezLimit = -1.0f;

    bool PlusLimit = true;

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
}
