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
		[SerializeField] private GameObject _loseScreen;
		public void Die()
		{
			StartCoroutine(Death());

		}
		IEnumerator Death()
		{
			_anim.Play(_deathAnim);
			_playerRef.GetComponentInChildren<SpriteRenderer>().enabled = false;
			_playerRef.layer = 0;
			yield return new WaitForSeconds(_timeToDie);
			Time.timeScale = 0;
			
			_playerRef.SetActive(false);
			_loseScreen.SetActive(true);
		}
	}

}
