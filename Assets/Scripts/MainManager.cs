using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        Debug.Log("Main manager instance initialized."); // TODO: Check if there is a dedicated dependency injection for Unity that can handle this.
    }


    #region Scenes & AppQuit methods
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitApplication()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
    #endif

        Application.Quit();
    }
    #endregion
}
