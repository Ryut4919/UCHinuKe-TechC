using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scop : MonoBehaviour {
    
    Vector3 Dir;
    public float MoveSpd=5.0f;
	// Use this for initialization
	void Start () {
        
       // this.transform.position = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("JoyX") * MoveSpd;
        var y = Input.GetAxis("JoyY") * MoveSpd;

        transform.Translate(new Vector2(x,y));
        //Dir = new Vector3(x, y,0);
        //if (Dir.sqrMagnitude > 0f)
        //{
        //    Vector3 Destination = transform.position + Dir.normalized * MoveSpd;
        //    transform.position = Destination;
        //}
    }
}
