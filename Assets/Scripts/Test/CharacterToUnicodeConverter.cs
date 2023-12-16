using UnityEngine;

public class CharacterToUnicodeConverter : MonoBehaviour
{
    public string character = "方"; // 変換したい文字

    private void Start()
    {
        int unicode = GetUnicodeFromCharacter(character);

        if (unicode != -1)
        {
            Debug.Log($"Character '{character}' のユニコードポイントは U+{unicode:X4} です。");
        }
        else
        {
            Debug.Log("無効な文字またはエラーが発生しました。");
        }
    }

    public int GetUnicodeFromCharacter(string character)
    {
        if (!string.IsNullOrEmpty(character) && character.Length == 1)
        {
            // 文字をUnicodeに変換
            int unicode = (int)character[0];
            return unicode;
        }

        return -1; // 無効な文字またはエラーの場合
    }
}
