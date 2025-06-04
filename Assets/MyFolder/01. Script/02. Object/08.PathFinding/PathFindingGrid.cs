using System.Collections.Generic;
using MyFolder._01._Script._1001.StaticClass;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyFolder._01._Script._02._Object._08.PathFinding
{
    [System.Serializable]
    public class Node
    {
        
        public Node(bool isWall, float x, float y,int gridX, int gridY)
        {
            this.isWall = isWall;
            this.x = x;
            this.y = y;
            this.gridX = gridX;
            this.gridY = gridY;
        }

        public bool isWall;
        public Node parentNode;

        public float x, y;
        public int g, h;
        public int gridX,gridY;
        public int f
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

        [SerializeField] private bool onGizmoDraw = false;
        public float perPixel =0.5f;
        int _sizeX, _sizeY;
        public NodeOneLine[] NodeArray;
        Node _startNode , _targetNode , _curNode;
        List<Node> _openList,_closedList;

        [SerializeField] private MeshFilter cellMeshFilter;
        [SerializeField] private MeshRenderer cellMeshRenderer;
        [SerializeField] private MeshFilter lineMeshFilter;
        [SerializeField] private MeshRenderer lineMeshRenderer;
        
        
        public void PathFinding()
        {
            _sizeX = ValueRound.FloatToInt((topRight.position.x - bottomLeft.position.x) / perPixel)+1;
            _sizeY = ValueRound.FloatToInt((topRight.position.y - bottomLeft.position.y) / perPixel)+1;
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
                                 new Vector2(perPixel*i + bottomLeft.position.x, perPixel*j + bottomLeft.position.y), 0.3f))
                    {
                        if (col.gameObject.layer == LayerMask.NameToLayer("Wall"))
                        {
                            isWall = true;
                        }
                    }

                    NodeArray[i].gird[j] = new Node(isWall, perPixel*i + bottomLeft.position.x, perPixel*j + bottomLeft.position.y,i,j);
                }
            }
        }

        public void GenerateGridMesh()
        {
            Mesh mesh = new Mesh();
            int width = _sizeX;
            int height = _sizeY;
            float cellSize = perPixel;
            
            Vector3[] vertices = new Vector3[width * height * 4];
            int[] triangles = new int[width * height * 6];
            Vector2[] uvs = new Vector2[vertices.Length];

            int v = 0;
            int t = 0;
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if(NodeArray[x].gird[y].isWall)
                        continue;
                    Vector3 origin = new Vector3(x * cellSize, y * cellSize) - new Vector3(); // (XY plane 기준)

                    // 각 셀의 4개 꼭짓점
                    vertices[v + 0] = origin;
                    vertices[v + 1] = origin + new Vector3(cellSize, 0);
                    vertices[v + 2] = origin + new Vector3(0, cellSize);
                    vertices[v + 3] = origin + new Vector3(cellSize, cellSize);

                    // 삼각형 2개로 셀 구성
                    triangles[t + 0] = v + 0;
                    triangles[t + 1] = v + 2;
                    triangles[t + 2] = v + 1;

                    triangles[t + 3] = v + 2;
                    triangles[t + 4] = v + 3;
                    triangles[t + 5] = v + 1;

                    // UV (선택)
                    uvs[v + 0] = new Vector2(0, 0);
                    uvs[v + 1] = new Vector2(1, 0);
                    uvs[v + 2] = new Vector2(0, 1);
                    uvs[v + 3] = new Vector2(1, 1);

                    v += 4;
                    t += 6;
                }
            }
            
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            
            cellMeshFilter.mesh = mesh;
            
            List<Vector3> lineVerts = new();
            List<int> lineIndices = new();
            int li = 0;

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) 
                {
                    if(NodeArray[x].gird[y].isWall)
                        continue;
                    float cx = x * cellSize;
                    float cy = y * cellSize;

                    // 한 셀에 4개 선분 (Line List 방식)
                    Vector3 bl = new(cx, cy, 0);
                    Vector3 br = new(cx + cellSize, cy, 0);
                    Vector3 tr = new(cx + cellSize, cy + cellSize, 0);
                    Vector3 tl = new(cx, cy + cellSize, 0);

                    lineVerts.Add(bl); lineVerts.Add(br); lineIndices.Add(li++); lineIndices.Add(li++);
                    lineVerts.Add(br); lineVerts.Add(tr); lineIndices.Add(li++); lineIndices.Add(li++);
                    lineVerts.Add(tr); lineVerts.Add(tl); lineIndices.Add(li++); lineIndices.Add(li++);
                    lineVerts.Add(tl); lineVerts.Add(bl); lineIndices.Add(li++); lineIndices.Add(li++);
                }
            }

            Mesh lineMesh = new();
            lineMesh.vertices = lineVerts.ToArray();
            lineMesh.SetIndices(lineIndices.ToArray(), MeshTopology.Lines, 0);
            lineMeshFilter.mesh = lineMesh;
        }
        
        private void OnDrawGizmos()
        {
            if (!onGizmoDraw)
                return;
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