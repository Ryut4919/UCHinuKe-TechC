using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scop : MonoBehaviour {
    
    //移動速度
    public float MoveSpd=5.0f;
    //ゲームが停止確認用
    public bool gamestop=false;
	// Use this for initialization
	void Start () {
        
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
