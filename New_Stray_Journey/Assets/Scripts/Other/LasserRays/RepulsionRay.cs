using UnityEngine;

public class RepulsionRay : LasserRay
{
	[SerializeField, Range(-200, 20)] private float _rayForce;
	public override void InteractWithEntities(Collider2D collision)
	{
		var dir = transform.position - collision.transform.position;
		var dirScale = Vector2.Scale(dir.normalized, gameObject.transform.localScale);
		collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dirScale * _rayForce, ForceMode2D.Impulse);
	}
}