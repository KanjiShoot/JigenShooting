using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public string nextScene;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Image tapped!");
        LoadScene();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}




