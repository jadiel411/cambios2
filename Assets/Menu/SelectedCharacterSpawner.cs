using UnityEngine;
using System.Collections.Generic;

public class SelectedCharacterSpawner : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();

    void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Apaga todos
        foreach (var c in characters)
            c.SetActive(false);

        // Activa el elegido
        if (index >= 0 && index < characters.Count)
            characters[index].SetActive(true);
    }
}
