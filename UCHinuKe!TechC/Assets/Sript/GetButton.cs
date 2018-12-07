using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetButton : MonoBehaviour {
    
    [SerializeField]
    private Scop _scop;
    //ゲーム停止文字
    [SerializeField]
    private Text StopText;
    //ゲーム停止の確認
    bool _IsStop = false;
      
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        #region gamestop
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            _IsStop = !_IsStop;
            //動けないようにする
            _scop.gamestop = !_scop.gamestop;
        }

        if (_IsStop)
        {
            //ゲーム停止
            Time.timeScale = 0;
            //停止文字を表示
            StopText.gameObject.SetActive(true);
            StopText.text = "Puase";
        }
        else
        {
            //ゲームを続き
            Time.timeScale = 1;
            //停止文字を非表示
            StopText.gameObject.SetActive(false);
        }
        
        #endregion
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //スライムのいろとボダンの色が同じ場合
        if (other.tag == "Red" && Input.GetKeyDown(KeyCode.Joystick1Button1)|| other.tag == "Yellow" && Input.GetKeyDown(KeyCode.Joystick1Button3)||
            other.tag == "Blue" && Input.GetKeyDown(KeyCode.Joystick1Button2)|| other.tag == "Green" && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //Script Suraimu の方へ行きます
            if (other.gameObject.GetComponent<Suraimu>().IsDeath == false)
            {
                //対象スライムに死亡信号を出す
                other.gameObject.GetComponent<Suraimu>().IsDeath = true;
                //正しいボダンを押した効果音
                other.gameObject.GetComponent<Suraimu>().CSound();
            }
        }
        //スライムのいろとボダンの色が間違えた場合
        else if (other.tag != "Red" && Input.GetKeyDown(KeyCode.Joystick1Button1) || other.tag != "Yellow" && Input.GetKeyDown(KeyCode.Joystick1Button3) ||
            other.tag != "Blue" && Input.GetKeyDown(KeyCode.Joystick1Button2) || other.tag != "Green" && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //間違えのボダンを押した効果音
            other.gameObject.GetComponent<Suraimu>().WSound();
        }
    }
    
}
