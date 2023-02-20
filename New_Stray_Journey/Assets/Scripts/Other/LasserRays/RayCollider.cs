using UnityEngine;
using Game.Enemies;

public class RayCollider : MonoBehaviour 
{
	public bool onRayRange;
	[SerializeField] private LasserRay _lasserRef;
	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Interactable>() != null ||
			collision.GetComponent<Enemy>() != null || collision.GetComponent<Collectable>() != null)
		{
			onRayRange = true;
			_lasserRef.InteractWithEntities(collision);
		}
	}
	protected virtual void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<Interactable>() != null ||
			collision.GetComponent<Enemy>() != null || collision.GetComponent<Collectable>() != null)
		{
			onRayRange = false;

		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Interactable>() != null ||
			collision.gameObject.GetComponent<Enemy>() != null || collision.gameObject.GetComponent<Collectable>() != null)
		{
			onRayRange = true;
			_lasserRef.InteractWithEntities(collision.collider);
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Interactable>() != null ||
			collision.gameObject.GetComponent<Enemy>() != null || collision.gameObject.GetComponent<Collectable>() != null)
		{
			onRayRange = false;
		}
	}
}
