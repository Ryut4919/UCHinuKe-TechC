using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour {

    [SerializeField]
    SSDataControl _ssDataControl;


    public CreateSuraimu _suraimuCreate;
    public GameObject ControlWLScene;
    
    //ゲーム失敗信号
    public bool Over;
    
    //ゲームクリア信号
    public bool Clear;

    //ゲーム失敗
    bool _over = false;
    
    //ものを非表示
    bool Clearall = false;

    //操作説明書を隠す
    bool PanelClose = false;

    [SerializeField]
    private GameObject _PointCount;

    //操作説明書
    [SerializeField]
    private GameObject _controlPanel;

    public GameObject _pointChecking;
    //最初ゲームスタートのカウントダウン
    public  Text _text;
    
    //カウントダウン時間
    float timer = 3;
    public GameObject BigBig;
    
    //スライムの撃破数
    public int Point;

    private bool _gameClear;

    //データを送る用
    private bool Sended;
    

    void Start()
    {
        //操作説明書を指定ところへ
        iTween.MoveTo(_controlPanel, new Vector3(524.0f, 418.0f, 0), 3.0f);
    }
    
	// Update is called once per frame
	void Update () {
        
        PanelC();
        if (PanelClose)
        {
                #region Timer
            timer -= Time.deltaTime;
            //整数のように表示する
            _text.text = "" + timer.ToString("0");
            if (timer < 0)
            {
                _text.text = "Start!!!";
                //BGMをプレイしてない場合
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    //BGMをプレイする
                    GetComponent<AudioSource>().Play();
                }
            }
            if (timer < -1 && !Clearall)
            {
                //カウントダウン文字を非表示
                _text.gameObject.SetActive(false);
                //ターゲットマークを表示
                BigBig.SetActive(true);
                //撃破数を表示
                _PointCount.SetActive(true);
            }
            #endregion
            #region gameOver
            //ゲームオーバーの場合
            if (Over&& !_over)
            {
                //gamelose
                _pointChecking.SetActive(false);
                //ゲーム失敗
                _over = true;
                //ゲームー終了パネルを表示
                ControlWLScene.SetActive(true);
                ControlWLScene.transform.GetChild(0).GetComponent<Text>().text = "ゲーム失敗";
                
                ClearAll();
                
                //Debug.Log("GameOver");
            }
            #endregion
        }

        #region Getpoint点数を取得
        /*else*/
        if (_PointCount.GetComponent<PointCheck>().GameClear&&!_gameClear)
        {
            //game win
            //スクリプトにゲームー終了信号を出す
            _suraimuCreate.GameOver = true;
            //ゲームー終了パネルを表示
            ControlWLScene.SetActive(true);
            ControlWLScene.transform.GetChild(0).GetComponent<Text>().text = "ゲームクリアー！！";
            ControlWLScene.transform.GetChild(1).GetComponent<Text>().text = "点数:" + GetComponent<LifePoint>().LifeP;
            ControlWLScene.transform.GetChild(1).GetComponent<Text>().color = Color.black;
            _gameClear = true; 
            
            ClearAll();
        }
        #endregion

        if (Sended)
        {
            SendDataTo();
            Sended = false;
        }
    }

    public void SendDataTo()
    {

            //今のゲームモード
            int gameMode = 0;
            //最大のゲームモード
            int MaxMode = 1;
            //取った点数
            int gameScore = GetComponent<LifePoint>().LifeP;
            //ゲーム最大点数
            int MaxScore = 3;

            _ssDataControl.SaveData(gameMode, MaxMode, gameScore, MaxScore);

    }

    void PanelC()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && !PanelClose)
        {
            //操作説明書を見えないところへ
            iTween.MoveTo(_controlPanel, new Vector3(1550.0f, 418.0f, 0), 3.0f);
            new WaitForSeconds(1f);
            //カウントダウンを表示
            _text.gameObject.SetActive(true);
            PanelClose = true;
        }
    }

    void ClearAll()
    {
        Clearall = true;
        //ターゲットマーク非表示
        BigBig.SetActive(false);
        //撃破数を非表示
        _pointChecking.SetActive(false);

        StartCoroutine("CloseWindow");

        Sended = true;

    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(6.0f);
        //6秒後ゲームーを終了する；
        Application.Quit();
    }
}
