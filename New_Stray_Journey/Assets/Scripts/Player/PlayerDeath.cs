using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Player
{
	public class PlayerDeath : MonoBehaviour
	{
		[SerializeField] private GameObject _playerRef;
		[SerializeField] private Animator _anim;
		[SerializeField] private string _deathAnim;
		[SerializeField] private float _timeToDie;

		public void Die()
		{
			StartCoroutine(Death());

		}
		IEnumerator Death()
		{
			_anim.Play(_deathAnim);
			yield return new WaitForSeconds(_timeToDie);
			_playerRef.SetActive(false);
		}
	}

}
