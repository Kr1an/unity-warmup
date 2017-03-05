﻿using System;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Xml.Schema;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public float Speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;

	private float nextFire;
	

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation); 
		}
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		rb.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * Speed ;

		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x*tilt*-1);
	}
}