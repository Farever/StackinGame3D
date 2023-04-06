using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public GameObject fallingOBJ, mainCamera;
    public int db = 0, points = 0;
    public float maxHeight, timeOfLastSpawn, remainingTime = 120, timeBeetwenSpawns = 3;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timeText.text = System.Math.Round(remainingTime).ToString();
        }
        else
        {
            Debug.Log("Game Over, " + points);
        }
        
        points = System.Convert.ToInt32(System.Math.Round(maxHeight * 10));

        if (mainCamera.transform.position.y - maxHeight <= 6)
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

        if (timeBeetwenSpawns > 2)
            timeBeetwenSpawns -= 0.05f;

        timeOfLastSpawn = Time.timeSinceLevelLoad;
        yield return new WaitForSeconds(1);
    }
}
