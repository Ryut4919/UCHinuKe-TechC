using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCheck : MonoBehaviour {
    public bool GameClear = false;
    public int GoalPoint = 25;
    public int point;
    [SerializeField]
    private GetButton _getButton;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        point = _getButton._point;
        this.GetComponent<Text>().text = point + "/"+GoalPoint;
        if (point >= GoalPoint&&!GameClear)
        {
            GameClear = true;
        }
        
    }
}
