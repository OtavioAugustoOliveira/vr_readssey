using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookDisplay : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public Button nextButton;
    public Button prevButton;

    private int currentPageIndex = 0;
    private string[] pages;

    void Start()
    {
        string jsonText = Resources.Load<TextAsset>("book").text;
        Book book = JsonUtility.FromJson<Book>(jsonText);
        pages = book.pages;

        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PrevPage);

        UpdatePage();
    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Length - 1)
        {
            currentPageIndex++;
            UpdatePage();
        }
    }

    public void PrevPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePage();
        }
    }

    private void UpdatePage()
    {
        textDisplay.text = pages[currentPageIndex];
        prevButton.interactable = currentPageIndex > 0;
        nextButton.interactable = currentPageIndex < pages.Length - 1;
    }

    [System.Serializable]
    private class Book
    {
        public string[] pages;
    }
}
