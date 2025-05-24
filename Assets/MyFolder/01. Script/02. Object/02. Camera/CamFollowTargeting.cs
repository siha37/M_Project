using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyFolder._01._Script._02._Object._02._Camera
{
    public class CamFollowTargeting : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);
        [SerializeField] private float speed;

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, target.position+offset, Time.fixedDeltaTime * speed);
        }
    }
}
