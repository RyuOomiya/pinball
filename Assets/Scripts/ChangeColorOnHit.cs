using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnHit : MonoBehaviour
{
    //Renderer Renderer;
    int r;
    [SerializeField] List<Color> Colors;

    // Start is called before the first frame update

    void OnCollisionEnter(Collision other)
    {
        this.GetComponent<Renderer>();
        if (other.gameObject.tag =="Ball")
            {
            ChangeMaterialColor();
        }
                

    }
    void ChangeMaterialColor()
    {
        this.GetComponent<Renderer>().material.color = Colors[r];
        r++;
        if (r >= Colors.Count)
        {
            r = 0;
        }
    }
   
}
