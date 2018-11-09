using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTest : MonoBehaviour
{
    private string currentBtn;
    private string currentAxis;
    private float axisValue;

    void Update()
    {
        getBtn();
        getAxis();
    }

    /// <summary>
    ///按键测试
    /// </summary>
    void getBtn()
    {
        var values = Enum.GetValues(typeof(KeyCode));
        for (int x = 0; x < values.Length; x++)
        {
            if (Input.GetKeyDown((KeyCode)values.GetValue(x)))
            {
                currentBtn = values.GetValue(x).ToString();
            }
        }
    }

    /// <summary>
    /// 轴向测试
    /// </summary>
    void getAxis()
    {
        if (Input.GetAxisRaw("X axis") > 0.3 || Input.GetAxisRaw("X axis") < -0.3)
        {
            currentAxis = "X axis";
            axisValue = Input.GetAxisRaw("X axis");
        }

        if (Input.GetAxisRaw("Y axis") > 0.3 || Input.GetAxisRaw("Y axis") < -0.3)
        {
            currentAxis = "Y axis";
            axisValue = Input.GetAxisRaw("Y axis");
        }

        if (Input.GetAxisRaw("3rd axis") > 0.3 || Input.GetAxisRaw("3rd axis") < -0.3)
        {
            currentAxis = "3rd axis";
            axisValue = Input.GetAxisRaw("3rd axis");
        }

        if (Input.GetAxisRaw("4th axis") > 0.3 || Input.GetAxisRaw("4th axis") < -0.3)
        {
            currentAxis = "4th axis";
            axisValue = Input.GetAxisRaw("4th axis");
        }

        if (Input.GetAxisRaw("5th axis") > 0.3 || Input.GetAxisRaw("5th axis") < -0.3)
        {
            currentAxis = "5th axis";
            axisValue = Input.GetAxisRaw("5th axis");
        }

        if (Input.GetAxisRaw("6th axis") > 0.3 || Input.GetAxisRaw("6th axis") < -0.3)
        {
            currentAxis = "6th axis";
            axisValue = Input.GetAxisRaw("6th axis");
        }

        if (Input.GetAxisRaw("7th axis") > 0.3 || Input.GetAxisRaw("7th axis") < -0.3)
        {
            currentAxis = "7th axis";
            axisValue = Input.GetAxisRaw("7th axis");
        }

        if (Input.GetAxisRaw("8th axis") > 0.3 || Input.GetAxisRaw("8th axis") < -0.3)
        {
            currentAxis = "8th axis";
            axisValue = Input.GetAxisRaw("8th axis");
        }

        if (Input.GetAxisRaw("9th axis") > 0.3 || Input.GetAxisRaw("9th axis") < -0.3)
        {
            currentAxis = "9th axis";
            axisValue = Input.GetAxisRaw("9th axis");
        }

        if (Input.GetAxisRaw("10th axis") > 0.3 || Input.GetAxisRaw("10th axis") < -0.3)
        {
            currentAxis = "10th axis";
            axisValue = Input.GetAxisRaw("10th axis");
        }

        if (Input.GetAxisRaw("11th axis") > 0.3 || Input.GetAxisRaw("11th axis") < -0.3)
        {
            currentAxis = "11th axis";
            axisValue = Input.GetAxisRaw("11th axis");
        }

        if (Input.GetAxisRaw("12th axis") > 0.3 || Input.GetAxisRaw("12th axis") < -0.3)
        {
            currentAxis = "12th axis";
            axisValue = Input.GetAxisRaw("12th axis");
        }

        if (Input.GetAxisRaw("13th axis") > 0.3 || Input.GetAxisRaw("13th axis") < -0.3)
        {
            currentAxis = "13th axis";
            axisValue = Input.GetAxisRaw("13th axis");
        }

        if (Input.GetAxisRaw("14th axis") > 0.3 || Input.GetAxisRaw("14th axis") < -0.3)
        {
            currentAxis = "14th axis";
            axisValue = Input.GetAxisRaw("14th axis");
        }
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, 250, 50), "CurrentBtn" + currentBtn);
        GUI.TextArea(new Rect(0, 100, 250, 50), "CurrentAxis" + currentAxis);
        GUI.TextArea(new Rect(0, 200, 250, 50), "AxisValue" + axisValue);
    }
}
