using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public string playerName; // Nombre del prefab dentro de Assets/Players
    public Button button;     // Referencia al botón de la UI

    void Start()
    {
        // Si el botón no está asignado en el inspector, lo busca en el mismo objeto
        if (button == null)
            button = GetComponent<Button>();

        if (button != null)
            button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        // Carga el prefab desde la carpeta Assets/Players
        GameObject playerPrefab = Resources.Load<GameObject>("Players/" + playerName);

        if (playerPrefab == null)
        {
            Debug.LogError("No se encontró el prefab en Resources/Players/" + playerName);
            return;
        }

        // Busca el objeto SonicPlayer1 en la escena
        GameObject parentObject = GameObject.Find("SonicPlayer1");
        if (parentObject == null)
        {
            Debug.LogError("No existe un objeto llamado 'SonicPlayer1' en la escena.");
            return;
        }

        // Instancia el prefab dentro de SonicPlayer1
        GameObject newPlayer = Instantiate(playerPrefab, parentObject.transform);
        newPlayer.name = playerPrefab.name;

        Debug.Log("Instanciado " + playerName + " dentro de SonicPlayer1");
    }

}