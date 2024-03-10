using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookDisplay : MonoBehaviour
{
    public TMP_Text textDisplay;
    public Button nextButton;
    public Button prevButton;

    private Page[] pages;
    private int currentPageIndex = 0;

    [System.Serializable]
    private class Page
    {
        public int index;
        public string[] text;
    }

    [System.Serializable]
    private class Book
    {
        public Page[] pages;
    }

    void Start()
    {
        string jsonText = Resources.Load<TextAsset>("book").text;
        Book book = JsonUtility.FromJson<Book>(jsonText);
        pages = book.pages;

        if (textDisplay == null)
        {
            Debug.LogError("textDisplay is not assigned.");
            return;
        }

        if (nextButton == null)
        {
            Debug.LogError("nextButton is not assigned.");
            return;
        }

        if (prevButton == null)
        {
            Debug.LogError("prevButton is not assigned.");
            return;
        }

        if (pages == null || pages.Length == 0)
        {
            Debug.LogError("No pages found.");
            return;
        }

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
        if (textDisplay != null && pages != null && pages.Length > 0 && currentPageIndex < pages.Length)
        {
            textDisplay.text = string.Join("\n", pages[currentPageIndex].text);
            prevButton.interactable = currentPageIndex > 0;
            nextButton.interactable = currentPageIndex < pages.Length - 1;
        }
    }
}
