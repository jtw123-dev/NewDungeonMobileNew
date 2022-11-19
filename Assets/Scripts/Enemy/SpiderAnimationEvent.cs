
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
     private Spider _spider;

    private void Start()
    {
        _spider = GameObject.Find("Spider_Enemy").GetComponent<Spider>();
    }


    public void Fire()
    {
        _spider.TellEventToFire();
    }
}
