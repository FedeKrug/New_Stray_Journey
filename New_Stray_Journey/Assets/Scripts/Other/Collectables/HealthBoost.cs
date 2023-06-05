using Game.Player;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour, Collectable
{
    [SerializeField] private float _healthPoints;
	[SerializeField] private SpriteRenderer _spriteR, _miniMapSprite;
	[SerializeField] private ParticleSystem _particleExplosion;
	[SerializeField] private AudioSource _aSource;
	[SerializeField] private AudioClip _healthClip;
	public void Collect()
	{
        PlayerManager.instance.IncreaseHealth(_healthPoints);
		StartCoroutine(HealthObjectExplosion());
	}

	IEnumerator HealthObjectExplosion()
	{
		_aSource.PlayOneShot(_healthClip);
		_spriteR.enabled = false;
		_miniMapSprite.enabled = false;
		_particleExplosion.gameObject.SetActive(true);
		yield return null;
		this.GetComponent<Collider2D>().enabled = false;
		while (_aSource.isPlaying)
		{
			yield return null;

		}
		gameObject.SetActive(false);

	}

}
