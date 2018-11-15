using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suraimu : MonoBehaviour {
    [SerializeField]
    private GameObject sumface;
    [SerializeField]
    private GameObject deathface;
    public bool TakeLife = false;
    public TimerControl gameOC;
    public bool IsDeath=false;

    public AudioSource HitSound;
    public AudioClip CurrentSound;
    public AudioClip WrongSound;
    
    Vector2[] targetPosition;
    GameObject Target;
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
        gameOC = GameObject.Find("Timer").GetComponent<TimerControl>();
        finalPos = targetPosition[Random.Range(0, targetPosition.Length)];
        sumface = transform.GetChild(1).gameObject;
        sumface.SetActive(true);
        deathface = transform.GetChild(0).gameObject;
        deathface.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        #region 出ると最後方向
        if (!IsDeath)
        {
            transform.localScale += new Vector3(1.0f, 1.0f, 0) * Time.deltaTime;
            transform.position = Vector2.Lerp(this.transform.position, finalPos, 0.3f * Time.deltaTime);
            if (this.transform.localScale.x > 3.5f)
            {
                TakeLife = true;
                Target.GetComponent<LifePoint>().DeleteLife = true;
            }
            if (TakeLife ||/*game win*/gameOC.gameClear ||/*game lose*/ Target.GetComponent<GameManage>().Over)
            {
                Destroy(this.gameObject);
            }
        }
        #endregion

        if (IsDeath) 
        {
            StartCoroutine("DeathPross",1f);
        }

    }

    IEnumerator DeathPross()
    {
        //顔の変換
        sumface.SetActive(false);
        deathface.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        //自分削除
        Destroy(gameObject);
    }

    public void CSound()
    {   
        # region ボダンが正しい場合
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
        #region ボダンが間違いました場合
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
