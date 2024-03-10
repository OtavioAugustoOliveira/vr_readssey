using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace ChristinaCreatesGames.Typography.Book
{
    public class BookContents : MonoBehaviour
    {
        [TextArea(10, 20)] [SerializeField] private string content;
        [Space] [SerializeField] private TMP_Text leftSide;
        [SerializeField] private TMP_Text rightSide;
        [Space] [SerializeField] private TMP_Text leftPagination;
        [SerializeField] private TMP_Text rightPagination;

        private void Awake()
        {
            SetupContent();
            UpdatePagination();

            CreateButtons();
        }

        private void SetupContent()
        {
            leftSide.text = content;
            rightSide.text = content;
        }

        private void UpdatePagination()
        {
            leftPagination.text = leftSide.pageToDisplay.ToString();
            rightPagination.text = rightSide.pageToDisplay.ToString();
        }

        private void CreateButtons()
        {
            GameObject canvas = GameObject.Find("Canvas"); // Nome do seu Canvas
            GameObject buttonContainer = new GameObject("ButtonContainer");
            buttonContainer.transform.SetParent(canvas.transform, false);

            Button previousButton = CreateButton("PreviousButton", new Vector2(-100f, 0f));
            previousButton.onClick.AddListener(PreviousPage);

            Button nextButton = CreateButton("NextButton", new Vector2(100f, 0f));
            nextButton.onClick.AddListener(NextPage);
        }

        private Button CreateButton(string name, Vector2 anchoredPosition)
        {
            GameObject buttonGO = new GameObject(name);
            buttonGO.transform.SetParent(GameObject.Find("ButtonContainer").transform, false);

            RectTransform rectTransform = buttonGO.AddComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 50);
            rectTransform.anchoredPosition = anchoredPosition;

            Button button = buttonGO.AddComponent<Button>();
            button.onClick.AddListener(() => { Debug.Log("Button clicked: " + name); });

            return button;
        }

        public void PreviousPage()
        {
            // Lógica para ir para a página anterior
            Debug.Log("Página anterior");
        }

        public void NextPage()
        {
            // Lógica para ir para a próxima página
            Debug.Log("Próxima página");
        }
    }
}
