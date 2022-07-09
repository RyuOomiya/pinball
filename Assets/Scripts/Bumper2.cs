using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper2 : MonoBehaviour
{

    [SerializeField] float bounce = 10f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.rigidbody.AddForce(bounce, 0, 0, ForceMode.VelocityChange);
        }
    }
   
}
