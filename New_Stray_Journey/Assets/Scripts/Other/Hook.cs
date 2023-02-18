using UnityEngine;
using System.Collections;
using Game.Player;
using Game.Enemies;


public class Hook : MonoBehaviour //Think about a pull ray & a push ray
{
	public bool objectGrabbed;
	public bool onLimit;
	public bool onShoot;

	[SerializeField, Range(0, 1000)] private float _hookGrabForce;
	[SerializeField, Range(0, 10)] private float _hookLimitTime, _hookMaxLimitTime;


	private void OnEnable()
	{
		onShoot = true;
		onLimit = false;
	}

	private void OnDisable()
	{
		onShoot = false;
		Debug.Log("Hook Disabled");
	}


	private void Update()
	{
		_hookLimitTime -= Time.deltaTime;
		if (_hookLimitTime <=0)
		{
			onLimit = true;
		}
		if (onLimit && !objectGrabbed)
		{
			Destroy(gameObject);

		}
		else
		{
			return;
		}
	}
	private void OnDestroy()
	{
		Debug.Log("Hook Destroyed");
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
