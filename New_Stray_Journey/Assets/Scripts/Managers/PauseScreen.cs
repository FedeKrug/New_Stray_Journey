using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseScreen : MonoBehaviour
{
    public static PauseScreen instance;
	[SerializeField] private GameObject _pauseImage;


    private bool _isPaused;

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

   
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
		{
			_isPaused = !_isPaused;
			if (_isPaused)
			{
				PauseGame();
			}
			else
			{
				ResumeGame();
			}
		}
	}

	

	public  void PauseGame()
	{
		Time.timeScale = 0;
		_pauseImage.SetActive(true);
	}

	public  void ResumeGame()
	{
		Time.timeScale = 1;
		_pauseImage.SetActive(false);
	}
}
