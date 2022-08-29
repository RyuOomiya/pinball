using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreBase : MonoBehaviour
{
    GameManager gameManager;
    [Tooltip("1-1用のハイスコアタイム")] static public float highScoreTime1_1 = 0;
    [Tooltip("1-2用のハイスコアタイム")] static public float highScoreTime1_2 = 0;
    [Tooltip("1-3用のハイスコアタイム")] static public float highScoreTime1_3 = 0;

    public Text textHighScore;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        textHighScore = GameObject.Find("HighScoreText").GetComponent<Text>();
        gameManager.MyGetScene();
        if(gameManager.nowScene == GameManager.MyScene.game1_1)    //1-1がアクティブならこれ
        {
            SetHighScoreText(highScoreTime1_1);
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_2)    //1-2がアクティブならこれ
        {
            SetHighScoreText(highScoreTime1_2);
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_3)    //1-3がアクティブならこれ
        {
            SetHighScoreText(highScoreTime1_3);
        }
    }

    void Update()
    {
        // 過去のハイスコアの値を上回っていたらハイスコアを更新します（表示は次回のプレイ時から）
        if (gameManager.nowScene == GameManager.MyScene.game1_1 && highScoreTime1_1 < gameManager.clearTime) //1-1がアクティブならこれ
        {
            highScoreTime1_1 = gameManager.clearTime;    
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_2 && highScoreTime1_2 < gameManager.clearTime) //1-2がアクティブならこれ
        {
            highScoreTime1_2 = gameManager.clearTime;
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_3 && highScoreTime1_3 < gameManager.clearTime)//1-3がアクティブならこれ
        {
            highScoreTime1_3 = gameManager.clearTime;
        }
    }

    /// <summary>/// ハイスコアタイムをテキストにして表示 /// </summary>
    /// <param name="highScoreTime">ハイスコアタイム</param>
    private void SetHighScoreText(float highScoreTime)
    {
        textHighScore.text = "High Score :" + highScoreTime.ToString("0.00");
    }
}
