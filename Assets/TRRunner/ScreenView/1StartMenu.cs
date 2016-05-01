
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
class ScreenView_1StartMenu : FB.ScreenView.IScreenView
{
    /// <summary>
    /// 返回ScreenView的名字，会用这个名字进行注册和导航，别乱取
    /// </summary>
    public string name
    {
        get { return "StartMenu"; }
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
    StartMenu startMenu;

    public void BeginInit(Action<Exception> onInit, FB.ScreenView.ScreenViewLayer layer)
    {
        canvas = GameObject.Find("Canvas").transform;
        startMenu = new StartMenu(canvas);
        startMenu.Start();
        isLoad = true;
        onInit(null);
    }

    public void BeginExit(Action<Exception> onExit)
    {
        startMenu.Destroy();
        startMenu = null;
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

class StartMenu
{
    Transform canvas;
    public StartMenu(Transform canvas)
    {
        this.canvas = canvas;
    }
    GameObject start;
    public void Start()
    {
        
    }
    public void Update()
    {

    }
    public void Destroy()
    {
        GameObject.Destroy(start);
    }
}