using UnityEngine;
using System.Collections;
using Game.Player;
using Game.Enemies;


public class Hook : Bullet
{
	public bool objectGrabbed;
	public bool onLimit;
	public bool onShoot;
	
	[SerializeField, Range(0, 100)] private float _hookGrabForce;



	private void OnEnable()
	{
		onShoot = true;
	}

	private void OnDisable()
	{
		onShoot = false;
		Debug.Log("Hook Disabled");
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Interactable>() != null || collision.GetComponent<ActiveEnemy>() != null ||
			collision.GetComponent<PassiveEnemy>() != null || collision.GetComponent<Collectable>() != null)
		{
			GrabEntity(collision.gameObject);
		}
		if (collision.CompareTag("Player"))
		{
			Debug.Log("Player Touched wit");
			gameObject.SetActive(false);
		}
	}

	IEnumerator GetOverHere(GameObject objectToGrab)
	{

		while (!objectGrabbed || !onLimit)
		{
			yield return null;

		}
		if (objectGrabbed || onLimit)
		{
			//StartCoroutine(BringHookToPlayer());

		}
		Debug.Log($"agarre un nuevo Objeto o personaje");
	}

	

	public void GrabEntity(GameObject objToGrab)
	{
		Debug.Log($"Agarro objeto");
		objectGrabbed = true;
		StartCoroutine(GetOverHere(objToGrab));
	}


}