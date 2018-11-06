using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
     Text _text;
    float timer = 3;
    public GameObject BigBig;
    // Use this for initialization
    void Awake()
    {
        _text = GetComponent<Text>();
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
        }
    }
}
