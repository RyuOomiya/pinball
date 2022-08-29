using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float timer;
    [SerializeField] Text timerText;
    [SerializeField] GameManager gameManager;
    private GameObject timeObj;
    private GameObject startObj;
    private Text tex;
    private Text tex2;
    int seconds;
    static public bool stop = false;
    private bool start = false;
 
   
    void Start()
    {
       ;
        timeObj = GameObject.Find("TimerText");
        startObj = GameObject.Find("StartText");
        tex = timeObj.GetComponent<Text>();
        tex2 = startObj.GetComponent<Text>();
        

    }

    
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.stage1UI.activeSelf)
        {

            if (timer > 1)
            {
                timer -= Time.deltaTime;

            }
            else if (timer < 1 && !start)
            {
                tex2.enabled = true;
                Destroy(tex2, 0.5f);
                tex.enabled = false;
                start = true;
            }
        }
        seconds = (int)timer;
        timerText.text = seconds.ToString();
        if (timer < 1 && !stop) //timer‚ª1‚É‚È‚é‚©‚Âstop‚ªfalse‚ÌŽž
        {
            this.GetComponent<Rigidbody>().AddForce(-speed, 0f, -speed, ForceMode.VelocityChange);
            stop = true;
        }
    }
}
