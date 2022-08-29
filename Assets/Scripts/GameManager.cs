using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : HighScoreBase
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
    [SerializeField] Text clearTimeText;
    [SerializeField] GameObject leftTimerUI;
    int stopTimer = 1;
    [Tooltip("制限時間")] float leftTimer = 60.0f;
    AudioSource audio1;
    private Text texLeft;
    private Text texCT;
    private GameObject leftObj;
    private bool isGameClear = false;
    public float clearTime;

    /// <summary>/// シーン管理/// </summary>
    public enum MyScene
    {
        Title,
        game1_1,
        game1_2,
        game1_3
    }
    [Tooltip("現在アクティブなシーン")]
    public MyScene nowScene;

    static Dictionary<string, MyScene> sceneDic = new Dictionary<string, MyScene>
    {
        {"Title" , MyScene.Title},
        {"game1-1" , MyScene.game1_1},
        {"game1-2" , MyScene.game1_2},
        {"game1-3" , MyScene.game1_3}
    };
    /// <summary>
    /// 今アクティブなシーンの名前をもってきてDictionaryのKeyとして使いnowSceneに渡す
    /// </summary>
    /// <returns>今アクティブなシーンを返す</returns>
    public MyScene MyGetScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        nowScene = sceneDic[sceneName];
        return nowScene;
    }

    void Start()
    {
        leftObj = GameObject.Find("LeftTimer");
        texLeft = leftObj.GetComponent<Text>();
        audio1 = gameObject.GetComponent<AudioSource>();
        Invoke(nameof(DelayUIMethod), 1f);
    }

    void DelayUIMethod()
    {
        stage1UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー処理
        if (Ball.stop)
        {
            leftTimer -= Time.deltaTime * stopTimer;
            texLeft.text = "Time :" + leftTimer.ToString("0.00");
            if (leftTimer < 0)
            {
                GameOver();
                stopTimer = 0;
                leftTimerUI.SetActive(false);
            }

        }

        if (isGameClear != true)
        {
            if (DestroyAllBlocks())
            {
                //ゲームクリア
                clearTime = leftTimer;
                leftTimerUI.SetActive(false);
                stopTimer = 0;
                texCT = clearTimeText.GetComponent<Text>();
                texCT.text = "Clear Time : " + leftTimer.ToString("0.00");
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
        foreach (Block b in blocks)
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

    /// <summary>
    /// リトライのためにシーンを再読み込み
    /// </summary>
    private void GameRetry()
    {
        Ball.stop = false;
        int nowScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nowScene);
    }
    /// <summary>
    /// ボタンのSEを鳴らすために実行を遅らせる
    /// </summary>
    public void DelayRetryMethod()
    {
        Invoke(nameof(GameRetry), 1f);
    }

    private void NextScene()
    {
        MyGetScene();
        Ball.stop = false;
        var nextScene = (int)nowScene + 1;
        int allSceneCount = SceneManager.sceneCountInBuildSettings;
        if (nextScene < allSceneCount)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void DelayNextMethod()
    {
        Invoke(nameof(NextScene), 1f);
    }
    private void NextGame1()
    {
        Ball.stop = false;
        SceneManager.LoadScene(2);
    }

    public void NextSE1()
    {

        Invoke(nameof(NextGame1), 1f);

    }

    private void NextGame2()
    {
        Ball.stop = false;
        SceneManager.LoadScene(3);
    }

    public void NextSE2()
    {
        Invoke(nameof(NextGame2), 1f);
    }
    private void GameTitle()
    {
        Ball.stop = false;
        SceneManager.LoadScene(0);
    }

    public void ReturnTitle1()
    {
        Invoke(nameof(GameTitle), 1f);
    }


}
