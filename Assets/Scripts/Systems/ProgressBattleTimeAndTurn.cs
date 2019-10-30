using System;
using ECSish;

namespace InverseRPG
{
    public class ProgressBattleTimeAndTurn : MonoBehaviourSystem
    {
        private void Update()
        {
            var battleTimeEntity = GetEntity<BattleTime>();
            if (battleTimeEntity == null) return;
            var time = battleTimeEntity.Item1.timeSinceStartOfBattle;

            if (ItIsSomeonesTurn(time))
            {
                if (ThereIsAnActionTaken())
                {
                    ProcessAction(time);
                    IncrementTurn();
                    ProgressTimeToNextCharactersTurn(battleTimeEntity.Item1);
                }
            }
            else
            {
                ProgressTimeToNextCharactersTurn(battleTimeEntity.Item1);
            }
        }

        private bool ItIsSomeonesTurn(float time)
        {
            foreach(var entity in GetEntities<AttackTime, CanTakeAction>())
                if (entity.Item1.nextAttackTime <= time)
                    return true;

            return false;
        }

        private bool ThereIsAnActionTaken()
        {
            return GetEntity<ActionTakenEvent>() != null;
        }

        private void ProcessAction(float time)
        {
            foreach(var entity in GetEntities<ActionTakenEvent, CanTakeAction, AttackTime, Speed>())
            {
                entity.Item2.canTakeActionNow = false;
                if (entity.Item4.speed > 0)
                    entity.Item3.nextAttackTime = time + 1f / entity.Item4.speed;
                else
                    entity.Item3.nextAttackTime = float.MaxValue;
            }
        }

        private void IncrementTurn()
        {
            foreach (var entity in GetEntities<Turn>())
                entity.Item1.turn++;
        }

        private void ProgressTimeToNextCharactersTurn(BattleTime battleTime)
        {
            var nextAttackTime = float.MaxValue;
            foreach (var entity in GetEntities<AttackTime, CanTakeAction>())
                if (entity.Item1.nextAttackTime < nextAttackTime)
                    nextAttackTime = entity.Item1.nextAttackTime;

            battleTime.timeSinceStartOfBattle = nextAttackTime;
        }
    }
}