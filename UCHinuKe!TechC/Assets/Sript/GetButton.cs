using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Red"&& Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Yellow"&&Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Blue"&& Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Green" && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Destroy(other.gameObject);
        }
    }
}
