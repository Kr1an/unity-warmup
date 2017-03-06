using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private bool isDead;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{



	}

	void FixedUpdate()
	{
		if (Input.GetMouseButtonDown(0) && !isDead)
		{
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(new Vector2(0f, 300f));

		}
			



	}

	void SetDead(bool value)
	{
		isDead = value;
		GameController.gameOver = isDead;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Collumn")
			SetDead(true);

	}
}
