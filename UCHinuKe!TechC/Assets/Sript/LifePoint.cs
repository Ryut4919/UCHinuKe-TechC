using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour {
    //スライム呼び出しスクリプト
    public CreateSuraimu _suraimuCreate;
    //ダメージ受付た時のパネル
    public GameObject _getdamagePanel;
    //生命数消す用
    public bool DeleteLife = false;
    //プレイヤーの生命数
    public int LifeP = 3;
    //ゲーム失敗の確認
    private bool GameOver = false;
    //ダメージ受けたときの確認
    private bool getDamage = false;
    
    //生命数をコントロールやすくなるように
    public new List<GameObject> Life = new List<GameObject>();
    GameObject Manager;
    
	// Use this for initialization
	void Start () {
        Manager = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update () {

       // Debug.Log(Life.Count);
        if (DeleteLife && LifeP > 0 && !getDamage)
        {
            if (!getDamage)
            {
                //生命数を1を消す
                LifeP -= 1;
                //ハート画像を消す
                Destroy(Life[LifeP]);
                DeleteLife = false;
                //少しいのダメージを受けない時間に入る
                getDamage = true;
            }
        }

        if (getDamage)
        {
            //パネル表示
            //　赤い色を設定
            Color _red = new Color(1, 0, 0, 1);
            //今の色を赤い色になる
            _getdamagePanel.GetComponent<Image>().color = Color.Lerp(_getdamagePanel.GetComponent<Image>().color, _red, 5f * Time.deltaTime);
            //色のアルファ値が0.8を超えた時
            if (_getdamagePanel.GetComponent<Image>().color.a > 0.8)
            {
                //ダメージを受けない時間に出る
                getDamage = false;
            }
        }

        if (!getDamage)
        {
            //元の色
            Color _normal = new Color(1, 0, 0, 0);
            //パネルのアルファ値を速く0に設定する
            _getdamagePanel.GetComponent<Image>().color = Color.Lerp(_getdamagePanel.GetComponent<Image>().color,_normal, 20f * Time.deltaTime);
        }

        if (!GameOver)
        {
            if (LifeP <= 0)
            {
                GameOver = true;
            }
            if (GameOver)
            {
                //スライムを出て来ないように
                _suraimuCreate.GameOver = true;
                //ゲーム失敗
                Manager.GetComponent<GameManage>().Over = true;
            }
        }
        return;
	}
}
