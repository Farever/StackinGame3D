using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject fallingOBJ, mainCamera;
    public int db = 0, points = 0;
    public float maxHeight, timeOfLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        points = System.Convert.ToInt32(System.Math.Round(maxHeight * 10));

        if (mainCamera.transform.position.y - maxHeight <= 8)
        {
            var step = 1 * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, mainCamera.transform.position + new Vector3(0.0f, 1.0f, 0.0f), step);
        }

        if (Time.timeSinceLevelLoad - timeOfLastSpawn > 3)
            StartCoroutine(Spawn());
    }


    public IEnumerator Spawn()
    {
        Instantiate(fallingOBJ, new Vector3(Random.Range(-2.0f, 2.0f), (5 + maxHeight), 0), Quaternion.identity);
        db++;
        timeOfLastSpawn = Time.timeSinceLevelLoad;
        yield return new WaitForSeconds(1);
    }
}
