using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMover : MonoBehaviour
{
    bool moveEnabled = true;
    public GameObject thisOBJ;
    Rigidbody rb;
    public float m_Thrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && moveEnabled)
        {
            rb.AddForce(m_Thrust, 0, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A) && moveEnabled)
        {
            rb.AddForce(-(m_Thrust), 0, 0, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        moveEnabled = false;
        if(thisOBJ.GetComponent<cubeMover>().enabled)
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.None;

            StartCoroutine(points());

        }

    }

    public IEnumerator points()
    {
        yield return new WaitForSeconds(1);

        GameObject gamemanager = GameObject.FindWithTag("GameController");
        if (gamemanager.GetComponent<gamemanager>().maxHeight < transform.position.y)
            gamemanager.GetComponent<gamemanager>().maxHeight = transform.position.y;

        thisOBJ.GetComponent<cubeMover>().enabled = false;

    }
}
