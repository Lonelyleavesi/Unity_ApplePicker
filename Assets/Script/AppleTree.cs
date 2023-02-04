using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // 实例预设
    public GameObject applePrefab;

    // 移动速度
    public float speed = 1f;

    // 活动区域
    public float leftAndRightEdge = 10f;

    // 苹果树改变方向的几率
    public float chanceToChangeDirections = 0.1f;

    // 苹果出现的间隔
    public float sencondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // 每秒掉落苹果 
        InvokeRepeating("DropApple", 2f, sencondsBetweenAppleDrops);
    }

    void DropApple ()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 基本运动
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // 改变方向
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); // 右
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // 向左
        } 
    }

    
     void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
