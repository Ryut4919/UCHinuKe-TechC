using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoint : MonoBehaviour {
    Suraimu _suraimu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (_suraimu.TakeLife)
        {
            Destroy(transform.GetChild(0));
            _suraimu.TakeLife = false;
        }
        else
            return;
	}
}
