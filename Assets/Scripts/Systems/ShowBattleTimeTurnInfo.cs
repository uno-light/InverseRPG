using ECSish;

namespace InverseRPG
{
    public class ShowBattleTimeTurnInfo : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach(var entity in GetEntities<BattleTimeTurnInfoUI, UIText>())
            {
                var ui = entity.Item2.text;
                ui.text = "";

                var battleTime = GetEntity<BattleTime>();
                if (battleTime != null)
                    ui.text += $"Battle Time: {battleTime.Item1.timeSinceStartOfBattle.ToString("0.000")}\n";

                var turn = GetEntity<Turn>();
                if (turn != null)
                    ui.text += $"Turn: {turn.Item1.turn}\n";
            }
        }
    }
}