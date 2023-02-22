namespace Game.Enemies
{
	public class SpecialAttackState : State
	{
		public NormalState normalState;
		public override State RunCurrentState()
		{
			if (!normalState.enemyRef.specialReady)
			{
				return normalState;
			}
			normalState.enemyRef.SpecialAttack();
			return this;
		}
	}
}
