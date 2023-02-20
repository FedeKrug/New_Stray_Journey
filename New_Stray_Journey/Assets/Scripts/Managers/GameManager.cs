using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.SO;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	[SerializeField] private FloatSO _playerLife;
	[SerializeField] private IntSO _scoreToSave;

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
		
	
	}
	private void OnDisable()
	{
		
		
	}

	

	
}
