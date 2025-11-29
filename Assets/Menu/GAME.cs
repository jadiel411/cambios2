using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME : MonoBehaviour
{
    // Cambiar a una escena por nombre
    public void LoadSceneByName(string sceneName)
    {
        sceneName = "Game";
        SceneManager.LoadScene(sceneName);
    }

}