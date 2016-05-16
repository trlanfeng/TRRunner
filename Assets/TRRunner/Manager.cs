using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace TRRunner
{
    public class Manager : MonoBehaviour
    {

        public static Manager instance = null;
        public static GameManager Game;
        public static InputManager Input;

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

    }
}
