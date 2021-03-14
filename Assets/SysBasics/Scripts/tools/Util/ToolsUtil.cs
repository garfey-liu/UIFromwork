/**
* @Author GarFey
* 20180723
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// 工具类
/// </summary>
public static class ToolsUtil
{
    /// <summary>
    /// 获取name  从path中
    /// </summary>
    /// <param name="_path"></param>
    /// <returns></returns>
	public static string getUINameForPath(string _path)
	{
		string uiName = "";
		string[] values = _path.Split (new char[]{ '/' });
		uiName = values [values.Length - 1];
		return uiName;
	}

    /// <summary>
    /// 截取字符长度 设定固定长度 超出的显示...
    /// </summary>
    /// <param name="str"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GetFirstString(string str, int length)
    {
        string ret = str;
        Regex regex = new Regex(@"[\u4e00-\u9fa5]+", RegexOptions.Compiled);
        char[] stringChar = ret.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch(stringChar[i].ToString()))
            {
                nLength += 2;
            }
            else
            {
                nLength += 1;
            }
            if (nLength <= length)
            {
                sb.Append(stringChar[i]);
            }
            else
            {
                break;
            }
        }
        if (sb.ToString() != str)
        {
            sb.Append("...");
        }
        ret = sb.ToString();
        return ret;
    }

    /// <summary>
    /// 将秒数转换成 时 分 秒 格式
    /// </summary>
    /// <param name="timer"> 计时时间 秒/单位 </param>
    /// <param name="isUefa5"> 是否中文间隔 </param>
    /// <returns></returns>
    public static string TimerTimeFormat(int _seconds, bool isUefa5 = false)
    {
        string timerStr = "";
        TimeSpan tsp = new TimeSpan(0, 0, (_seconds));
        if (tsp.Hours > 0)
        {
            if (isUefa5)
            {
                timerStr = string.Format("{0:00}", tsp.Hours) + "小时" + string.Format("{0:00}", tsp.Minutes) + "分" + string.Format("{0:00}", tsp.Seconds) + "秒";
            }
            else
            {
                timerStr = string.Format("{0:00}", tsp.Hours) + ":" + string.Format("{0:00}", tsp.Minutes) + ":" + string.Format("{0:00}", tsp.Seconds);
            }

        }
        else if (tsp.Hours == 0 && tsp.Minutes > 0)
        {
            if (isUefa5)
            {
                timerStr = /*"00:" + */string.Format("{0:00}", tsp.Minutes) + "分" + string.Format("{0:00}", tsp.Seconds) + "秒";
            }
            else
            {
                timerStr = "00:" + string.Format("{0:00}", tsp.Minutes) + ":" + string.Format("{0:00}", tsp.Seconds);
            }
        }
        else if (tsp.Hours == 0 && tsp.Minutes == 0)
        {
            if (isUefa5)
            {
                timerStr = /*"00:00:" + */string.Format("{0:00}", tsp.Seconds) + "秒";
            }
            else
            {
                timerStr = "00:00:" + string.Format("{0:00}", tsp.Seconds);
            }
        }
        return timerStr;
    }

    /// <summary>
    /// 传入秒 转换完整时间 年-月-日 星期几 下午 时：分：秒
    /// </summary>
    /// <param name="_seconds"> 秒数 </param>
    public static string TimerAllFormat(int _seconds)
    {
        string timerStr = "";
        TimeSpan tsp = new TimeSpan(0, 0, (_seconds));
        
        // 将服务器发过来的秒 转换成DateTime的毫秒
        long ticks = ((long)_seconds * (long)10000000 + (long)621355968000000000) ;

        // 将DateTime获取的毫秒 转换成10进制的秒
        long dttks = DateTime.Now.ToUniversalTime().Ticks;
        long sec = (dttks - 621355968000000000 )/ 10000000;
        //Debug.LogError("ticks "+ ticks+ " || datetime dttks" + dttks);

        DateTime dt = new DateTime(ticks);
        timerStr = string.Format("{0:yyyy-MM-dd dddd tt HH:mm:ss.fff}", dt);
        return timerStr;
    }

    /// <summary>
    /// 获取字符长度  中文会被截取乱 显示�
    /// </summary>
    /// <param name="str"></param>
    /// <param name="num"></param>
    /// <returns></returns>
     static string GetSubString(string str, int num)
    {
        string ret = str;
        byte[] buffer = Encoding.Default.GetBytes(ret);

        if (buffer.Length > num)
        {
            ret = Encoding.Default.GetString(buffer, 0, num);
        }
        string rets = ret.Replace("�", "");
        return rets;
    }
}
