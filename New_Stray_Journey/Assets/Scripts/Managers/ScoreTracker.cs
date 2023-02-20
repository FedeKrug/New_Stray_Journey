using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
using Game.SO;
using UnityEngine.UI;
using TMPro;


public class ScoreTracker : MonoBehaviour
{
	public static ScoreTracker instance;

	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private PlayerMovement _playerRef;
	[SerializeField] private IntSO _scoreToSave;
	[SerializeField] public int score;


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
		EventManager.instance.saveScoreEvent.AddListener(SaveScoreHandler);
	}

	private void OnDisable()
	{
		EventManager.instance.scoreEvent.RemoveListener(UpdateScoreHandler);
		EventManager.instance.saveScoreEvent.RemoveListener(SaveScoreHandler);
	}
	public void SaveScoreHandler(int value, TextMeshProUGUI savedScoreUI)
	{

		_scoreToSave.value = score;
		value = _scoreToSave.value;

		savedScoreUI.text = value.ToString();
	}

	public void UpdateScoreHandler(string scoreText, TextMeshProUGUI scoreUI)
	{

	}
}
