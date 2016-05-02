using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace TRRunner
{
    public class Navigator : MonoBehaviour
    {
        public string layerName;
        public static Navigator instance = null;
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
            initScreenView();
            regScreenView();
            layer.BeginNavTo(layerName, null);
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
            layer.RegScreen(new ScreenView_2Game());
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
