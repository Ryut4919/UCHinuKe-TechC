using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suraimu : MonoBehaviour {
    public bool TakeLife = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale +=new Vector3(0.5f,0.5f,0)*Time.deltaTime;
        if (this.transform.localScale.x > 3.5f)
        {
            TakeLife = true;
        }
	}
}
