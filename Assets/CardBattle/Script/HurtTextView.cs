using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtTextView : MonoBehaviour
{
    /// <summary>
    /// 滚动速度
    /// </summary>
    protected float speed = 8f;

    /// <summary>
    /// 计时器
    /// </summary>
    protected float timer = 0f;

    /// <summary>
    /// 销毁时间
    /// </summary>
    protected float time = 2.5f;

    protected virtual void Update()
    {
        Scroll();
    }

    /// <summary>
    /// 冒泡效果
    /// </summary>
    protected virtual void Scroll()
    {
        Color color = this.GetComponent<Text>().color;

        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        timer += Time.deltaTime;
        //字体渐变透明
        if (timer > 1.25f)
        {
            color.a = 1 - timer + 1;
            this.GetComponent<Text>().color = color;
        }
        else
        {
            this.GetComponent<Text>().color = color;
        }
        
        Destroy(gameObject, time);
    }
}
