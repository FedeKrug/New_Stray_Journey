using UnityEngine;


namespace Game.SO
{
	[CreateAssetMenu(fileName = "new Int", menuName = "ScriptableObjects/Int")]
	public class IntSO : ScriptableObject
	{
		public int value;
	}
}
