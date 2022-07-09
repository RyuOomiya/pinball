using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] AudioClip t1;
    AudioSource audio2;

    void Start()
    {
        audio2 = GetComponent<AudioSource>();
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio2.PlayOneShot(t1);
            Invoke(nameof(PushSpace), 2f);
        }
    }
    void PushSpace()
    {
        SceneManager.LoadScene("game1-1");  
    }

   
}
