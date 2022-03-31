using System;
using TestAssingment.Interfaces;
using TestAssingment.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Object = UnityEngine.Object;

public class HUDInitializer: IController, IDisposable
{
    private TextMeshProUGUI _scoreHolder;
    private Image _firstElementParent;
    private Image _secondElementParent;
    private Image _resultElementParent;
    private Button _sellButton;
    private Button _exitToMainMenuButton;
    private Button _mixButton;
    private Button _emptyVileButton;
    private GameObject _gameHUD;
    private TextMeshProUGUI _objectiveField;


    public TextMeshProUGUI ScoreHolder => _scoreHolder;
    public TextMeshProUGUI ObjectiveField => _objectiveField;
    public Image FirstElementParent => _firstElementParent;
    public Image SecondElementParent => _secondElementParent;
    public Image ResultElementParent => _resultElementParent;
    public Button SellButton => _sellButton;
    public Button MixButton => _mixButton;
    public Button ExitToMainMenuButton => _exitToMainMenuButton;
    public Button EmptyVileButton => _emptyVileButton;
    
    
    public HUDInitializer(ReferenceHolder referenceHolder)
    {
        CreateHUD(referenceHolder.GameHUD);
    }

    private void CreateHUD(GameObject gameObject)
    {
        _gameHUD = Object.Instantiate(gameObject);
        var gameHUDView = _gameHUD.GetComponent<GameHUDView>();
        GetTextFields(gameHUDView);
        GetParents(gameHUDView);
        GetButtons(gameHUDView);
    }

    private void GetTextFields(GameHUDView gameHUDView)
    {
        _scoreHolder = gameHUDView.ScoreField;
        _objectiveField = gameHUDView.ObjectiveField;
    }

    private void GetParents(GameHUDView gameHUDView)
    {
        _firstElementParent = gameHUDView.FirstElementParent;
        _secondElementParent = gameHUDView.SecondElementParent;
        _resultElementParent = gameHUDView.ResultElementParent;
    }

    private void GetButtons(GameHUDView gameHUDView)
    {
        _sellButton = gameHUDView.SellButton;
        _exitToMainMenuButton = gameHUDView.ExitToMainMenuButton;
        _mixButton = gameHUDView.MixButton;
        _emptyVileButton = gameHUDView.EmptyVileButton;
    }
    
    public void Dispose()
    {
        Object.Destroy(_gameHUD);
    }
}