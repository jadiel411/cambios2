using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneChanger2 : MonoBehaviour
{
    public static SceneChanger2 instance;

    private string selectedCharacter;
    private Scene gameScene;

    public GameObject Selector;

    void Awake()
    {
        instance = this;
    }

    public void SelectCharacter(string characterName)
    {
        selectedCharacter = characterName;

        // Si la escena Game no está cargada: cargarla
        if (!SceneManager.GetSceneByName("Game").isLoaded)
        {
            StartCoroutine(LoadGameSceneAndPlaceCharacter());
        }
        else
        {
            // Si ya está cargada: solo cambiar personaje
            PlaceCharacterInLoadedScene();
        }
    }

    IEnumerator LoadGameSceneAndPlaceCharacter()
    {
        var async = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        yield return async;

        gameScene = SceneManager.GetSceneByName("Game");

        SceneManager.SetActiveScene(gameScene);
        PlaceCharacterInLoadedScene();
    }

    void PlaceCharacterInLoadedScene()
    {
        if (!gameScene.isLoaded)
            gameScene = SceneManager.GetSceneByName("Game");

        GameObject parent = null;

        // Buscar el contenedor "Sonic Player1"
        foreach (var root in gameScene.GetRootGameObjects())
        {
            if (root.name == "Sonic Player2")
            {
                parent = root;
                break;
            }
        }

        if (parent == null)
        {
            Debug.LogError("No existe Sonic Player1.");
            return;
        }

        // Borrar el personaje anterior


        // Cargar el nuevo prefab
        GameObject prefab = Resources.Load<GameObject>("Players/" + selectedCharacter);

        if (prefab == null)
        {
            Debug.LogError("Prefab no encontrado: " + selectedCharacter);
            return;
        }

        // Instanciar nuevo
        GameObject newPlayer = Instantiate(prefab, parent.transform);
        newPlayer.name = prefab.name;

        parent.SetActive(true);
        newPlayer.SetActive(true);
        Selector.SetActive(false);

        Debug.Log("Personaje seleccionado: " + selectedCharacter);
    }
}
