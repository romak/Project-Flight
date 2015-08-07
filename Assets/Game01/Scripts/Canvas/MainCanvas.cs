using UnityEngine;
using System.Collections;

public class MainCanvas : MonoBehaviour {

    public GameObject inGameMenu;
    public GameObject mainMenu;
    public GameObject inGameUI;
    public GameObject storeMenu;
    public GameObject newGameMenu;
    public GameObject tutorialMenu;
    public GameObject levelEndMenu;
    public GameObject settingsMenu;
    public GameObject loadingMenu;
    public GameObject deathMenu;
    public GameObject creditsMenu;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start () {
	
	}
	
	void Update () {
	
	}

    public void ShowPanel(GameObject ob)
    {
        ob.SetActive(true);
    }

    public void HidePanel(GameObject ob)
    {
        ob.SetActive(false);
    }

}
