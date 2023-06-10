using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	GameObject player;

	int life;

	string objectTag;

	float resetTime;

	AudioSource aS;

	public SpriteRenderer spRender;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		aS = gameObject.GetComponent<AudioSource>();

		objectTag = this.gameObject.tag;

		switch (objectTag)
		{
		case "Rock":
			life = 10;
			break;
		case "Tree":
			life = 15;
			break;
		case "Iron":
			life = 20;
			break;
		case "Gold":
			life = 25;
			break;
		}

	}
	
	void Update () 
	{
		if(life == 0)
		{
			switch (objectTag)
			{
			case "Rock":
				PlayerScript.rockQuant += Random.Range(3,6);
				break;
			case "Tree":
				PlayerScript.woodQuant += Random.Range(2,6);
				PlayerScript.treeSeedQuant += Random.Range(0,2);
				break;
			case "Iron":
				PlayerScript.ironQuant += Random.Range(1,4);
				break;
			case "Gold":
				PlayerScript.goldQuant += Random.Range(1,4);
				break;
			}

			Destroy(this.gameObject);

		}

		resetTime += Time.deltaTime;

		if(resetTime > 0.05f)
		{
			spRender.color = Color.white;
			resetTime = 0;
		}
	}

	void OnMouseDown()
	{
		if(Vector3.Distance(this.gameObject.transform.position,player.transform.position) <= 4)
		{
			life --;
			spRender.color = Color.red;
			aS.Play();
		}
	}
}
