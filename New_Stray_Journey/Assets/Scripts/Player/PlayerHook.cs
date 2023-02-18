using UnityEngine;
using System.Collections;

namespace Game.Player
{
	public class PlayerHook : MonoBehaviour
	{
		[SerializeField] private GameObject _hookOrigin, _hook;
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E)&& !_hook.GetComponentInChildren<Hook>().onShoot)
			{
				
				EventManager.instance.playerHookEvent.Invoke(_hookOrigin, _hook);
			}
		}

		public IEnumerator MarkHookLimit()
		{
			yield return null;
		}
	}
}



