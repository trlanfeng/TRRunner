
using System;
using System.Collections.Generic;
using DG.Tweening;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//IScreenView
//注意，IScreenView会在内存中一直存在，所以每个ScreenView要管理好自己内部资源的生命周期
//收到Destory要立即销毁资源
//受到BeginExit可以销毁可以不销毁，销毁完只后回调
//最简的实现为
//public void BeginExit(Action<Exception> onExit)
//{
//    Destory();
//    onExit();
//}
//如果设计异步的 Init 和 Exit，过程中isBusy要返回true；
//资源加载后isload=true，卸载后=false

//Update为通常更新所用，完成内部动画之类的
//UpdateTask 在BeginInit BeginExit 等导航任务期间内被调用
//完成异步导航任务
class ScreenView_0Logo : FB.ScreenView.IScreenView
{
    /// <summary>
    /// 返回ScreenView的名字，会用这个名字进行注册和导航，别乱取
    /// </summary>
    public string name
    {
        get { return "logo"; }
    }
    /// <summary>
    /// 资源加载后isload=true，卸载后=false
    /// </summary>
    public bool isLoad
    {
        get;
        private set;
    }
    /// <summary>
    ///     //如果设计异步的 Init 和 Exit，过程中isBusy要返回true；
    /// </summary>
    public bool isBusy
    {
        get;
        private set;
    }
    /// <summary>
    /// 透明的ScreenView显示时不会导致下层的ScreenView被Exit，反之则Exit
    /// </summary>
    public bool isTransparent
    {
        get { return false; }
    }

    Transform canvas;
    Logo logo;

    public void BeginInit(Action<Exception> onInit, FB.ScreenView.ScreenViewLayer layer)
    {
        canvas = GameObject.Find("Canvas").transform;
        logo = new Logo(canvas, layer);
        logo.Start();
        isLoad = true;
        onInit(null);
    }

    public void BeginExit(Action<Exception> onExit)
    {
        logo.Destroy();
        logo = null;
        Destory();
        onExit(null);
    }

    public void Destory()
    {
        isLoad = false;
    }

    public void Update(float delta)
    {

    }

    public void UpdateTask(float delta)
    {
        Debug.Log("task!");
    }
}

class Logo
{
    FB.ScreenView.ScreenViewLayer layer;
    Transform canvas;
    public Logo(Transform canvas, FB.ScreenView.ScreenViewLayer layer)
    {
        this.layer = layer;
        this.canvas = canvas;
    }
    GameObject logo;
    public void Start()
    {
        logo = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/Logo"), Vector3.zero, Quaternion.identity) as GameObject;
        logo.transform.SetParent(canvas, false);
        Image img = logo.GetComponent<Image>();
        img.DOFade(0, 0).OnComplete(() => { img.DOFade(1, 3).OnComplete(() => { img.DOFade(0, 3).OnComplete(() => { layer.BeginNavTo("StartMenu", null); }); }); });
    }
    public void Destroy()
    {
        GameObject.Destroy(logo);
    }
}