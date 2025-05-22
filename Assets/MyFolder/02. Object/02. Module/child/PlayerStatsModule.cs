﻿using MyFolder._01.Script._02.Object.Player;
using MyFolder._01.Script._02.Object.Player.State;
using UnityEngine;

namespace Assets.MyFolder._01.Script._02.Object.Player.Module.child
{
    class PlayerStatsModule : IAgentModule
    {
        public float DashMutiple { get; set; } = 2f;
        [SerializeField] private float jumpForce = 3f;
        public float JumpForce => jumpForce;

        public void ChangedState(IAgentState oldstate, IAgentState newstate)
        {
        }

        public void Init(PlayerController player)
        {
        }

        public void OnDisable()
        {
        }

        public void OnEnable()
        {
        }

        public void Init(AgentController player)
        {
        }
    }
}
