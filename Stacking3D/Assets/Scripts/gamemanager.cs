using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject fallingOBJ;
    public int db = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(fallingOBJ, new Vector3(Random.Range(-2.0f, 2.0f), (5+db), 0), Quaternion.identity);
            db++;
        }
    }
}
