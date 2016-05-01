using UnityEngine;
using System.Collections;

namespace TRGameUtils
{
    public class SampleLoader : MonoBehaviour
    {
        static FB.ScreenView.ScreenViewCenter screenViewCenter;
        FB.ScreenView.ScreenViewLayer layer;

        void Start()
        {
            initScreenView();
            regScreenView();
            layer.BeginNavTo("Sample", null);
        }

        void initScreenView()
        {
            screenViewCenter = new FB.ScreenView.ScreenViewCenter();
            screenViewCenter.AddLayer();//增加一个导航层
            layer = screenViewCenter.GetLayer(0);
        }

        void regScreenView()
        {
            layer.RegScreen(new ScreenView_SampleScreenview());
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
