using System.Collections;

using UnityEngine;

public class FinalVortex : MonoBehaviour
{
	[SerializeField] private AudioSource _aSource;
	[SerializeField] private AudioClip _vortexFinish, _winScreenMusic;
	[SerializeField] private GameObject _winScreen;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.GetComponentInChildren<SpriteRenderer>().enabled = false;
		StartCoroutine(WinTheGame());
	}

	IEnumerator WinTheGame()
	{
		_aSource.PlayOneShot(_vortexFinish);
		
		while (_aSource.isPlaying)
		{
		yield return null;

		}
		_winScreen.SetActive(true);
		yield return null;
		_aSource.PlayOneShot(_winScreenMusic);
		
	}
}