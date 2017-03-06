using UnityEngine;
using System.Collections;

public class CollumnController : MonoBehaviour
{

	private Rigidbody2D rb2d;
	private float maxVelocity = 4f;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		

	
	}

	void FixedUpdate()
	{
		rb2d.AddForce(new Vector2(-2, 0));
		if (Mathf.Abs(rb2d.velocity.x) > maxVelocity)
		{
			rb2d.velocity = new Vector2(-maxVelocity, 0);
		}
	}
}
