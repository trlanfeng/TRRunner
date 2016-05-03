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

        public bool isOnGround = false;
        public bool isCoolDown = false;
        public float coolDownTimer = 0;

        private Rigidbody2D R2D;

        void Start()
        {
            R2D = this.transform.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            checkCoolDown();
            Jump();
        }

        void Jump()
        {
            if (Input.GetAxis("Fire1") != 0 && isOnGround && isCoolDown)
            {
                R2D.AddForce(Vector2.up * JumpForce);
                transform.GetComponent<AudioSource>().Play();
                coolDownTimer = 0;
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
                isOnGround = true;
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
            if (transform.position.x < -9.15f || transform.position.y < - 5.35f)
            {
                Debug.Log("GameOver");
            }
        }
    }

}
