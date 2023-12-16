/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StateF2EnemyLoad : ShootIState
{
    private List<string[]> _csvDatas = new List<string[]>();
    public TextAsset _csvFile;
    public IEnumerator Handle(ShootContext shootContext){

        _csvFile = Resources.Load(shootContext.Stage) as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvDatas.Add(line.Split(','));
        }
        shootContext.EnemyInfo=_csvDatas;
        shootContext.SetState(new StateF3CheckTarget());
        yield return "This is not a coroutine";
    }
}
