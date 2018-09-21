using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;
using System.Text;

namespace Eagle1st
{
    public class WWWHelper : MonoSingleton<WWWHelper>
    {

        public void WWWGetText(string from, float timeout, Action<string> callback)
        {
            StartCoroutine(GetTextWWW(from, timeout, callback));
        }

        IEnumerator GetTextWWW(string from, float timeout, Action<string> callback)
        {
            WWW loader = new WWW(from);
            float duration = 0.0f;
            while (!loader.isDone && duration < timeout)
            {
                duration += Time.deltaTime;
                yield return 0;
            }
            if (loader.error != null || duration >= timeout)
            {
                Debug.Log(loader.error);
                if (callback != null)
                {
                    callback(null);
                }
            }
            else
            {
                if (loader.text != null)
                {
                    if (callback != null)
                    {
                        callback(loader.text);
                    }
                }
            }
            if (loader != null)
            {
                loader.Dispose();
                loader = null;
            }
        }

        public void WWWGetTexture(string from, float timeout, Action<Texture> callback)
        {
            StartCoroutine(GetTextureWWW(from, timeout, callback));
        }

        IEnumerator GetTextureWWW(string from, float timeout, Action<Texture> callback)
        {
            WWW loader = new WWW(from);
            float duration = 0.0f;
            while (!loader.isDone && duration < timeout)
            {
                duration += Time.deltaTime;
                yield return 0;
            }
            if (loader.error != null || duration >= timeout)
            {
                Debug.Log(loader.error);
                if (callback != null)
                {
                    callback(null);
                }
            }
            else
            {
                if (loader.texture != null)
                {
                    if (callback != null)
                    {
                        callback(loader.texture);
                    }
                }
            }
            if (loader != null)
            {
                loader.Dispose();
                loader = null;
            }
        }

        public string Sigin(string key, byte[] body)
        {

            byte[] byte_md5 = GetMd5Hash(body); // 对获取的MD5值转换为 16 进制的字符串。
            string str_md5 = ToHexString(byte_md5) + key; // 转换后的 md5 字符串 后面追加上key。

            str_md5 = str_md5.ToLower(); // 把 追加后的字符串全部转换为小写。
            byte[] data = System.Text.Encoding.UTF8.GetBytes(str_md5); // 获取字符串存储的二进制值，UTF-8格式存储的二进制值

            byte[] sha1 = System.Security.Cryptography.SHA1.Create().ComputeHash(data); // 对 获取到的二进制进行sha1运算。

            return ToHexString(sha1).ToLower(); // 把 sha1 转换为 16进制字符串，并返回

        }

        // 把字节型转换成十六进制字符串  
        public string ToHexString(byte[] InBytes)
        {
            //string StringOut = "";
            //foreach (byte InByte in InBytes)
            //{
            //    //StringOut = StringOut + string.Format("{0:X2} ", InByte);
            //    StringOut = StringOut + System.Convert.ToString(InByte, 16);
            //    StringOut = StringOut + System.Convert.ToString(InByte, 16);
            //    (data[i].ToString("x2")
            //}
            //return System.Text.Encoding.UTF8.GetBytes(StringOut);

            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < InBytes.Length; i++)
            {
                sBuilder.Append(InBytes[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public byte[] GetMd5Hash(byte[] input)
        {

            if (input == null)
            {
                return null;
            }

            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // 将输入字符串转换为字节数组并计算哈希数据  
            byte[] data = md5Hash.ComputeHash(input);

            return data;
        }

        public double ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = System.TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }

        public void StopAllWWWW()
        {
            StopAllCoroutines();
        }
    }
}
