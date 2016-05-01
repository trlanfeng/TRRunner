using UnityEngine;
using System.Collections;

public class clientmain : MonoBehaviour
{

    // Use this for initialization
    public Camera mainCamera;
    static Camera sCamera;
    //按键操作延时
    void Start()
    {
        sCamera = mainCamera;
        screenViewCenter = new FB.ScreenView.ScreenViewCenter();
        screenViewCenter.AddLayer();//增加一个导航层
        var layer = screenViewCenter.GetLayer(0);
        layer.RegScreen(new ScreenView_0Logo());

        layer.BeginNavTo("logo", null);

        UserData.Instance().dataTemp["init"] = new MyJson.JsonNode_Object();//相当于一个字典<string,object>
        UserData.Instance().dataTemp["init"].asDict()["test1"] = new MyJson.JsonNode_ValueNumber(123);//存个数值123
        UserData.Instance().dataTemp["init"].asDict()["test2"] = new MyJson.JsonNode_ValueString("abc123");//存个字符串123
        UserData.Instance().dataTemp["init"].asDict()["test3"] = new MyJson.JsonNode_Array();//存个数组
        UserData.Instance().dataTemp["init"].asDict()["test3"].AsList().Add(new MyJson.JsonNode_ValueNumber(334));
        //战场数据


        var v = UserData.Instance().dataTemp["init"].asDict()["test1"].AsInt();//可以这样取
        var v2 = UserData.Instance().dataTemp["init"].asDict()["test3"].AsList()[0].AsInt();//可以这样取
    }
    static FB.ScreenView.ScreenViewCenter screenViewCenter;

    // Update is called once per frame
    void Update()
    {
        if (screenViewCenter != null)
            screenViewCenter.Update(Time.deltaTime);
    }

    public static FB.ScreenView.ScreenViewLayer GetPopLayer()
    {
        return screenViewCenter.GetLayer(1);
    }
    public static FB.ScreenView.ScreenViewLayer GetLayer()
    {
        return screenViewCenter.GetLayer(0);
    }
    public static Camera getMainCamera()
    {
        return sCamera;
    }
}
