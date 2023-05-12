using System;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.UI;

public class UIElementsController: MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private InputField inputField;
    private SquareGrid _squareGridGenerator;

    private void Start()
    {
        GetSquareGridContainer();
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void GetSquareGridContainer()
    {
        _squareGridGenerator = ContainerManager.GetContainer(Container.Game).ServiceLocator.Resolve<SquareGrid>();
    }

    private void OnStartButtonClick()
    {
        if (string.IsNullOrEmpty(inputField.text)) return;
        _squareGridGenerator.GridReGenerate(Convert.ToInt32(inputField.text));
    }
}
