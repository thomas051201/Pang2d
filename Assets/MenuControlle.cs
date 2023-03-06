using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuControlle : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button playButton, quiteButton;
    // Start is called before the first frame update

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        playButton = uiDocument.rootVisualElement.Q<Button>("BtnPlay");
        quiteButton = uiDocument.rootVisualElement.Q<Button>("BtnQuit");

        playButton.clicked += playButtonClicked;
        quiteButton.clicked += quitButtonClicked;

    }
    void playButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Play");
    }
    void quitButtonClicked()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
        Debug.Log("quitter le jeux");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
