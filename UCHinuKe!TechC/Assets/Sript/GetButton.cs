using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetButton : MonoBehaviour {
    [SerializeField]
    private Scop _scop;
    [SerializeField]
    private Text StopText;
    bool _IsStop = false;
    public int _point;
    
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
            _scop.gamestop = !_scop.gamestop;
        }

        if (_IsStop)
        {
            Time.timeScale = 0;
            StopText.gameObject.SetActive(true);
            StopText.text = "Puase";
        }
        else
        {
            Time.timeScale = 1;
            StopText.gameObject.SetActive(false);
        }
        
        #endregion
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Red" && Input.GetKeyDown(KeyCode.Joystick1Button1)|| other.tag == "Yellow" && Input.GetKeyDown(KeyCode.Joystick1Button3)||
            other.tag == "Blue" && Input.GetKeyDown(KeyCode.Joystick1Button2)|| other.tag == "Green" && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //Script Suraimu の方へ行きます
            other.gameObject.GetComponent<Suraimu>().IsDeath = true;
            other.gameObject.GetComponent<Suraimu>().CSound();
            _point += 1;

        }
        else if(other.tag != "Red" && Input.GetKeyDown(KeyCode.Joystick1Button1) || other.tag != "Yellow" && Input.GetKeyDown(KeyCode.Joystick1Button3) ||
            other.tag != "Blue" && Input.GetKeyDown(KeyCode.Joystick1Button2) || other.tag != "Green" && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {//間違えのボダンを押す場合
            other.gameObject.GetComponent<Suraimu>().WSound();
        }
    }
    
}
