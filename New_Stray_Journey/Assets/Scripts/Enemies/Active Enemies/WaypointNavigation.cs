using UnityEngine;
using System.Collections.Generic;


namespace Game.Enemies
{
	public class WaypointNavigation : MonoBehaviour
	{
		[SerializeField] private List<Transform> _points;
		[SerializeField] private int _currentPoint;
		[SerializeField] private PassiveEnemy _passiveEnemyRef;
		[SerializeField] private ActiveEnemy _activeEnemyRef;


		private void Update()
		{
			if (_currentPoint < _points.Count)
			{
				if (_passiveEnemyRef)
				{
					_passiveEnemyRef.transform.position = Vector3.Lerp(_passiveEnemyRef.transform.position,
					_points[_currentPoint].transform.position, 5);

				}
				if (_activeEnemyRef)
				{
					_activeEnemyRef.transform.position = Vector3.Lerp(_activeEnemyRef.transform.position,
					_points[_currentPoint].transform.position, _activeEnemyRef.MovementSpeed);
				}
			}
		}

	}
}
