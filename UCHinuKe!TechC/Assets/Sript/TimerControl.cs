using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour {
    float timer = 60;
    Text TimerText;
    public bool gameClear = false;
    public bool timer_over = false;
    

	// Use this for initialization
	void Start () {
        TimerText =GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameClear&&!timer_over)
        {
            timer -= Time.deltaTime;
            TimerText.text = timer.ToString("0");

            //gameclear
            if (timer <= 0)
            {
                timer = 0;
                gameClear = true;
                Debug.Log("GameClear");
                //ShowWinScene
            }
        }
        
        
    }
}
