using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
    void Awake()
    {
        if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
    }


	private void OnEnable()
	{
		EventManager.instance.scoreEvent.AddListener(UpdateScoreHandler);
	}
	private void OnDisable()
	{
		EventManager.instance.scoreEvent.RemoveListener(UpdateScoreHandler);
		
	}

	public void UpdateScoreHandler(string scoreText, TextMeshProUGUI scoreUI)
	{
		Debug.Log("Score is being updated");
	}
}
