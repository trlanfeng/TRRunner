using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

namespace TRRunner
{
    public class Manager : MonoBehaviour
    {

        public static Manager instance = null;
        public static GameManager Game;
        public static InputManager Input;

        public float gameSpeed;
        public static float GameSpeed;

        public Text timeText;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            initManager();
        }

        void initManager()
        {
            Game = GetComponent<GameManager>();
            Input = GetComponent<InputManager>();
        }


        float speedFreshTimer;
        void Update()
        {
            updateTime();
            speedFreshTimer += Time.deltaTime;
            if (speedFreshTimer > 60)
            {
                float s = gameSpeed + 1;
                DOTween.To(() => gameSpeed, x => gameSpeed = x, s, 5);
                speedFreshTimer = 0;
            }
            GameSpeed = gameSpeed;
        }

        void updateTime()
        {
            float t = Time.time;
            string m = ((int)(t / 60)).ToString();
            string s = Mathf.FloorToInt(t % 60f).ToString();
            if (s.Length == 1)
            {
                s = "0" + s;
            }
            timeText.text = "时间   " + m + " : " + s;
        }
    }
}
