using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module
{
    public interface IAgentColliderModule : IAgentModule
    {
        public void OnCollisionEnter2D(Collision2D collision);
        public void OnCollisionExit2D(Collision2D collision);
        public void OnCollisionStay2D(Collision2D collision);
        public void OnTriggerEnter2D(Collider2D other);
        public void OnTriggerExit2D(Collider2D other);
        public void OnTriggerStay2D(Collider2D other);
    }
}