using UnityEngine;
using System.Collections;
using TMPro;

public class TextTargetController : MonoBehaviour
{
	private string _textEnemy;
	private TextMeshProUGUI _textEnemyUI;

	public void Initialize(string textEnemy)
	{
		_textEnemyUI =GetComponent<TextMeshProUGUI>();

		_textEnemyUI.text=textEnemy;
	}
}