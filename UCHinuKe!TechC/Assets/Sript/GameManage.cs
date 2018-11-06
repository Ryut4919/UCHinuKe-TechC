using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour {
    public CreateSuraimu _suraimuCreate;
    public bool Over;
    public bool Clear;

    public  Text _text;
    public GameObject _timer;
    float timer = 3;
    public GameObject BigBig;
    // Use this for initialization
    void Awake()
    {
        //_text = GetComponent<Text>();
    }    
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;
        _text.text = "" + timer.ToString("0");
        if (timer < 0)
        {
            _text.text = "Start!!!";
        }
        if (timer < -1)
        {
            _text.gameObject.SetActive(false);
            BigBig.SetActive(true);
            _timer.SetActive(true);
        }
        //gameClear
        if (Over)
        {
           _timer.GetComponent<TimerControl>().timer_over = true;
            _suraimuCreate.GameOver = true;
        }

    }
}
