using UnityEngine;
using System.Collections;
namespace TRRunner
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class Runner : MonoBehaviour
    {
        /// <summary>
        /// 允许跳跃的次数
        /// </summary>
        public int JumpsTimeAllowed { get; set; }
        /// <summary>
        /// 跳跃的力的大小
        /// </summary>
        public float  JumpForce { get; set; }
        /// <summary>
        /// 两次跳跃之间的冷却时间
        /// </summary>
        public float CooldownBetweenJumps { get; set; }
        /// <summary>
        /// 是否仅可以在地面时跳跃
        /// </summary>
        public bool JustCanJumpOnGround { get; set; }
    }

}
