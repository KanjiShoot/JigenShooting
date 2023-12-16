using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using F3;
using F4;
using F3ToF4;
using Life;
using Result;

public class ShootMain : MonoBehaviour
{
    void Awake(){
        F3.EventManager.Init();
        F4.EventManager.Init();
        F3ToF4.EventManager.Init();
        Result.EventManager.Init();
        Life.EventManager.Init();
        Result.ResultGlobal.resultList.Clear();
    }
   void Start()
    {
        StartCoroutine(RunStateMachine());
    }

    IEnumerator RunStateMachine()
    {
        var shootContext = new ShootContext(new StateF1StageLoad());

        while(shootContext.CurrentEnumState != ShootStates.F5End2Result)
        {
            yield return shootContext.Request();
        }
    }
}
