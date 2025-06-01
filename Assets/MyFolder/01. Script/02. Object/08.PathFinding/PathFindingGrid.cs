using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyFolder._01._Script._02._Object._08.PathFinding
{
    [System.Serializable]
    public class Node
    {
        
        public Node(bool isWall, float x, float y)
        {
            this.isWall = isWall;
            this.x = x;
            this.y = y;
        }

        public bool isWall;
        public Node parentNode;
        
        public float x, y, g, h;
        public float f
        {
            get { return g + h; }
        }
    }

    [System.Serializable]
    public class NodeOneLine
    {
        public Node[] gird;
    }

    public class PathFindingGrid : MonoBehaviour
    {
        public Transform bottomLeft, topRight;
        public Vector2 startPos, targetPos;

        [SerializeField] private float perPixel =0.5f;
        int _sizeX, _sizeY;
        public NodeOneLine[] NodeArray;
        Node _startNode , _targetNode , _curNode;
        List<Node> _openList,_closedList;

        private void Start()
        {
            PathFinding();
        }

        public void PathFinding()
        {
            _sizeX = (int)Math.Round((topRight.position.x - bottomLeft.position.x) / perPixel) + 1;
            _sizeY = (int)Math.Round((topRight.position.y - bottomLeft.position.y) / perPixel) + 1;
            NodeArray = new NodeOneLine[_sizeX];

            for (int i = 0; i < _sizeX; i++)
            {
                NodeArray[i] = new NodeOneLine
                {
                    gird = new Node[_sizeY]
                };
                for (int j = 0; j < _sizeY; j++)
                {
                    bool isWall = false;
                    foreach (Collider2D col in Physics2D.OverlapCircleAll(
                                 new Vector2(perPixel*i + bottomLeft.position.x, perPixel*j + bottomLeft.position.y), .4f))
                    {
                        if (col.gameObject.layer == LayerMask.NameToLayer("Wall"))
                        {
                            isWall = true;
                        }
                    }

                    NodeArray[i].gird[j] = new Node(isWall, perPixel*i + bottomLeft.position.x, perPixel*j + bottomLeft.position.y);
                }
            }
        }
        
        private void OnDrawGizmos()
        {
            if (NodeArray == null || NodeArray.Length == 0)
                return;
            Gizmos.color = Color.green;
            foreach (NodeOneLine n in NodeArray)
            {
                foreach (Node n1 in n.gird)
                    Gizmos.DrawSphere(new Vector3(n1.x, n1.y, 0), 0.05f);
            }
        }
    }
}