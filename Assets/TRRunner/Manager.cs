using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace TRRunner
{
    public class Manager : MonoBehaviour
    {

        public static Manager instance = null;
        public static GameManager Game;
        public static MapManager Map;
        public static BackgroundManager Background;
        public static InputManager Input;

        static FB.ScreenView.ScreenViewCenter screenViewCenter;
        public static FB.ScreenView.ScreenViewLayer layer;

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
            initScreenView();
            regScreenView();
            layer.BeginNavTo("logo", null);
        }

        void initManager()
        {
            Game = GetComponent<GameManager>();
            Map = GetComponent<MapManager>();
            Background = GetComponent<BackgroundManager>();
            Input = GetComponent<InputManager>();
        }

        void initScreenView()
        {
            screenViewCenter = new FB.ScreenView.ScreenViewCenter();
            screenViewCenter.AddLayer();//增加一个导航层
            layer = screenViewCenter.GetLayer(0);
        }

        void regScreenView()
        {
            layer.RegScreen(new ScreenView_0Logo());
            layer.RegScreen(new ScreenView_1StartMenu());
        }

        void Update()
        {
            updateScreenView();
        }

        void updateScreenView()
        {
            if (screenViewCenter != null)
                screenViewCenter.Update(Time.deltaTime);
        }
    }
}
