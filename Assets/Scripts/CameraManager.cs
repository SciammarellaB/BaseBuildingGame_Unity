using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public GameObject cameraLook,player;
	public float x,y;
	float cameraSizeView;

	void Start () 
	{
		cameraSizeView = 10;
	}
	
	void Update () 
	{
		if(!GameManagerScript.buildMode)
		{
			Look();
		}

		cameraSizeView -= Input.GetAxis("Mouse ScrollWheel");

		gameObject.GetComponent<Camera>().orthographicSize = cameraSizeView;
	}

	void Look()
	{
		x = player.transform.position.x;
		y = player.transform.position.y;

		this.gameObject.transform.position = new Vector3(x,y,this.transform.position.z);
	}
}
