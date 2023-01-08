using UnityEngine;
using System.Collections.Generic;


namespace Game.Player
{
	public class PlayerShooting : MonoBehaviour
	{
		[SerializeField] private List<GameObject> _bulletGens;
		[SerializeField] private GameObject _bullet;
		[SerializeField] private float _maxTimeRate;
		[SerializeField] private ShootType _shootType;

		private float _timeRate;

		void Update()
		{
			_timeRate -= Time.deltaTime;

			#region ShootTypes with Enums
			switch (_shootType)
			{
				case ShootType.ArrowType:

					if (Input.GetKeyUp(KeyCode.C))
					{
						_timeRate = _maxTimeRate;
						EventManager.instance.normalShootingEvent.Invoke(_bulletGens, _bullet);
					}
					break;

				case ShootType.Automatic:
					if (Input.GetKey(KeyCode.C))
					{
						if (_timeRate <= 0)
						{
							_timeRate = _maxTimeRate;

							EventManager.instance.normalShootingEvent.Invoke(_bulletGens, _bullet);
							Debug.Log("Shooting");
						}
					}
					break;

				case ShootType.Manual:

					if (Input.GetKeyDown(KeyCode.C))
					{
						_timeRate = _maxTimeRate;
						EventManager.instance.normalShootingEvent.Invoke(_bulletGens, _bullet);


					}
					break;
				case ShootType.Alternative:
					if (Input.GetKey(KeyCode.C))
					{

					}
						break;
			}
			#endregion


		}
	}
}
