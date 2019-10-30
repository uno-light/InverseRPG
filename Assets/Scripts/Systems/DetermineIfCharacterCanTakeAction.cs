using ECSish;

namespace InverseRPG
{
    public class DetermineIfCharacterCanTakeAction : MonoBehaviourSystem
    {
        private void Update()
        {
            var battleTimeEntity = GetEntity<BattleTime>();
            if (battleTimeEntity == null) return;

            var time = battleTimeEntity.Item1.timeSinceStartOfBattle;

            foreach (var entity in GetEntities<AttackTime, CanTakeAction>())
            {
                var nextAttackTime = entity.Item1.nextAttackTime;
                var canTakeAction = entity.Item2;

                if (time >= nextAttackTime)
                    canTakeAction.canTakeActionNow = true;
                else
                    canTakeAction.canTakeActionNow = false;
            }
        }
    }
}