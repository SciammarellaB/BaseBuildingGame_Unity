using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public static int rockQuant,woodQuant,ironQuant,goldQuant,treeSeedQuant;

	public float speed, x, y;
	public Rigidbody2D playerRb2d;
	Animator anim;

	void Start () 
	{
		playerRb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = transform.GetComponentInChildren<Animator>();
	}
	
	void Update () 
	{
		Move();
	}

	void Move()
	{
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		if(x != 0 || y!=0)
		{
			anim.SetBool("Idle",false);
			anim.SetBool("Walk",true);
		}

		else
		{
			anim.SetBool("Idle",true);
			anim.SetBool("Walk",false);
		}

		if(x > 0)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector2(2,2);
		}

		if(x < 0)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector2(-2,2);
		}

		this.gameObject.transform.Translate(new Vector2(x * speed * Time.deltaTime,y * speed * Time.deltaTime));
	}
}
