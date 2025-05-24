using System;
using UnityEngine;
using BehaviorDesigner.Runtime;

namespace MyFolder._01._Script._02._Object._00._Agent._01._Enemy
{
    public class EnemyBehaviorVarialbesInterface : MonoBehaviour
    {
        [SerializeField] private BehaviorTree behaviorTree;

        public void FixedUpdate()
        {
            behaviorTree.SetVariable("MyPostion",(SharedVector3)transform.position);
        }
    }
}
