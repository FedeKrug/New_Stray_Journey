using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.SO
{
	[CreateAssetMenu(fileName ="new Float", menuName ="ScriptableObjects/Float")]
	public class FloatSO : ScriptableObject
	{
		public float value;
	}

	[CreateAssetMenu(fileName = "new Int", menuName = "ScriptableObjects/Int")]
	public class IntSO : ScriptableObject
	{
		public int value;
	}
}
