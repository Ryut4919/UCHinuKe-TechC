using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSuraimu : MonoBehaviour {

    [SerializeField]
    private PointCheck _pointNum;
    public Transform[] SuraimuPrefab;
    //倒しスライムの数
    public int[] targetNum;

    public bool GameOver = false;
    bool CanCreate=false;
    bool showBadEnding = true;
    //最初からスライムが出てくる用
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
            //-5,12 -4,4
            #region 数調整
            //数、Xの最小範囲(-5)、Xの最大範囲(12)、Yの最小範囲(4.5)、Yの最大範囲(4.5)、出る時間
            if (_pointNum.point <= targetNum[0])
            {
                create(1, -2.0f, 3.0f, 2.5f, -2.5f, 1.2f);
            }
            else if (_pointNum.point <= targetNum[1] && _pointNum.point > targetNum[0])
            {
                create(2, -3.5f, 7.0f, 4.0f, -4.4f, 1.0f);
            }
            else if (_pointNum.point <= targetNum[2] && _pointNum.point > targetNum[1])
            {
                create(2, -4.0f, 9.0f, 4.0f, -4.4f, 0.8f);
            }
            else if (_pointNum.point <= targetNum[3] && _pointNum.point > targetNum[2])
            {
                create(3, -4.5f, 10.5f, 4.0f, -4.4f, 0.7f);
            }
            else if (_pointNum.point > targetNum[3])
            {
                create(4, -5.0f, 12f, 4.5f, -5.0f, 0.6f);
            }
            #endregion
        }
        else
        {
            //失敗
            if (showBadEnding)
            {
                showBadEnding = false;
            }   
        }
    }
    IEnumerator CreateS()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(2.5f);
            CanCreate = true;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param 数="num"></param>
    /// <param Xの最小範囲="min_X"></param>
    /// <param Xの最大範囲="max_X"></param>
    /// <param Yの最小範囲="min_y"></param>
    /// <param Yの最大範囲="max_y"></param>
    /// <param 出る時間="time"></param>
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
