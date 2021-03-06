﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	private Int32 count;

	public Text countText;
	public Text winText;
	public float Speed;
	

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * Speed);


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12)
			winText.text = "You Win! this one";
	}
}
