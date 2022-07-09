using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Block[] blocks;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameClearUI;
    [SerializeField] public GameObject stage1UI;
    [SerializeField] AudioClip a1;
    [SerializeField] AudioClip a2;
    [SerializeField] GameObject ball;
    [SerializeField] ParticleSystem particle;
    [SerializeField] ParticleSystem particle2;
    [SerializeField] ParticleSystem particle3;
    [SerializeField] private AudioSource b1;
    [SerializeField] private AudioSource b2;
    AudioSource audio1;
    private bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        audio1 = gameObject.GetComponent<AudioSource>();
        Invoke(nameof(DelayMethod), 2f);
    }

        void DelayMethod()
    {
        stage1UI.SetActive(false);
    }


    // Update is called once per frame
    private void Update()
    { 

        if (isGameClear != true)
        {
            if (DestroyAllBlocks())
            {
                //ゲームクリア
                gameClearUI.SetActive(true);               
                isGameClear = true;
                particle.Play();
                particle2.Play();
                particle3.Play();
                audio1.enabled = false;
                b1.PlayOneShot(a1);
                b2.time = 13f;
                b2.Play();
                ball.SetActive(false);
            }
        }
         
        
    }
    
    private bool DestroyAllBlocks() 
    {
        foreach(Block b in blocks)
        {
            if (b != null)
            {
                return false;
            }
        }
        return true;
    }

    public void GameOver()
    {
        //ゲームオーバー
        gameOverUI.SetActive(true);
        audio1.enabled = false;
        b1.PlayOneShot(a2);
    }

    
    public void GameRetry1()
    {
          SceneManager.LoadScene("game1-1");
    }

    public void RetrySE1()
    {
        Invoke(nameof(GameRetry1), 1f);
        
    }

    private void GameRetry2()
    {
       
        SceneManager.LoadScene("game1-2");
    }
    public void RetrySE2()
    {
        Invoke(nameof(GameRetry2), 1f);
    }

    void GameRetry3()
    {
        SceneManager.LoadScene("game1-3");
    }

    public void RetrySE3()
    {
        Invoke(nameof(GameRetry3), 1f);
    }

    private void NextGame1()
    {
        SceneManager.LoadScene("game1-2");
    }

    public void NextSE1()
    {
       
        Invoke(nameof(NextGame1), 1f);

    }

    private void NextGame2()
    {
        SceneManager.LoadScene("game1-3");
    }

    public void NextSE2()
    {
        Invoke(nameof(NextGame2), 1f); 
    }
    private void GameTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ReturnTitle1()
    {
        Invoke(nameof(GameTitle), 1f);
    }


}
