using System.Collections;
using System.Collections.Generic;

using Game.Player;

using UnityEngine;

public class Coin : MonoBehaviour, Collectable
{
	[SerializeField] private int _coinScore;
	[SerializeField] private ParticleSystem _particleCoinExplosion;
	[SerializeField] private AudioSource _aSource;
	[SerializeField] private AudioClip _coinClip;
	[SerializeField] private SpriteRenderer _spriteR, _miniMapSprite;
	[SerializeField] private Rigidbody2D _rb2d;
	[SerializeField] private bool _collected;
	public void Collect()
	{
		ScoreTracker.instance.IncreaseScore(_coinScore);
		StartCoroutine(CoinExplosion());
		_collected = true;
	}

	IEnumerator CoinExplosion()
	{
		_aSource.PlayOneShot(_coinClip);
		_spriteR.enabled = false;
		_miniMapSprite.enabled = false;
		_particleCoinExplosion.gameObject.SetActive(true);
		yield return null;
		this.GetComponent<Collider2D>().enabled = false;
		while (_aSource.isPlaying)
		{
			yield return null;

		}

		gameObject.SetActive(false);

	}
	
}
