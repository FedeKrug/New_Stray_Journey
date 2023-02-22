namespace Game.Enemies
{
	public class NormalState : State
	{
		public Enemy enemyRef;
		public SpecialAttackState specialAttackState;
		public override State RunCurrentState()
		{
			if (enemyRef.specialReady)
			{
				return specialAttackState;
			}
			else
			{
				return this;

			}
		}
	}
}
