using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlanter : MonoBehaviour {

	public float growTime;
	public float actualTime;
	public GameObject tree;


	void Start () 
	{
		growTime = 30;
	}
	
	void Update ()
	{
		Grow();
	}

	void Grow()
	{
		actualTime += Time.deltaTime;

		if(actualTime > growTime)
		{
			Instantiate(tree,this.gameObject.transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
