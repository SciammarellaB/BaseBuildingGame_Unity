using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTest : MonoBehaviour {

	public GameObject grass,water,treePlanter,table;

	public LayerMask lm;
	public RaycastHit2D hit;
	public GameObject newCollision, lastCollision, oldCollision;
	float timeUpdate,tileDistance;

	void Start () 
	{
		hit = new RaycastHit2D();
		tileDistance = 2;
	}

	public void BuildMode()
	{
		Move();

		timeUpdate += Time.deltaTime;
		Ray2D ray2D = new Ray2D(this.transform.position,Vector3.forward);
		hit = Physics2D.Raycast(this.transform.position,Vector3.forward,5.0f,lm);

		newCollision = hit.collider.gameObject;

		newCollision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

		if(newCollision != lastCollision)
		{
			lastCollision = newCollision;
		}
	}

	void Move()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			this.gameObject.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + tileDistance,this.transform.position.z);
			oldCollision = lastCollision;
			oldCollision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			this.gameObject.transform.position = new Vector3(this.transform.position.x,this.transform.position.y - tileDistance,this.transform.position.z);
			oldCollision = lastCollision;
			oldCollision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			this.gameObject.transform.position = new Vector3(this.transform.position.x - tileDistance,this.transform.position.y,this.transform.position.z);
			oldCollision = lastCollision;
			oldCollision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			this.gameObject.transform.position = new Vector3(this.transform.position.x + tileDistance,this.transform.position.y ,this.transform.position.z);
			oldCollision = lastCollision;
			oldCollision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}

	public void PlaceBlock(string blockType)
	{
		switch (blockType)
		{
			case "Grass":
			if(hit.collider.gameObject.tag == "Water")
			{
				Destroy(hit.collider.gameObject);
				Instantiate(grass,hit.collider.gameObject.transform.position,Quaternion.identity);
			}
			break;
		}

	}

	public void PlaceBuild(string craftType)
	{
		
	}

	public void PlaceCraft(string craftType)
	{
		switch (craftType)
		{
		case "TreePlanter":
			if(PlayerScript.treeSeedQuant >=1)
			{
				if(hit.collider.gameObject.tag == "Grass")
				{				
					Instantiate(treePlanter,hit.collider.gameObject.transform.position,Quaternion.identity);
					PlayerScript.treeSeedQuant --;
				}
			}
			break;
		case "Table":
			if(PlayerScript.woodQuant >=4)
			{
				if(hit.collider.gameObject.tag == "Grass")
				{				
					Instantiate(table,hit.collider.gameObject.transform.position,Quaternion.identity);
					PlayerScript.woodQuant -= 4;
				}
			}
			break;
		}
	}


}
