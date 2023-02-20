using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Coin : MonoBehaviour, Collectable
{
	[SerializeField] private int _coinScore;
	[SerializeField] private ParticleSystem _particleCoinExplosion;
	[SerializeField] private AudioSource _aSource;
	[SerializeField] private AudioClip _coinClip;
	[SerializeField] private SpriteRenderer _spriteR;
	[SerializeField] private Rigidbody2D _rb2d;
	public void Collect()
	{
		ScoreTracker.instance.score += _coinScore;
		StartCoroutine(CoinExplosion());
	}

	IEnumerator CoinExplosion()
	{
		_aSource.PlayOneShot(_coinClip);
		_spriteR.enabled = false;
		_particleCoinExplosion.gameObject.SetActive(true);
		while (_aSource.isPlaying || _particleCoinExplosion.isPlaying)
		{
			yield return null;

		}
		
		gameObject.SetActive(false);

	}

}
