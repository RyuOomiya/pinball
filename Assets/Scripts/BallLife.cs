using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject ballPrefab;
    void Update()
    {
        GameObject ballObj = GameObject.FindGameObjectWithTag("Ball");
        if (ballObj == null)
        {
            GameObject newBall = Instantiate(ballPrefab);
            newBall.tag = ballPrefab.tag;
        }
    }
}
