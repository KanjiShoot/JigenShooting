/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace F4{
    public static class ShootGlobal
    {

        public static int waveQty;//問題数
        public static int enemyQty;//enemyの数(正解を除く)
        public static int correctEnemyQty;//正しい正解の数
        public static int currentCorrectEnemyQty;//正解の数
        public static int currentEnemyQty;//今wave中で残っている敵の数
        public static int currentWaveQty;//残りのwaveの数
        public static bool ifFall;
        public static int fallQty;//落下してしまった敵の数
        public static List<List<object[]>> superList = new List<List<object[]>>();
    }
}
