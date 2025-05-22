using System.Numerics;

namespace Assets.MyFolder._02._Object._04._InputProvider
{
    public interface IInputProvider
    {
        public Vector2 MousePos { get; set; }
        public Vector2 ArrowPos { get; set; }
    }
}
