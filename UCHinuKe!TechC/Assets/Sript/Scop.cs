using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scop : MonoBehaviour {
    
    Vector3 Dir;
    public float MoveSpd=5.0f;
    public bool gamestop=false;
	// Use this for initialization
	void Start () {
        
       // this.transform.position = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {

        if (!gamestop)
        {
            var x = Input.GetAxis("JoyX") * MoveSpd;
            var y = Input.GetAxis("JoyY") * MoveSpd;

            transform.Translate(new Vector2(x, y));
        }
        else
            return;

    }
}
