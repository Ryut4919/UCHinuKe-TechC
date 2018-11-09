using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSuraimu : MonoBehaviour {
    [SerializeField]
    private TimerControl _timer;
    public Transform[] SuraimuPrefab;

    public bool GameOver = false;
    bool CanCreate=false;
    bool showBadEnding = true;
    int i;

	// Use this for initialization
	void Start () {
        StartCoroutine("CreateS");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameOver)
        {
            //数、Xの最小範囲(-3)、Xの最大範囲(9.5)、Yの最小範囲(4.5)、Yの最大範囲(4.5)、出る時間

            if (_timer.timer >= 40)
            {
                create(2, -2.0f, 3.0f, 2.5f, -2.5f, 1.0f);
            }
            else if (_timer.timer >= 20.0f && _timer.timer < 40.0f)
            {
                create(3, -2.5f, 7.0f, 4.0f, -4.4f, 0.8f);
            }
            else if (_timer.timer < 20.0f)
            {
                create(4, -3.0f, 9.5f, 4.5f, -5.0f, 0.5f);
            }
        }
        else
        {
            //失敗
            if (showBadEnding)
            {
                Debug.Log("Bye");
                showBadEnding = false;
            }   
        }
    }
    IEnumerator CreateS()
    {
        for (int i = 0; i < 4; i++)
        {
            //Instantiate(SuraimuPrefab[Random.Range(0,3)], new Vector3(Random.Range(10.0f,-5.0f),Random.Range(4.0f,-4.0f), 0), Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
            CanCreate = true;
        }
    }
    //数、Xの最小範囲、Xの最大範囲、Yの最小範囲、Yの最大範囲、出る時間
    private void create(int num, float min_X, float max_X, float min_y, float max_y, float time)
    {
        if (GameObject.FindGameObjectsWithTag("Red").Length + GameObject.FindGameObjectsWithTag("Yellow").Length +
       GameObject.FindGameObjectsWithTag("Blue").Length + GameObject.FindGameObjectsWithTag("Green").Length < num)
        {
            Instantiate(SuraimuPrefab[Random.Range(0, 4)], new Vector3(Random.Range(min_X, max_X), Random.Range(min_y, max_y), 0), Quaternion.identity);
            new WaitForSeconds(time);
        }
    }

}
