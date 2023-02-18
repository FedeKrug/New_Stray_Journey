using UnityEngine;
using System.Collections;
using Game.Player;
using Game.Enemies;

public class Bullet : MonoBehaviour
{
	public float damage;
	[Range(-250, 250f)] public float speed;
	[SerializeField, Tooltip("Change damage " +
	"with a boost later"), Range(0, 25f)]
	private float damageModifier;
	[Header("Destroying Bullets: ")]
	[SerializeField, Range(0, 15f)] private float _maxTimeToDestroy;
	[SerializeField] public Rigidbody2D rb2d;
	[SerializeField] private Animator _anim;
	[SerializeField] private AudioSource _aSource;

	private void OnEnable()
	{
		rb2d.velocity = Vector2.up * speed;
	}

	private void Update()
	{

		Destroy(gameObject, _maxTimeToDestroy);
	}

	private void FixedUpdate()
	{
		rb2d.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerManager.instance.TakeDamage(damage);
		}
		if (collision.CompareTag("Enemy"))
		{
			collision.GetComponent<EnemyHealth>().TakeDamage(damage);
		}
	}
}
