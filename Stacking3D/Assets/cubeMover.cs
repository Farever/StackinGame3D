using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMover : MonoBehaviour
{
    Rigidbody rb;
    public float m_Thrust = 50f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        while (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(transform.right * m_Thrust);
        }

        while (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(transform.right * (-(m_Thrust)));
        }
    }
}
