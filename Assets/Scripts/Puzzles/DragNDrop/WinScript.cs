using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private int fullElement;
    public static int myElement;
    public GameObject myPuzzl;
    public GameObject myPanel;
    public GameObject winPanel;

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
            winPanel.SetActive(true);
            SceneManager.UnloadSceneAsync("DragNDropScene");
        }
    }

    public static void AddElement()
    {
        myElement++;
    }
}
