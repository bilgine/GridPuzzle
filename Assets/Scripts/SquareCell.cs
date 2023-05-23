using UnityEngine;

public class SquareCell : Cell
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public override void InitializeCell()
    {
        gameObject.SetActive(true);
    }

    public override void OpenCell()
    {
        if (isOpened) return;
        spriteRenderer.color = Color.blue;
        isOpened = true;
    }

    public override void CloseCell()
    {
        spriteRenderer.color = Color.white;
        isOpened = false;
    }

    public override void SetCellDefault()
    {
        gameObject.SetActive(false);
        spriteRenderer.color = Color.white;
        isOpened = false;
    }
}