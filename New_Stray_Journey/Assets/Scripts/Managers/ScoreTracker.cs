using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
using UnityEngine.UI;
using TMPro;


public class ScoreTracker : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private PlayerMovement _playerRef;
	[SerializeField] private int _score;
	void Awake()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Collectable>()!=null)
		{

		}
	}

	void Update()
	{

	}

	public void IncreaseScore()
	{
		EventManager.instance.scoreEvent.Invoke(_score.ToString(), _scoreText);
	}


}


public interface Collectable
{
	public void Collect();
}

public interface Interactable
{
	public void Interact();
}

public interface Destroyable
{
	public void Destroy();
}