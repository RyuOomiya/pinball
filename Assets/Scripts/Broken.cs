using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    
   
    public GameManager myManager;

    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        Destroy(other.gameObject);
        myManager.GameOver();
    }
}
