using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    public bool enable;

    private void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        scoreGT = scoreGo.GetComponent<Text>();
        scoreGT.text = "0";
    }


    void Update()
    {
        // 获取鼠标的坐标， 但是z坐标默认设置成 主相机相对0 的绝对值
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
     
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (enable)
        {
            GameObject collidedWith = collision.gameObject;
            if (collidedWith.tag == "Apple")
            {
                Destroy(collidedWith);
            }

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

          
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
