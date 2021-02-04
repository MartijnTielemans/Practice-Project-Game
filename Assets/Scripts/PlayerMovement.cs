using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float originalSpeed = 6;
    public float runSpeed = 9;
    float currentSpeed;
    public float jumpHeight = 5;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Run") > 0)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = originalSpeed;
        }

        transform.position += new Vector3((Input.GetAxis("Horizontal") * currentSpeed) * Time.deltaTime, 0, ((Input.GetAxis("Vertical") * currentSpeed) * Time.deltaTime));
    }
}
