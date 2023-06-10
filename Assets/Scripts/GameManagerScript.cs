using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public static bool buildMode;
	public GameObject[] canvasTypes;
	BuildTest bTScript;
	// public Text[] itemsQuantity;

	void Start ()
	{
		bTScript = Camera.main.gameObject.GetComponent<BuildTest>();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			buildMode = !buildMode;
		}

		if(buildMode)
		{
			bTScript.BuildMode();
			Time.timeScale = 0;
			canvasTypes[1].gameObject.SetActive(true);
		}

		else
		{
			Time.timeScale = 1;
			canvasTypes[1].gameObject.SetActive(false);
		}

		InventoryQuantity();
	}

	void InventoryQuantity()
	{
		// itemsQuantity[0].text = PlayerScript.rockQuant.ToString();
		// itemsQuantity[1].text = PlayerScript.woodQuant.ToString();
		// itemsQuantity[2].text = PlayerScript.goldQuant.ToString();
		// itemsQuantity[3].text = PlayerScript.treeSeedQuant.ToString();
	}
}
