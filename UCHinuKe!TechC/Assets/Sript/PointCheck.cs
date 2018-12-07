using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCheck : MonoBehaviour {

    //ゲーム終了確認
    public bool GameClear = false;
    //スライム目標撃破数
    public int GoalPoint;
    //今の撃破数
    public int point =0;
    [SerializeField]
    private GameManage _GM;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //ゲームマネージャーから今までの撃破数を取る
        point = _GM.Point;
        //撃破数の表示
        this.GetComponent<Text>().text = point + "/"+GoalPoint;
        //撃破数が達成する場合
        if (point >= GoalPoint )
        {
            //ゲーム終了
            GameClear = true;
        }

    }
}
