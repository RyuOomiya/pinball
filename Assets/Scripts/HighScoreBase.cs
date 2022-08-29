using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreBase : MonoBehaviour
{
    GameManager gameManager;
    [Tooltip("1-1�p�̃n�C�X�R�A�^�C��")] static public float highScoreTime1_1 = 0;
    [Tooltip("1-2�p�̃n�C�X�R�A�^�C��")] static public float highScoreTime1_2 = 0;
    [Tooltip("1-3�p�̃n�C�X�R�A�^�C��")] static public float highScoreTime1_3 = 0;

    public Text textHighScore;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        textHighScore = GameObject.Find("HighScoreText").GetComponent<Text>();
        gameManager.MyGetScene();
        if(gameManager.nowScene == GameManager.MyScene.game1_1)    //1-1���A�N�e�B�u�Ȃ炱��
        {
            SetHighScoreText(highScoreTime1_1);
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_2)    //1-2���A�N�e�B�u�Ȃ炱��
        {
            SetHighScoreText(highScoreTime1_2);
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_3)    //1-3���A�N�e�B�u�Ȃ炱��
        {
            SetHighScoreText(highScoreTime1_3);
        }
    }

    void Update()
    {
        // �ߋ��̃n�C�X�R�A�̒l�������Ă�����n�C�X�R�A���X�V���܂��i�\���͎���̃v���C������j
        if (gameManager.nowScene == GameManager.MyScene.game1_1 && highScoreTime1_1 < gameManager.clearTime) //1-1���A�N�e�B�u�Ȃ炱��
        {
            highScoreTime1_1 = gameManager.clearTime;    
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_2 && highScoreTime1_2 < gameManager.clearTime) //1-2���A�N�e�B�u�Ȃ炱��
        {
            highScoreTime1_2 = gameManager.clearTime;
        }
        else if(gameManager.nowScene == GameManager.MyScene.game1_3 && highScoreTime1_3 < gameManager.clearTime)//1-3���A�N�e�B�u�Ȃ炱��
        {
            highScoreTime1_3 = gameManager.clearTime;
        }
    }

    /// <summary>/// �n�C�X�R�A�^�C�����e�L�X�g�ɂ��ĕ\�� /// </summary>
    /// <param name="highScoreTime">�n�C�X�R�A�^�C��</param>
    private void SetHighScoreText(float highScoreTime)
    {
        textHighScore.text = "High Score :" + highScoreTime.ToString("0.00");
    }
}
