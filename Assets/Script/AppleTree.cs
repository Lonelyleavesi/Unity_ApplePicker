using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // ʵ��Ԥ��
    public GameObject applePrefab;

    // �ƶ��ٶ�
    public float speed = 1f;

    // �����
    public float leftAndRightEdge = 10f;

    // ƻ�����ı䷽��ļ���
    public float chanceToChangeDirections = 0.1f;

    // ƻ�����ֵļ��
    public float sencondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // ÿ�����ƻ�� 
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
        // �����˶�
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // �ı䷽��
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); // ��
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // ����
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
