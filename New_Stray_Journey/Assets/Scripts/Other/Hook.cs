using UnityEngine;
using System.Collections;
using Game.Player;
using Game.Enemies;


public class Hook : Bullet
{
	[SerializeField] private bool _onShoot, _objectGrabbed;
	[SerializeField] private PlayerHook p;

	private void OnEnable()
	{
		_onShoot = true;
	}

	private void OnDisable()
	{
		_onShoot = false;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Interactable>() != null || collision.GetComponent<ActiveEnemy>() != null || 
			collision.GetComponent<PassiveEnemy>() != null || collision.GetComponent<Collectable>() != null)
		{
			GrabEntity();
		}
	}

	IEnumerator GetOverHere(GameObject objectToGrab)
	{ 

		while (_onShoot)
		{
			yield return null;
			objectToGrab.transform.position = this.transform.position;
		}

		Debug.Log($"");
	}

	public void GrabEntity()
	{
		//var go  = 
		_objectGrabbed = true;
		//StartCoroutine(GetOverHere());
	}
}