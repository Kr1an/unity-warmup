using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static GameController instance;
	public Text gameOverText;
	public Text scoreText;
	public static bool gameOver = false;
	public static int score = 0;
	private Animator anim;
	public GameObject mainCamera;

	void Awake()
	{
		
		Initialize();
	}

	void Initialize()
	{
		score = 0;
		gameOver = false;
		gameOverText.gameObject.SetActive(false);
	}

	void Start()
	{
		anim = mainCamera.GetComponent<Animator>();
	}
	string GetScore()
	{
		return "Score: " + score;
	}
	
	void Update () {
		if (gameOver)
		{
			gameOverText.gameObject.SetActive(true);
			if (Input.GetMouseButtonDown(1))
			{
				SceneManager.LoadScene("MainScene");
				anim.SetTrigger("Alive");
			}
			anim.SetTrigger("Dead");

		}
		else
		{
			scoreText.text = GetScore();
		}

	}
}
