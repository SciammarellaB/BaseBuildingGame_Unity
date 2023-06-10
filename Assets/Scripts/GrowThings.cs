using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowThings : MonoBehaviour {

	//Used to grow elements on Grass tiles

	public float growTime, actualTime;
	public GameObject[] grassTiles;
	public GameObject[] itemToCreate;

	void Start () 
	{
		growTime = 5;
	}
	
	void Update ()
	{
		actualTime += Time.deltaTime;

		if(actualTime >= growTime)
		{
			grassTiles = GameObject.FindGameObjectsWithTag("Grass");

			Instantiate(itemToCreate[Random.Range(0,itemToCreate.Length)],grassTiles[Random.Range(0,grassTiles.Length)].transform.position,Quaternion.identity);

			actualTime = 0;
		}
	}
}
