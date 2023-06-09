using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private int fullElement;
    public Winnable win;
    public static int myElement;
    public GameObject myPuzzl;
    public GameObject myPanel;
    

    void Start()
    {
        fullElement = myPuzzl.transform.childCount;
    }

    void Update()
    {
        if (fullElement == myElement) // Условие при победе
        {
            // Вместо изменения панелей переход на другую сцену
            myPanel.SetActive(false);
            win.SetMode();
            FindObjectOfType<ActivePuzzle>().SetPuzzle(false);
            FindObjectOfType<Player>().SetUI();
            FindObjectOfType<needItem>().setComplete();
            SceneManager.UnloadSceneAsync("DragNDropScene");
        }
    }

    public static void AddElement()
    {
        myElement++;
    }

    public void Exit()
    {
        FindObjectOfType<ActivePuzzle>().SetPuzzle(false);
        FindObjectOfType<Player>().SetUI();
        SceneManager.UnloadSceneAsync("DragNDropScene");
    }
}
