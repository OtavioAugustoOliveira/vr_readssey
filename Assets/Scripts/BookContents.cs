using TMPro;
using UnityEngine;

namespace ChristinaCreatesGames.Typography.Book
{
    public class BookContents : MonoBehaviour
    {
        [TextArea(10, 20)] [SerializeField] private string content;
        [Space] [SerializeField] private TMP_Text leftSide;
        [SerializeField] private TMP_Text rightSide;
        [Space] [SerializeField] private TMP_Text leftPagination;
        [SerializeField] private TMP_Text rightPagination;

        [SerializeField] private Material cenario_1;
        [SerializeField] private Material cenario_2;
        [SerializeField] private Material cenario_3;

        private void OnValidate()
        {
            UpdatePagination();

            if (leftSide.text == content)
                return;

            SetupContent();
        }

        private void Awake()
        {
            SetupContent();
            UpdatePagination();
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

        public void PreviousPage()
        {
            if (leftSide.pageToDisplay <= 1)
            {
                return;
            }

            leftSide.pageToDisplay -= 2;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;

            UpdatePagination();
            ChangeSkybox(leftSide.pageToDisplay);
        }

        public void NextPage()
        {
            if (rightSide.pageToDisplay >= rightSide.textInfo.pageCount)
            {
                return;
            }

            leftSide.pageToDisplay += 2;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;

            UpdatePagination();
            ChangeSkybox(leftSide.pageToDisplay);
        }

        private void ChangeSkybox(int page)
        {
            if (page >= 1 && page <= 5)
            {
                RenderSettings.skybox = cenario_1;
            }
            else if (page >= 7 && page <= 9)
            {
                RenderSettings.skybox = cenario_2;
            }
            else
            {
                RenderSettings.skybox = cenario_3;
            }
        }
    }
}
