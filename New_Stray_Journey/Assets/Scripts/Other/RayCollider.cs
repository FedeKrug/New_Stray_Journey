using UnityEngine;
using Game.Enemies;

public class RayCollider : MonoBehaviour 
{
	public bool onRayRange;
	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Interactable>() != null ||
			collision.GetComponent<Enemy>() != null || collision.GetComponent<Collectable>() != null)
		{
			onRayRange = true;

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
}
public class AttractionRayCollider : RayCollider
{

}
public class RepulsionRayCollider : RayCollider
{

}