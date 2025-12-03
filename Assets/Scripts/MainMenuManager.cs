using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button playButton;
    void Start()
    {
        playButton.onClick.AddListener(LoadLevel1);
    }
    
    void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
