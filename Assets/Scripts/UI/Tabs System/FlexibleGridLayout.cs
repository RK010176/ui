using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public int Rows;
    public int Columns;
    public Vector2 CellSize;
    public Vector2 Spacing;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float sqrRt = Mathf.Sqrt(transform.childCount);
        Rows = Mathf.CeilToInt(sqrRt);
        Columns = Mathf.CeilToInt(sqrRt);

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth / (float)Columns) - ((Spacing.x / (float)Columns) *2 );
        float cellHight = (parentHeight / (float)Rows) - ((Spacing.y / (float)Rows) * 2);

        CellSize.x = cellWidth;
        CellSize.y = cellHight;

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectTransform.childCount ; i++)
        {
            rowCount = i / Columns;
            columnCount = i % Columns;

            var item = rectChildren[i];

            var xPos = (CellSize.x * columnCount) + (Spacing.x * columnCount) ;
            var yPos = (CellSize.y * rowCount) + (Spacing.y * rowCount);

            SetChildAlongAxis(item, 0, xPos, CellSize.x);
            SetChildAlongAxis(item, 1, yPos, CellSize.y);

        }


    }

    public override void CalculateLayoutInputVertical()
    {
        

    }

    public override void SetLayoutHorizontal()
    {
        
    }

    public override void SetLayoutVertical()
    {
        
    }
}
