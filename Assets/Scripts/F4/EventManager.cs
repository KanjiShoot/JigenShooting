using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace F4{
    public class EventManager
    {
        //EventSubscribeへの操作
        public static UnityAction<int,int> Wave;
        //StateF4への操作
        public static UnityAction ChangeStateToF5;
        public static UnityAction AddWaveCount;
        public static UnityAction EndWave;

        public static UnityAction<bool> AddResult;


        //OperateSGの登録
        public static UnityAction<int> SetWaveQty;
        public static UnityAction<int> SetEnemyQty;
        public static UnityAction<int> SetCorrectEnemyQty;

        public static UnityAction<int> SetCurrentCorrectEnemyQty;
        public static UnityAction ReduceCurrentCorrectEnemyQty;
        public static UnityAction<int> SetCurrentEnemyQty;
        public static UnityAction ReduceCurrentEnemyQty;
        public static UnityAction<int> SetCurrentWaveQty;
        public static UnityAction ReduceCurrentWaveQty;
        public static UnityAction IfFall2True;
        public static UnityAction IfFall2False;
        public static UnityAction SetFallQty;

        public static UnityAction<List<object[]>> AddWaveList;
        public static UnityAction ReflectSG;

        //TextEnemyControllerへの操作
        public static UnityAction WrongECorrect2Delete;
        public static UnityAction CorrectEWrong2Delete;
        public static UnityAction FallEnd2Delete;
        public static UnityAction AddFallQty;

        public static void Init()
        {
            // 変数にnullを代入
            Wave = null;
            ChangeStateToF5 = null;
            AddWaveCount = null;
            EndWave = null;
            AddResult = null;
            SetWaveQty = null;
            SetEnemyQty = null;
            SetCorrectEnemyQty = null;
            SetCurrentCorrectEnemyQty = null;
            ReduceCurrentCorrectEnemyQty = null;
            SetCurrentEnemyQty = null;
            ReduceCurrentEnemyQty = null;
            SetCurrentWaveQty = null;
            ReduceCurrentWaveQty = null;
            IfFall2True = null;
            IfFall2False = null;
            AddWaveList = null;
            ReflectSG = null;
            WrongECorrect2Delete = null;
            CorrectEWrong2Delete = null;
            SetFallQty=null;
            FallEnd2Delete=null;
            AddFallQty=null;
        }
    }
}
