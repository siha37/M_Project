
namespace Assets.MyFolder._01.Script._02.Object.Player.Module
{
    public interface IAgentTickableModule : IAgentModule
    {
        public void Update();
        public void FixedUpdate();
        public void LateUpdate();
    }
}
