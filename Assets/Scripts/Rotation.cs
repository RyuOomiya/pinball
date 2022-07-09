using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotAngle = 4.0f;
    
    void FixedUpdate()
    {
        transform.Rotate(rotAngle, 0f, 0f);
    }
}
