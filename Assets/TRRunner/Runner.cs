﻿using UnityEngine;
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
        public int JumpsTimeAllowed = 1;
        /// <summary>
        /// 跳跃的力的大小
        /// </summary>
        public float JumpForce = 1;
        /// <summary>
        /// 两次跳跃之间的冷却时间
        /// </summary>
        public float CooldownBetweenJumps = 0.5f;
        /// <summary>
        /// 是否仅可以在地面时跳跃
        /// </summary>
        public bool JustCanJumpOnGround = true;
        /// <summary>
        /// 动画控制器
        /// </summary>
        public Animator animator;
        /// <summary>
        /// 已跳跃次数
        /// </summary>
        public int jumpTimes = 0;
        /// <summary>
        /// 影子的Transform
        /// </summary>
        public Transform shadow;
        /// <summary>
        /// 角色状态，跑步、跳起、降落、二段跳
        /// </summary>
        public enum PlayerState
        {
            JumpDown,
            JumpTwice,
            JumpUp,
            Run
        }
        public PlayerState playerState = PlayerState.Run;

        public bool isOnGround = false;
        public bool isCoolDown = false;
        public float coolDownTimer = 0;

        private Rigidbody2D R2D;
        private SpriteFrames SF;

        void Start()
        {
            R2D = this.transform.GetComponent<Rigidbody2D>();
            //animator = this.transform.GetComponent<Animator>();
            SF = GetComponent<SpriteFrames>();
        }

        void Update()
        {
            showShadow();
            stateCheck();
            checkCoolDown();
            Jump();
        }

        void stateCheck()
        {
            if (R2D.velocity.y < 0)
            {
                playerState = PlayerState.JumpDown;
            }
            else if (R2D.velocity.y == 0)
            {
                //playerState = PlayerState.Run;
            }
            //animator.SetInteger("jumpState", (int)playerState);
            SF.curClip = (int)playerState;
        }

        void Jump()
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isOnGround)
            {
                playerState = PlayerState.JumpUp;
                R2D.AddForce(Vector2.up * JumpForce);
                transform.GetComponent<AudioSource>().Play();
                coolDownTimer = 0;
                jumpTimes++;
                return;
            }
            else if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && jumpTimes < 2)
            {
                playerState = PlayerState.JumpTwice;
                R2D.velocity = Vector3.zero;
                R2D.AddForce(Vector2.up * JumpForce);
                transform.GetComponent<AudioSource>().Play();
                jumpTimes++;
                return;
            }
        }

        void checkCoolDown()
        {
            if (coolDownTimer <= CooldownBetweenJumps && coolDownTimer >= 0)
            {
                coolDownTimer += Time.deltaTime;
                isCoolDown = false;
            }
            else
            {
                isCoolDown = true;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                R2D.velocity = Vector2.zero;
                playerState = PlayerState.Run;
                isOnGround = true;
                jumpTimes = 0;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = false;
            }
        }

        void checkDead()
        {
            if (transform.position.x < -9.15f || transform.position.y < -5.35f)
            {
                Debug.Log("GameOver");
            }
        }

        RaycastHit2D hit2D;
        void showShadow()
        {
            Debug.Log(LayerMask.NameToLayer("Ground"));
            hit2D = Physics2D.Raycast(transform.position, Vector3.down, 10f, 1 << LayerMask.NameToLayer("Ground"));
            if (hit2D && hit2D.collider != null)
            {
                Debug.Log("hit");
                shadow.position = hit2D.point;
            }
        }
    }

}
