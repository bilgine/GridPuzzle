using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIElementsController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private InputField inputField;
    private SquareGrid _squareGridGenerator;


    [Inject]
    public void Construct(SquareGrid squareGrid)
    {
        _squareGridGenerator = squareGrid;
    }

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        if (string.IsNullOrEmpty(inputField.text)) return;
        _squareGridGenerator.GridReGenerate(Convert.ToInt32(inputField.text));
    }
}