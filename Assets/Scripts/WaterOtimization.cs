using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOtimization : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void onTriggerEnter2D(Collider2D c2D)
	{
		if(c2D.gameObject.tag == "Grass")
		{
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
	}

	void onCollisionEnter2D(Collider2D c2D)
	{
		if(c2D.gameObject.tag == "Water")
		{
			this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
