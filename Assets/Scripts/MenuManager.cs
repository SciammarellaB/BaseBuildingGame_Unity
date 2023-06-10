using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject first,second;
	public bool startGame;
	public float startTime,currentTime;


	public void Start()
	{
		startGame = false;
		startTime = 10;
		currentTime = 0;
		first.gameObject.SetActive(true);
		second.gameObject.SetActive(false);
	}

	public void Update()
	{
		if(startGame)
		{
			currentTime += Time.deltaTime;
			first.gameObject.SetActive(false);
			second.gameObject.SetActive(true);
		}

		if(currentTime > startTime)
		{
			SceneManager.LoadScene(1);
		}
	}


	public void Actions(string type)
	{
		switch (type)
		{
		case "Play":
			startGame = true;			
			break;

		case "Exit":
			Application.Quit();
			break;
		}
	}
}
