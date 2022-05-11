/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class F3DSunController : MonoBehaviour {

    float mouseX, mouseY;
    Vector3 offsetVector;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update ()
    {
        mouseX += Input.GetAxis("Mouse X") * 3;
        mouseY += Input.GetAxis("Mouse Y") * 3;

        offsetVector = Quaternion.AngleAxis(mouseX, Vector3.up) * (Vector3.forward + Vector3.up) * 3;

        Vector3 offsetSide = Vector3.Cross(offsetVector, Vector3.up).normalized;

        offsetVector = Quaternion.AngleAxis(mouseY, offsetSide) * offsetVector;

        transform.position = offsetVector;

    }

    // Show FULLSCREEN button
#if !UNITY_EDITOR
    void OnGUI()
    {
        if (!Screen.fullScreen)
        {
            if (GUI.Button(new Rect(10, 10, 150, 100), "Fullscreen"))
            {
                Resolution[] resolutions = Screen.resolutions;
                Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
            }
        }

    }
#endif
}
