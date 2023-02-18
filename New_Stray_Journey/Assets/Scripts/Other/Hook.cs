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
		if (collision.GetComponent<Interactable>() != null || 
			collision.GetComponent<Enemy>() != null || collision.GetComponent<Collectable>() != null)
		{
			GrabEntity(collision.gameObject);

		}
		else
		{
			//onLimit = true;
		}

		if (collision.CompareTag("Player") && (onLimit || objectGrabbed))
		{
			Debug.Log("Player Touched with Hook");
			gameObject.SetActive(false);
		}
	}




	public void GrabEntity(GameObject objToGrab)
	{
		var dir = FindObjectOfType<PlayerMovement>().transform.position - objToGrab.transform.position;
		var dirScale = Vector2.Scale(dir.normalized, gameObject.transform.localScale);
		objToGrab.gameObject.GetComponent<Rigidbody2D>().AddForce(dirScale * _hookGrabForce, ForceMode2D.Force);
		objectGrabbed = true;
	}


}