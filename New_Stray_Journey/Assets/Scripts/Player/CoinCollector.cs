using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
	[SerializeField, Range(0,20)] private float _collectorForce;
	private void OnTriggerStay2D(Collider2D collision)
	{
		Collect(collision);
	}
	private void Collect(Collider2D collision)
	{
		if (collision.GetComponent<Collectable>() != null)
		{
			var dir = transform.position - collision.transform.position;
			var dirScale = Vector2.Scale(dir.normalized, gameObject.transform.localScale);
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dirScale * _collectorForce, ForceMode2D.Force);
		}
	}
}
