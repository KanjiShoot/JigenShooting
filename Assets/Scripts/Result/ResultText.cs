/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Result;

namespace Result{
    public class ResultText : MonoBehaviour
    {
        public GameObject resultTextPrefab;

        public Canvas canvas;
        public GameObject TextK_panel;

        // Start is called before the first frame update
        void Start()
        {
            GameObject targetToggle=null;//未割り当て防止のためnullを入れる
            for(int i=0;i<Result.ResultGlobal.resultList.Count;i++){
                Vector3 vector=GetResultLocation(i);//resultTextの配置場所を設定
                GameObject _resultTextPrefab = Instantiate(resultTextPrefab,vector,Quaternion.identity);

                string textK=(string)Result.ResultGlobal.resultList[i][0];
                string madeMean=(string)Result.ResultGlobal.resultList[i][1];
                bool textK_appear=(bool)Result.ResultGlobal.resultList[i][2];
                bool textK_ifCorrect=(bool)Result.ResultGlobal.resultList[i][3];
                string madePron=(string)Result.ResultGlobal.resultList[i][4];

                _resultTextPrefab.transform.SetParent(TextK_panel.transform, false);
                _resultTextPrefab.GetComponent<ResultTextController>().Initialize(textK,madeMean,textK_appear,textK_ifCorrect,madePron);

                if(i==0)targetToggle=_resultTextPrefab;
            }
            targetToggle.GetComponent<Toggle>().isOn=true;
        }
        private Vector3 GetResultLocation(int count){
            int ROW_NUM=5;//列の数
            int row=count%ROW_NUM;
            int column =count/ROW_NUM;

            float DIF_X=20f;
            float DIF_Y=25f;

            float DEFAULT_X=-40f;
            float DEFAULT_Y=0f;

            float pos_X=DEFAULT_X+(row*DIF_X);
            float pos_Y=DEFAULT_Y-(column*DIF_Y);

            Vector3 location =new Vector3(pos_X,pos_Y,0);

            return location;
        }

    }
}
