using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SetBookOptionFromUI : MonoBehaviour
{
    public TMPro.TMP_Dropdown bookDropdown;

    private void Start()
    {
        bookDropdown.onValueChanged.AddListener(OnBookOptionSelected);

        // Simular escolha de um livro inicial (mocado)
        //OnBookOptionSelected(0); // 0 representa o primeiro livro na lista (índice 0)
    }

    public void OnBookOptionSelected(int bookIndex)
    {
        // Você pode adicionar aqui a lógica para lidar com a escolha do livro
        Debug.Log("Livro selecionado: " + bookDropdown.options[bookIndex].text);
        
        //HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(2);
    }
}
