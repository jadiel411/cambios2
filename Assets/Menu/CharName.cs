using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharName : MonoBehaviour
{
    public string CharaName; // Nombre del prefab dentro de Resources/Players/

    public void SelectCharacter()
    {
        SceneChanger.instance.SelectCharacter(CharaName);
    }
}
