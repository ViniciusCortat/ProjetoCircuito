using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ReloadPage() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void GoNextScene(string name) {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void DeleteSave() {
        Puzzles.GetInstance().DeleteSave();
        ReloadPage();
    }

    public void Quit() {
        Application.Quit();
    }
}
