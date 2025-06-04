using UnityEngine;

namespace MyFolder._01._Script._02._Object._1001.Editor._08._PathFinding
{
    public class AStarAgentMove : MonoBehaviour
    {
        private Transform _tf;
        private AStarAgent _agent;
        private Vector3 _startPosition, _endPosition;
        private int listindex = 0;
        [SerializeField] private float time = 0;
        [SerializeField] private float moveSpeed;
        private bool Following = false;
        void Awake()
        {
            _tf = transform;
            listindex = 0;
            if(TryGetComponent(out _agent))
                _agent.OnPathFinding+=PathFindingListComplete;
        }

        public void PathFindingListComplete()
        {
            PathFollow();
        }
        void PathFollow()
        {
            if(listindex ==_agent.FinalNodeList.Count)
                return;
            if(listindex == 0)
            {
                _startPosition = _tf.position;
                _endPosition = new Vector3(_agent.FinalNodeList[listindex].x,_agent.FinalNodeList[listindex].y,0);
            }
            else
            {
                _startPosition = new Vector3(_agent.FinalNodeList[listindex - 1].x, _agent.FinalNodeList[listindex - 1].y, 0);
                _endPosition = new Vector3(_agent.FinalNodeList[listindex].x, _agent.FinalNodeList[listindex].y, 0);
            }
            Following = true;
            listindex++;
            time = 0;
        }

        void FixedUpdate()
        {
            if (Following)
            {
                time += Time.deltaTime * moveSpeed;
                if (time > 1)
                {
                    Following = false;
                    PathFollow();
                }

                _tf.position = Vector3.Lerp(_startPosition, _endPosition, time);
            }
        }
    }
}
