using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSuraimu : MonoBehaviour {
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
            if (GameObject.FindGameObjectsWithTag("Red").Length + GameObject.FindGameObjectsWithTag("Yellow").Length +
        GameObject.FindGameObjectsWithTag("Blue").Length + GameObject.FindGameObjectsWithTag("Green").Length < 2)
            {
                Instantiate(SuraimuPrefab[Random.Range(0, 4)], new Vector3(Random.Range(9.0f, -4.0f), Random.Range(3.5f, -3.5f), 0), Quaternion.identity);
                new WaitForSeconds(1.50f);
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
}
