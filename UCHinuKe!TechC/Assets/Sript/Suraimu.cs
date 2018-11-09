using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suraimu : MonoBehaviour {
    [SerializeField]
    private ParticleSystem _bingo;
    public bool TakeLife = false;
    public TimerControl gameOC;
    public bool IsDeath=false;
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
        
    }
	
	// Update is called once per frame
	void Update () {

        #region 出ると最後方向
        transform.localScale +=new Vector3(1.0f,1.0f,0)*Time.deltaTime;
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
        #endregion

        if (IsDeath)
        {
            if (!_bingo.isPlaying)
            {
                _bingo.Play();
                Destroy(this.gameObject);
            }
           
            
        }
        //if (/*game win*/gameOC.gameClear ||/*game lose*/ Target.GetComponent<GameManage>().Over)
        //{
        //    Destroy(gameObject);
        //}

    }
}
