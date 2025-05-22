using Assets.MyFolder._01.Script._02.Object.Player;

namespace MyFolder._01.Script._02.Object.Player.State
{
    /// <summary>
    /// PlayerStateMachine class
    /// </summary>
    /// <remarks>
    /// This class is responsible for managing the player's state machine.
    /// </remarks>
    /// <author>Jin</author>
    /// <date>2023/10/12</date>
    /// <version>1.0</version>
    /// <see cref="IAgentState"/>
    public class AgentStateMachine
    {
        /********************���� ���� ����********************/

        PlayerController player;

        IAgentState currentState;


        /*********************������**************************/

        public AgentStateMachine(PlayerController player)
        {
            this.player = player;
        }

        /********************�ʱ�ȭ �Լ�**********************/

        private void Start()
        {

        }

        /********************������Ʈ �Լ�********************/

        private void Update()
        {
            currentState?.Update();
        }

        /********************Public �Լ�*********************/
        public void ChangeState<T>(out IAgentState oldState, out IAgentState newState) where T : IAgentState, new()
        {
            newState = new T();
            oldState = currentState;
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter(player);
        }

        public string GetCurrentState()
        {
            return currentState.GetName();
        }

        /********************Private �Լ�********************/


    }
}