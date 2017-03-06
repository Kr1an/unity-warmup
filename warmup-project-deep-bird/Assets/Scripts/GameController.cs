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
			}
		}
		else
		{
			scoreText.text = GetScore();
		}

	}
}
