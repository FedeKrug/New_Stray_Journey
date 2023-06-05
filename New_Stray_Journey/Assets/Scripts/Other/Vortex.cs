using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Vortex : MonoBehaviour
{
	[SerializeField] private string _nextScene;
	[SerializeField] private AudioSource _aSource;
	[SerializeField] private AudioClip _vortexSound;
	[SerializeField] private SpriteRenderer _playerFireSprite;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.GetComponentInChildren<SpriteRenderer>().enabled = false;
		collision.GetComponentInChildren<SpriteRenderer>().enabled = false;
		StartCoroutine(GoToNextLevel()) ;
	}
	IEnumerator GoToNextLevel()
	{
		yield return null;
		_aSource.PlayOneShot(_vortexSound);
		while (_aSource.isPlaying)
		{
			yield return null;
		}
		SceneLoader.instance.ChangeScene(_nextScene);
	}
}
