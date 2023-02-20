using UnityEngine;
using Game.Enemies;

public abstract class LasserRay : MonoBehaviour
{
	protected RaycastHit2D hit;
	[SerializeField] protected LineRenderer lasserLine;
	[SerializeField] protected Transform lasserTransform;
	[SerializeField, Range(0, 100)] protected float rayDistance;
	[SerializeField] protected BoxCollider2D rayCollider2D;
	[SerializeField] protected float rayWidth;
	[SerializeField] protected RayCollider rayCollider;

	private void Update()
	{
		CreateLasserRay();
		if (rayCollider.onRayRange)
		{
			Debug.Log("Ray has choked with an object");

		}
		else
		{
			
		}
	}

	protected void CreateLasserRay()
	{

		var newInitialPos = new Vector3(0, 0, 0);
		var newFinalPos = new Vector3(0, 0, rayDistance);
		lasserLine.SetPosition(0, newInitialPos);
		lasserLine.SetPosition(1, newFinalPos);
		rayCollider2D.size = new Vector2(rayWidth, rayDistance);
		rayCollider2D.offset = new Vector2(0, rayDistance / 2);
		lasserLine.startWidth = rayWidth;
		lasserLine.endWidth = rayWidth;

	}

	protected abstract void InteractWithEntities(Collider2D collision);

}
