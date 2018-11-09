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
    //private GameObject _timer;

    public  Text _text;
    public GameObject _timer;
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
        }
        if (timer < -1&&!Clearall)
        {
            _text.gameObject.SetActive(false);
            BigBig.SetActive(true);
            _timer.SetActive(true);
        }
        #endregion
        #region gamoverOr
        if (Over&& !_over)
        {
            //gamelose
            Debug.Log("GameOver");
            _over = true;
            _timer.GetComponent<TimerControl>().timer_over = true;
            ControlWLScene.SetActive(true);
            ControlWLScene.transform.GetChild(0).GetComponent<Text>().text = "ゲーム失敗";
            ClearAll();
           //call losescene;
        }
        else if (_timer.GetComponent<TimerControl>().gameClear)
        {
            //game win
            _suraimuCreate.GameOver = true;
            ControlWLScene.SetActive(true);
            ControlWLScene.transform.GetChild(0).GetComponent<Text>().text = "ゲームクリアー！！";
            _timer.GetComponent<Text>().text = "点数:" + GetComponent<LifePoint>().LifeP ;
            _timer.GetComponent<Text>().color = Color.black;
        }
        #endregion
        
        #region Getpoint点数を取得

        #endregion
    }

    void ClearAll()
    {
        Clearall = true;
        BigBig.SetActive(false);
        _timer.SetActive(false);
    }
}
