using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    // https://www.youtube.com/watch?v=CGsEJToeXmA
    public class FlexibleGridLayout : LayoutGroup
    {
        public int rows;
        public int cols;
        public Vector2 cellSize;
        public Vector2 spacing;

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            float sqrRt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrRt);
            cols = Mathf.CeilToInt(sqrRt);

            var rect = rectTransform.rect;
            float parentWidth = rect.width;
            float parentHeight = rect.height;

            float cellWidth = parentWidth / cols - (spacing.x / cols) * 2;
            float cellHeight = parentHeight / rows - (spacing.y / rows) * 2;

            cellSize.x = cellWidth;
            cellSize.y = cellHeight;

            int colCount = 0;
            int rowCount = 0;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                rowCount = i / cols;
                colCount = i % cols;

                RectTransform item = rectChildren[i];

                var xPos = cellSize.x * colCount + spacing.x * colCount;
                var yPos = cellSize.y * rowCount + spacing.y * rowCount;
            
                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }
        }

        public override void CalculateLayoutInputVertical()
        {
            throw new System.NotImplementedException();
        }

        public override void SetLayoutHorizontal()
        {
            throw new System.NotImplementedException();
        }

        public override void SetLayoutVertical()
        {
            throw new System.NotImplementedException();
        }
    }
}
