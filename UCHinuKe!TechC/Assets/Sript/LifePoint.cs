using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour {
    public CreateSuraimu _suraimuCreate;
    public GameObject _getdamagePanel;
    public bool DeleteLife = false;
    private bool GameOver = false;
    private bool getDamage = false;
    private int LifeP = 3;
    public new List<GameObject> Life = new List<GameObject>();
    GameObject Manager;
    
	// Use this for initialization
	void Start () {
        Manager = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update () {

        if (DeleteLife && LifeP > 0 && !getDamage)
        {
            if (!getDamage)
            {
                LifeP -= 1;
                Destroy(Life[LifeP]);
                DeleteLife = false;
                getDamage = true;
            }
        }

        if (getDamage)
        {
            Color _red = new Color(1, 0, 0, 1);
            _getdamagePanel.GetComponent<Image>().color = Color.Lerp(_getdamagePanel.GetComponent<Image>().color, _red, 5f * Time.deltaTime);
            if (_getdamagePanel.GetComponent<Image>().color.a > 0.8)
            {
                getDamage = false;
            }
        }

        if (!getDamage)
        {
            Color _normal = new Color(1, 0, 0, 0);
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
                _suraimuCreate.GameOver = true;
                Manager.GetComponent<GameManage>().Over = true;
            }
        }
        return;
	}
}
