using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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
        public float CooldownBetweenJump = 0.5f;
        /// <summary>
        /// 两次冲刺的冷却时间
        /// </summary>
        public float CooldownBetweenRush = 10f;
        /// <summary>
        /// 是否仅可以在地面时跳跃
        /// </summary>
        public bool JustCanJumpOnGround = true;
        /// <summary>
        /// 已跳跃次数
        /// </summary>
        public int jumpTimes = 0;
        /// <summary>
        /// 影子的Transform
        /// </summary>
        public Transform shadow;
        /// <summary>
        /// 跳跃按钮的这招
        /// </summary>
        public Image jumpButtonMask;
        /// <summary>
        /// 冲刺按钮的遮罩
        /// </summary>
        public Image rushButtonMask;
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
        public bool isJumpCoolDown = true;
        public bool isRushCoolDown = true;
        public float jumpCoolDownTimer = 0;
        public float rushCoolDownTimer = 0;

        private Rigidbody2D R2D;
        private SpriteFrames SF;

        void Start()
        {
            R2D = this.transform.GetComponent<Rigidbody2D>();
            SF = GetComponent<SpriteFrames>();
        }

        void Update()
        {
            showShadow();
            stateCheck();
            checkJumpCoolDown();
            checkRushCoolDown();
            //if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            //{
            //    Jump();
            //}
        }

        void stateCheck()
        {
            if (R2D.velocity.y < 0)
            {
                playerState = PlayerState.JumpDown;
            }
            SF.curClip = (int)playerState;
        }

        public void Jump()
        {
            if (!isJumpCoolDown)
            {
                return;
            }
            if (isOnGround)
            {
                playerState = PlayerState.JumpUp;
                R2D.AddForce(Vector2.up * JumpForce);
                transform.GetComponent<AudioSource>().Play();
                jumpCoolDownTimer = CooldownBetweenJump;
                jumpTimes++;
                return;
            }
            else if (jumpTimes < 2)
            {
                playerState = PlayerState.JumpTwice;
                R2D.velocity = Vector3.zero;
                R2D.AddForce(Vector2.up * JumpForce);
                transform.GetComponent<AudioSource>().Play();
                jumpTimes++;
                return;
            }
        }

        void checkJumpCoolDown()
        {
            //if (jumpCoolDownTimer > 0)
            //{
            //    jumpCoolDownTimer -= Time.deltaTime;
            //    isJumpCoolDown = false;
            //    jumpButtonMask.fillAmount = jumpCoolDownTimer / CooldownBetweenJump;
            //}
            //else
            {
                isJumpCoolDown = true;
                jumpCoolDownTimer = 0;
            }
        }

        public void Rush()
        {
            if (!isRushCoolDown)
            {
                return;
            }
            transform.DOMoveX(-1.25f, 0.5f);
            rushCoolDownTimer = CooldownBetweenRush;
        }

        void checkRushCoolDown()
        {
            if (rushCoolDownTimer > 0)
            {
                rushCoolDownTimer -= Time.deltaTime;
                isRushCoolDown = false;
                rushButtonMask.fillAmount = rushCoolDownTimer / CooldownBetweenRush;
            }
            else
            {
                isRushCoolDown = true;
                rushCoolDownTimer = 0;
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
            hit2D = Physics2D.Raycast(transform.position, Vector3.down, 10f, 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Barricades"));
            if (hit2D && hit2D.collider != null)
            {
                shadow.position = hit2D.point;
            }
        }
    }

}
