using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject firstSettings;
    [SerializeField] GameObject secondSettings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("World");
    }   

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenFirstSettings()
    {
        firstSettings.SetActive(true);
        secondSettings.SetActive(false);
    }

    public void OpenSecondSettings()
    {
        secondSettings.SetActive(true);
        firstSettings.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}