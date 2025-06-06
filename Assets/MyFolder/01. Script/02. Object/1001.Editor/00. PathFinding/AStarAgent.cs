using System.Collections.Generic;
using MyFolder._01._Script._02._Object._08.PathFinding;
using MyFolder._01._Script._1001.StaticClass;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._1001.Editor._08._PathFinding
{
    public class AStarAgent : MonoBehaviour
    {
        PathFindingGrid _pathFindingGrid;
        [SerializeField] private bool allowDiagonal, dontCrossCorner;
        public List<Node> FinalNodeList;
        
        Node startNode,targetNode,currentNode;
        
        List<Node> openList,closedList;

        public Transform TargetObejct;

        public delegate void PathFindingEventHandler();
        public PathFindingEventHandler OnPathFinding;
        
        void Start()
        {
            _pathFindingGrid = GameObject.FindFirstObjectByType<PathFindingGrid>();
            if(_pathFindingGrid == null)
                this.enabled = false;
            PathFind();
        }

        
        public void PathFind()
        {
            Vector2Int startPos = new Vector2Int(
                ValueRound.FloatToInt((transform.position.x - _pathFindingGrid.bottomLeft.position.x) / _pathFindingGrid.perPixel),
                ValueRound.FloatToInt((transform.position.y - _pathFindingGrid.bottomLeft.position.y) / _pathFindingGrid.perPixel ));
            Vector2Int targetPos = new Vector2Int(
                ValueRound.FloatToInt((TargetObejct.position.x - _pathFindingGrid.bottomLeft.position.x) / _pathFindingGrid.perPixel),
                ValueRound.FloatToInt((TargetObejct.position.y - _pathFindingGrid.bottomLeft.position.y) / _pathFindingGrid.perPixel));
            NodeOneLine[] nodearrary = _pathFindingGrid.NodeArray;
            
            startNode = nodearrary[startPos.x].gird[startPos.y];
            targetNode = nodearrary[targetPos.x].gird[targetPos.y];
            
            openList = new List<Node>() {startNode};
            closedList = new List<Node>();
            FinalNodeList = new List<Node>();

            while (openList.Count > 0)
            {
                currentNode = openList[0];
                for (int i = 1; i < openList.Count; i++)
                {
                    if(openList[i].f <= currentNode.f && openList[i].h <= currentNode.h)
                        currentNode = openList[i];
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode == targetNode)
                {
                    Node TargetCurrentNode = targetNode;
                    while (TargetCurrentNode != startNode)
                    {
                        FinalNodeList.Add(TargetCurrentNode);
                        TargetCurrentNode = TargetCurrentNode.parentNode;
                    }
                    FinalNodeList.Add(startNode);
                    FinalNodeList.Reverse();

                    for (int i = 0; i < FinalNodeList.Count; i++)
                    {
                        
                    }
                    
                    
                    OnPathFinding?.Invoke();

                    return;
                }

                if (allowDiagonal)
                {
                    OpenListAdd(currentNode.gridX+1, currentNode.gridY+1);
                    OpenListAdd(currentNode.gridX-1, currentNode.gridY+1);
                    OpenListAdd(currentNode.gridX-1, currentNode.gridY-1);
                    OpenListAdd(currentNode.gridX+1, currentNode.gridY-1);
                }
                
                OpenListAdd(currentNode.gridX, currentNode.gridY + 1);
                OpenListAdd(currentNode.gridX + 1, currentNode.gridY);
                OpenListAdd(currentNode.gridX, currentNode.gridY - 1);
                OpenListAdd(currentNode.gridX - 1, currentNode.gridY);
            }
        }

        private void OpenListAdd(int checkX, int checkY)
        {
            NodeOneLine[] nodearrary = _pathFindingGrid.NodeArray;
            if (checkX >= 0 &&
                checkX < nodearrary.Length &&
                checkY >= 0 &&
                checkY < nodearrary.Length &&
                !nodearrary[checkX].gird[checkY].isWall &&
                !closedList.Contains(nodearrary[checkX].gird[checkY]))
            {
                if (allowDiagonal &&
                    nodearrary[currentNode.gridX].gird[checkY].isWall &&
                    nodearrary[checkX].gird[currentNode.gridY].isWall)
                    return;

                if (dontCrossCorner &&
                    nodearrary[currentNode.gridX].gird[checkY].isWall ||
                    nodearrary[checkX].gird[currentNode.gridY].isWall)
                    return;
                Node NeighborNode = nodearrary[checkX].gird[checkY];
                int MoveCost = currentNode.g + (currentNode.gridX - checkX == 0 || currentNode.gridY - checkX == 0 ? 10 : 14);


                if (MoveCost < NeighborNode.g || !openList.Contains(NeighborNode))
                {
                    NeighborNode.g = MoveCost;
                    NeighborNode.h = (Mathf.Abs(NeighborNode.gridX - targetNode.gridX) + Mathf.Abs(NeighborNode.gridY - targetNode.gridY)) * 10;
                    NeighborNode.parentNode = currentNode;
                    
                    openList.Add(NeighborNode);
                }
            }
        }
    }
}
