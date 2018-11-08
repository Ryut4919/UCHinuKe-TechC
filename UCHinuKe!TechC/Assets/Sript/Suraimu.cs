using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suraimu : MonoBehaviour {
    public bool TakeLife = false;
    public TimerControl gameOC;
    //private new List<Vector2> targetPosition = new List<Vector2>();
    Vector2 targetPosition;
    //Transform[] targetPosition;
    GameObject Target;

   
	// Use this for initialization
	void Start () {
        Target = GameObject.Find("GameManager");
        gameOC = GameObject.Find("Timer").GetComponent<TimerControl>();
        //targetPosition[0] = new Vector2(Random.Range(0,), Random.Range(0, 3));
        targetPosition= new Vector2(Random.Range(-1, 4), Random.Range(-1, 4));
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.localScale +=new Vector3(0.5f,0.5f,0)*Time.deltaTime;
        transform.position = Vector2.Lerp(this.transform.position, targetPosition, 0.15f * Time.deltaTime);
        if (this.transform.localScale.x > 3.5f)
        {
            TakeLife = true;
            Target.GetComponent<LifePoint>().DeleteLife = true;

        }
        if (TakeLife)
        {
            Destroy(this.gameObject);
        }

        if (/*game win*/gameOC.gameClear ||/*game lose*/ Target.GetComponent<GameManage>().Over)
        {
            Destroy(gameObject);
        }
       
	}
}
