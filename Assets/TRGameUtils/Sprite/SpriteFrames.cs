using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class SpriteFrames : MonoBehaviour
{
    public Dictionary<string, List<Sprite>> Clips = new Dictionary<string, List<Sprite>>();
    public List<string> clipsName;
    void Start()
    {

    }
    public void addClip(string name)
    {
        Clips.Add(name, new List<Sprite>());
    }
}
