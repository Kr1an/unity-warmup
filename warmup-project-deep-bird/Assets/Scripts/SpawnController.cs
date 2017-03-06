using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class SpawnController : MonoBehaviour
{


	public Transform collumnSpawner;
	public Transform collumnRemover;
	public GameObject collumnPrefab;
	private List<GameObject> collumns;
	private int collumnCount = 3;

	// Use this for initialization
	void Start () {
		collumns = new List<GameObject>();
		for (int i = 0; i < collumnCount; i++)
		{
			collumns.Add((GameObject)Instantiate(collumnPrefab, new Vector3(collumnSpawner.position.x + i*12, collumnSpawner.position.y), Quaternion.identity));
			collumns[i].SetActive(true);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (collumns.Count < collumnCount)
		{
			collumns.Add((GameObject)Instantiate(collumnPrefab, collumnSpawner.position, Quaternion.identity));
		}

		for (int i = 0; i < collumnCount; i++)
		{
			if (collumns[i].transform.position.x <= 0f)
			{
				GameController.score++;
			}
			if (collumns[i].transform.position.x <= collumnRemover.transform.position.x)
			{
				collumns[i].transform.position = collumnSpawner.position;
			}
			
		}



	}
}
