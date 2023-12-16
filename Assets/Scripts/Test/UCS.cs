/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using System;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UCS : MonoBehaviour
{
    public int GetUCSFromCharacter(string character)
    {
        if (!string.IsNullOrEmpty(character) && character.Length == 1)
        {
            Encoding utf32 = Encoding.UTF32;
            byte[] bytes = utf32.GetBytes(character);

            // UTF-32エンコードの最初の4バイトがUCS符号ポイントです
            if (bytes.Length >= 4)
            {
                int ucs = BitConverter.ToInt32(bytes, 0);
                return ucs;
            }
        }

        return -1; // 無効な文字またはエラーの場合
    }

    public void Start()
    {
        string character = "方";
        int ucs = GetUCSFromCharacter(character);

        if (ucs != -1)
        {
            Debug.Log($"Character '{character}' のUCS符号ポイントは {ucs} です。");
        }
        else
        {
            Debug.Log($"無効な文字またはエラーが発生しました。");
        }
    }
}
