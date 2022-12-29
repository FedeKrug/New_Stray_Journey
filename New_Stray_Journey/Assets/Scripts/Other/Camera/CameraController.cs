using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Camera
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Transform _player;
		[SerializeField, Range(0, 5)] private float dampTime;

		private Vector3 _cameraPos;
		private Vector3 velocity = Vector3.zero;

		private void LateUpdate()
		{
			_cameraPos = new Vector3(_player.position.x, _player.position.y, -10);
			transform.position = Vector3.SmoothDamp(gameObject.transform.position, _cameraPos, ref velocity, dampTime);
		}
	}
}
