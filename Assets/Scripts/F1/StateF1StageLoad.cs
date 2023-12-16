using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StateF1StageLoad : ShootIState
{
    private List<string[]> _csvDatas = new List<string[]>();
    private string stageInfo="stage";//ステージ情報のcsvのファイル名
    public TextAsset _csvFile;
    public IEnumerator Handle(ShootContext shootContext)
    {
        string targetCode=shootContext.Stage;
        _csvFile = Resources.Load(stageInfo) as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvDatas.Add(line.Split(','));
        }
        for (var x = 0; x < _csvDatas.Count; x++)
        {
            if(_csvDatas[x][0]==targetCode){//csvファイルの該当箇所をSHootContextに送る
                shootContext.StageInfo=_csvDatas[x];
            }
        }
        shootContext.SetState(new StateF2EnemyLoad());
        yield return "This is not a coroutine";
    }
}
