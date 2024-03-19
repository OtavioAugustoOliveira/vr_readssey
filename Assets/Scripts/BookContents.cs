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

        [SerializeField] private Material cenario_inicial;
        [SerializeField] private Material cenario_1;
        [SerializeField] private Material cenario_2;
        [SerializeField] private Material cenario_3;

        [SerializeField] private Material cenario_4;
        [SerializeField] private Material cenario_5;
        [SerializeField] private Material cenario_6;

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
            if (page >= 1 && page <= 3)
            {
                RenderSettings.skybox = cenario_inicial;
            }
             else if (page >= 5 && page <= 9)
            {
                RenderSettings.skybox = cenario_1;
            }
            else if (page >= 11 && page <= 43)
            {
                RenderSettings.skybox = cenario_2;
            }
            else if (page >= 45 && page <= 69)
            {
                RenderSettings.skybox = cenario_3;
            }
            else if (page >= 71 && page <= 85)
            {
                RenderSettings.skybox = cenario_4;
            }
            else if (page >= 87 && page <= 107)
            {
                RenderSettings.skybox = cenario_5;
            }
            else
            {
                RenderSettings.skybox = cenario_6;
            }
        }
    }
}
