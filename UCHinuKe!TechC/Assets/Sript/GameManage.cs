using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour {
    public CreateSuraimu _suraimuCreate;
    public GameObject ControlWLScene;
    
    public bool Over;
    public bool Clear;
    bool _over = false;
    bool Clearall = false;

    [SerializeField]
    private GameObject _PointCount;

    public  Text _text;
    public GameObject _pointChecking;
    float timer = 3;
    public GameObject BigBig;
    
	// Update is called once per frame
	void Update () {
        
        #region Timer
        timer -= Time.deltaTime;
        _text.text = "" + timer.ToString("0");
        if (timer < 0)
        {
            _text.text = "Start!!!";
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        if (timer < -1&&!Clearall)
        {
            _text.gameObject.SetActive(false);
            BigBig.SetActive(true);
            _PointCount.SetActive(true);
        }
        #endregion
        #region gameOver
        if (Over&& !_over)
        {
            //gamelose
            _pointChecking.SetActive(false);
            Debug.Log("GameOver");
            _over = true;
            _pointChecking.GetComponent<PointCheck>().GameClear = true;
            ControlWLScene.SetActive(true);
            ControlWLScene.transform.GetChild(0).GetComponent<Text>().text = "ゲーム失敗";
            ClearAll();
           
        }
        #endregion

        #region Getpoint点数を取得
        else if (_PointCount.GetComponent<PointCheck>().GameClear)
        {
            Debug.Log("ゲームクリアー！！");
            //game win
            _suraimuCreate.GameOver = true;
            ControlWLScene.SetActive(true);
            ControlWLScene.transform.GetChild(0).GetComponent<Text>().text = "ゲームクリアー！！";
            ControlWLScene.transform.GetChild(1).GetComponent<Text>().text = "点数:" + GetComponent<LifePoint>().LifeP;
            ControlWLScene.transform.GetChild(1).GetComponent<Text>().color = Color.black;
            ClearAll();
        }
        #endregion
    }

    void ClearAll()
    {
        Clearall = true;
        BigBig.SetActive(false);
        _pointChecking.SetActive(false);
    }
}
