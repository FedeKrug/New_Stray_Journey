using Game.SO;

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
	public static SceneLoader instance;
	[SerializeField] private FloatSO _playerHealth;
	void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void ExitGame()
	{
		Application.Quit();
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#endif
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		_playerHealth.value = 1000;
		PauseScreen.instance.ResumeGame();
	}
}
