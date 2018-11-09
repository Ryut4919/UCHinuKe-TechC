using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButton : MonoBehaviour {
    [SerializeField]
    private Scop _scop;
    [SerializeField]
    private ParticleSystem _Bingo;
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
            _scop.gamestop = !_scop.gamestop;
        }

        if (_IsStop)
        {
            Time.timeScale = 0;
            
        }
        else
            Time.timeScale = 1;
        #endregion
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Red" && Input.GetKeyDown(KeyCode.Joystick1Button1)|| other.tag == "Yellow" && Input.GetKeyDown(KeyCode.Joystick1Button3)||
            other.tag == "Blue" && Input.GetKeyDown(KeyCode.Joystick1Button2)|| other.tag == "Green" && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //Script Suraimu の方へ行きます
            other.gameObject.GetComponent<Suraimu>().IsDeath = true;
           // Destroy(other.gameObject);
        }
        else if(other.tag != "Red" && Input.GetKeyDown(KeyCode.Joystick1Button1) || other.tag != "Yellow" && Input.GetKeyDown(KeyCode.Joystick1Button3) ||
            other.tag != "Blue" && Input.GetKeyDown(KeyCode.Joystick1Button2) || other.tag != "Green" && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {//間違えのボダンを押す場合
            //Debug.Log("Wrong Effect");
        }
    }
    
}
