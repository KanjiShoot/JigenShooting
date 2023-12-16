/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using UnityEngine;
using System;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class ResultTextController : MonoBehaviour
{
	private string _madeText,_madeMean,_madePron;
    private bool _ifAppear,_ifCorrect;

	private TextMeshProUGUI _textKUI;
	private TextMeshProUGUI _textK_Made_UI,_textK_Mean_UI,_textK_Pron_UI;
    
    private GameObject flame;


	public void Initialize(string madeText, string madeMean,bool ifAppear,bool ifCorrect,string madePron)
	{
        _madeText=madeText;
        Debug.Log("madeMean"+madeMean);
        _madeMean=madeMean;
        _ifAppear=ifAppear;
        _ifCorrect=_ifCorrect;
        _madePron=madePron;

		GameObject textK_TMP=transform.Find("TextK").gameObject;
		_textKUI =textK_TMP.GetComponent<TextMeshProUGUI>();


		_textKUI.text=madeText;
        var toggle = GetComponent<Toggle>();

        //色替え
        if(ifAppear==true){
            Debug.Log("ifAppear");
            if(ifCorrect==true){
                _textKUI.color=Color.black;//必要に応じて色替え
            }else{
                _textKUI.color=Color.gray;//必要に応じて色替え
            }
        }else{
            Debug.Log("ifAppearFalse");
            _textKUI.color=Color.gray;//必要に応じて色替え
            _textKUI.text="?";
            _madeText="?";
            _madeMean="?";
            _madePron="?";
        }

        GameObject TextK_pannel=transform.parent.gameObject;
        toggle.group = TextK_pannel.GetComponent<ToggleGroup>(); 
	}
    
    public void OnClick(){
        GameObject rootObject = transform.root.gameObject;

        

        _textK_Mean_UI= rootObject.transform.Find("SelectedKmean").GetComponent<TextMeshProUGUI>();
        _textK_Mean_UI.text=_madeMean;

        _textK_Pron_UI= rootObject.transform.Find("SelectedKpron").GetComponent<TextMeshProUGUI>();
        _textK_Pron_UI.text=_madePron;
        _textK_Made_UI= rootObject.transform.Find("SelectedK").GetComponent<TextMeshProUGUI>();
        _textK_Made_UI.text=_madeText;
    }

}

