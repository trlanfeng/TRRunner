using UnityEngine;
using System.Collections;
[System.Serializable]
public class LevelScript : MonoBehaviour
{
    // 关卡名称
    public string levelName;
    // 关卡ID
    public int levelID;
    // 过关所需点数
    public int needPoint;
    // 默认初始速度
    public int defaultSpeed;
    // 速度刷新周期
    public int speedPlusTimer;
    // 速度增加量
    public int speedPlusNumber;
}
