using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Suraimu : MonoBehaviour {
    
    //通常の顔
    [SerializeField]
    private GameObject sumface;
    //死亡の顔
    [SerializeField]
    private GameObject deathface;
    //死亡時のパーティクルシステム
    public GameObject _Star;
    //生命数を取ったかの確認
    public bool TakeLife = false;
    public PointCheck gameOC;
    //死亡信号が来た時用
    public bool IsDeath=false;

    //効果音
    public AudioSource HitSound;
    //正しい効果音
    public AudioClip CurrentSound;
    //間違えた効果音
    public AudioClip WrongSound;
    //最終到着場所を設定
    Vector2[] targetPosition;
    //Game Managerを取る
    GameObject Target;
    //最終到着場所
    Vector2 finalPos;
   
    // Use this for initialization
    void Start () {
# region 最終到着点
        targetPosition = new Vector2[]
        {//最終到着点(x,y)(X_max=5.7,min=-5.5,y_max=4.5,mix=-4.5)
        new Vector2(3,-1.5f),
        new Vector2(-4, 5),
        new Vector2(-5,4),
        new Vector2(5,4),
        new Vector2(1,-4),
        new Vector2(5,-4.4f),
        };

        #endregion
        Target = GameObject.Find("GameManager");
        gameOC = GameObject.Find("CountPoint").GetComponent<PointCheck>();
        //ランダムで、スライムの出る場所を決める
        finalPos = targetPosition[Random.Range(0, targetPosition.Length)];
        //通常の顔を設定
        sumface = transform.GetChild(1).gameObject;
        //通常の顔を表示
        sumface.SetActive(true);
        //死の顔亡を設定
        deathface = transform.GetChild(0).gameObject;
        //死の顔亡を非表示
        deathface.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        #region 出ると最後方向
        if (!IsDeath)
        {
            //画像を大きくなる
            transform.localScale += new Vector3(1.0f, 1.0f, 0) * Time.deltaTime;
            //最終到着場所に移動
            transform.position = Vector2.Lerp(this.transform.position, finalPos, 0.3f * Time.deltaTime);
            //画像が3.5に超えた場合
            if (this.transform.localScale.x > 3.5f)
            {
                //生命数を取る
                TakeLife = true;
                //ハート画像を消す信号を出す
                Target.GetComponent<LifePoint>().DeleteLife = true;
            }
            //生命数を取ったか、ゲームー終了かそれどもゲームー失敗したか
            if (TakeLife ||/*game win*/gameOC.GameClear ||/*game lose*/ Target.GetComponent<GameManage>().Over)
            {
                //自分を消す
                Destroy(this.gameObject);
            }
        }
        #endregion
        //死亡信号を受けた場合
        if (IsDeath) 
        {
            //死亡のプロセスを始まり
            StartCoroutine("DeathPross",1f);
        }

    }

    IEnumerator DeathPross()
    {
        //顔の変換
        //通常の顔を非表示
        sumface.SetActive(false);
        //死亡の顔を表示する
        deathface.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        //素速くに画像を小さくなる
        iTween.ScaleTo(this.gameObject, new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(0.1f);
        //死亡のパーティクルシステムがプレイしてない場合
        if (!_Star.GetComponent<ParticleSystem>().isPlaying)
        {
            //死亡のパーティクルシステムがプレイしする
            _Star.GetComponent<ParticleSystem>().Play();
            //スライムの撃破数をプラス
            Target.GetComponent<GameManage>().Point += 1;
        }
        yield return new WaitForSeconds(0.2f);
        //自分削除
        Destroy(gameObject);
    }

    public void CSound()
    {   
        # region ボダンが正しい場合の音楽
            HitSound.clip = CurrentSound;
        if (HitSound.isPlaying)
        {
            HitSound.Stop();
            HitSound.pitch = 1;
        }

        if (!HitSound.isPlaying)
            {
                HitSound.pitch = 3;
                HitSound.volume = 0.6f;
                HitSound.Play();
            }
            #endregion
    }

    public void WSound()
    {
        #region ボダンが間違いました場合の音楽
        HitSound.clip = WrongSound;
        if (HitSound.isPlaying)
        {
            HitSound.Stop();
            HitSound.pitch = 1;
        }

        if (!HitSound.isPlaying)
        {
            HitSound.pitch = 1;
            HitSound.volume = 0.6f;
            HitSound.Play();
        }
        #endregion
    }
}
