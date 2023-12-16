using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using F4;
public class StateF5End2Result : ShootIState
{
    public IEnumerator Handle(ShootContext shootContext){
        //リザルト画面へ以降するステート
        F4.ShootGlobal.superList.Clear();

        for(int i=0;i<8;i++){
            //Debug.Log(shootContext.Correct[i]);
        }
        SceneManager.LoadScene("Result");
        //shootContext.CurrentEnumState = ShootStates.F1StageLoad;//多分いらない

        yield return "This is not a coroutine";
    }
}
