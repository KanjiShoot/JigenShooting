/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using F3;
using F3ToF4;

public class StateF3CheckTarget : ShootIState
{
    
   public IEnumerator Handle(ShootContext shootContext)
   {

        const int TARGET_LINE=0;
        const int MADE_COLUMN=0;
        const int PRON_COLUMN=2;

        string target,pron;
        target = shootContext.EnemyInfo[TARGET_LINE][MADE_COLUMN];
        pron = shootContext.EnemyInfo[TARGET_LINE][PRON_COLUMN];
        F3.EventManager.CreateTarget?.Invoke();

        F3.EventManager.PlaceTarget?.Invoke(target,pron);

        //先にここでF4のEventManagerにstageInfoのデータを送る
        F3ToF4.EventManager.HandleDataReady?.Invoke(shootContext);
        Result.EventManager.HandleDataReady.Invoke(shootContext);


        //ここでheartを設置

        while(ShootGlobal.targetExist){
            yield return null;
        }
        shootContext.Correct=new bool[] {true};

        //パーティクルを動作
        F3.EventManager.SpawnAndPlayParticle?.Invoke();
        yield return new WaitForSeconds(1);
        F3.EventManager.DestroyParticle?.Invoke();
        shootContext.SetState(new StateF4StartFall());
    }

    
}
