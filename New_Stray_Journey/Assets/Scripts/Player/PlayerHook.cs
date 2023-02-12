using UnityEngine;


namespace Game.Player
{
	public class PlayerHook : MonoBehaviour
	{
		[SerializeField] private GameObject _hookOrigin, _hook;
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				EventManager.instance.playerHookEvent.Invoke(_hookOrigin, _hook);
			}
		}
	}
}



