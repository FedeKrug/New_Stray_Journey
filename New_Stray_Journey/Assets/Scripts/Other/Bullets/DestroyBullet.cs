﻿using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour
{
	[SerializeField] private AudioClip _explosionAudio;
	[SerializeField] private AudioSource _explosionASource;
	[SerializeField] private GameObject _bulletToDestroy, _explosion;
	[SerializeField, Range(0.5f, 5)] private float _explosionTime;
	[SerializeField] private Bullet _bulletRef;

	public IEnumerator DestroyBullets()
	{
		_bulletRef.speed = 0;

		
		yield return null;
		Instantiate(_explosion, this.gameObject.transform);
		_explosionASource.PlayOneShot(_explosionAudio);
		//yield return new WaitForSeconds(0.2f);
		_bulletToDestroy.SetActive(false);
		yield return new WaitForSeconds(_explosionTime);
		//yield return new WaitForSeconds(_explosionTime);
		Destroy(_bulletToDestroy);
		Debug.Log("BulletDestroyed");
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
		{
			StartCoroutine(DestroyBullets());
		}

	}
}