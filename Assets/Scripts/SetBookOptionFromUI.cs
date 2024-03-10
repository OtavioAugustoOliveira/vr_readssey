using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBookOptionFromUI : MonoBehaviour
{
    public TMPro.TMP_Dropdown bookDropdown;

    private void Start()
    {
        bookDropdown.onValueChanged.AddListener(OnBookOptionSelected);
        Button selectButton = GameObject.Find("SelecionarLivro").GetComponent<Button>(); // Encontrar o botão pelo nome
        selectButton.onClick.AddListener(OnSelectButtonClicked); // Adicionar um listener para o evento de clique do botão
    }

    public void OnBookOptionSelected(int bookIndex)
    {
        // Você pode adicionar aqui a lógica para lidar com a escolha do livro
        Debug.Log("Livro selecionado: " + bookDropdown.options[bookIndex].text);
    }

    public void OnSelectButtonClicked()
    {
        // Esse método será chamado quando o botão for clicado
        // Adicione aqui a lógica para mudar de cena
        SceneTransitionManager.singleton.GoToSceneAsync(2);
    }
}
