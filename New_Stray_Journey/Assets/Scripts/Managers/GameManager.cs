using UnityEngine;
using TMPro;
using Game.SO;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	[SerializeField] private FloatSO _playerLife;
	[SerializeField] private TextMeshProUGUI _scoreText;

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
