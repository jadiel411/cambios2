using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    public int currentCharacter = 0;

    void Start()
    {
        // Desactiva todos
        foreach (var c in characters)
            c.SetActive(false);

        // Activa el inicial
        if (characters.Count > 0)
            ActiveCharacter(0);
    }

    public void ActiveCharacter(int index)
    {
        // Apaga todos
        foreach (GameObject character in characters)
            character.SetActive(false);

        // Activa el que corresponde
        if(index >= 0 && index < characters.Count)
        {
            characters[index].SetActive(true);
            currentCharacter = index;
        }
    }

    // BOTÓN ANTERIOR
    public void PreviousCharacter()
    {
        int index = currentCharacter - 1;
        if (index < 0) index = characters.Count - 1;
        ActiveCharacter(index);
    }

    // BOTÓN SIGUIENTE
    public void NextCharacter()
    {
        int index = (currentCharacter + 1) % characters.Count;
        ActiveCharacter(index);
    }
    public void SelectAndStartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacter);
        SceneManager.LoadScene("Game");
    }
}
