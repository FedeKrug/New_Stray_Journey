using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

	private void OnEnable()
	{
		EventManager.instance.enemyShootingEvent.AddListener(HandleEnemyShooting);
	}

	private void OnDisable()
	{
		EventManager.instance.enemyShootingEvent.RemoveListener(HandleEnemyShooting);

	}

	public void HandleEnemyShooting(List<GameObject> bulletGenerators, GameObject bullet)
	{
		for (int i = 0; i < bulletGenerators.Count; i++)
		{
			if (bullet)
			{
				GameObject _bullet = Instantiate(bullet, bulletGenerators[i].transform.position, bulletGenerators[i].transform.rotation);
				Debug.Log("Disparo Enemigo");

			}
		}
	}
}
