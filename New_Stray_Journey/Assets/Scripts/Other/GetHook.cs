using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHook : MonoBehaviour
{
	[SerializeField] private Hook _hookRef;
	[SerializeField] private Transform _playerPos;

	private void Update()
	{
		if (_hookRef.onLimit|| _hookRef.objectGrabbed)
		{
			StartCoroutine(BringHookToPlayer());
		}
	}
	public IEnumerator BringHookToPlayer()
	{

		while (_hookRef.onShoot)
		{

			yield return null;
			_hookRef.rb2d.MovePosition(new Vector2(_playerPos.position.x, _playerPos.position.y));
			
		}
	}

}
