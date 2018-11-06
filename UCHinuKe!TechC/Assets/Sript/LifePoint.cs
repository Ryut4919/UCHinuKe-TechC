using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoint : MonoBehaviour {
    public CreateSuraimu _suraimuCreate;
    public bool DeleteLife = false;
    private bool GameOver = false;
    private int LifeP = 3;
    public new List<GameObject> Life = new List<GameObject>();
    GameObject Manager;
    
	// Use this for initialization
	void Start () {
        Manager = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
        
        if (DeleteLife && LifeP > 0)
        {
            LifeP -= 1;
            //Life.RemoveAt(0);
            Destroy(Life[LifeP]);
            DeleteLife = false;
        }

        if (!GameOver)
        {
            if (LifeP <= 0)
            {
                GameOver = true;
            }
            if (GameOver)
            {
                _suraimuCreate.GameOver = true;
                //_suraimu.GameOver = true;
                Manager.GetComponent<GameManage>().Over = true;
                Debug.Log("GameOver");
            }
        }

        
        return;
	}
}
