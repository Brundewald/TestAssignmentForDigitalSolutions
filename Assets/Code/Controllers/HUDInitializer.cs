using System;
using TestAssingment.Interfaces;
using TestAssingment.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class HUDInitializer: IController, IDisposable
{
    private readonly Transform _parent;
    private TextMeshProUGUI _scoreHolder;
    private Transform _firstElementParent;
    private Transform _secondElementParent;
    private Transform _resultElementParent;
    private Button _sellButton;
    private Button _exitToMainMenuButton;
    private Button _mixButton;
    private GameObject _gameHUD;
    private Camera _camera;

    public Transform FirstElementParent => _firstElementParent;
    public Transform SecondElementParent => _secondElementParent;
    public Transform ResultElementParent => _resultElementParent;
    public Button SellButton => _sellButton;

    public Button MixButton => _mixButton;
    public Button ExitToMainMenuButton => _exitToMainMenuButton;

    public HUDInitializer(ReferenceHolder referenceHolder)
    {
        CreateHUD(referenceHolder.GameHUD);
        _parent = referenceHolder.Parent;
    }

    private void CreateHUD(GameObject gameObject)
    {
        _gameHUD = Object.Instantiate(gameObject);
        var gameHUDView = _gameHUD.GetComponent<GameHUDView>();
        _scoreHolder = gameHUDView.ScoreField;
        GetParents(gameHUDView);
        GetButtons(gameHUDView);
        _camera = gameHUDView.CameraHUD;
        _camera.transform.SetParent(_parent);
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
    }

    public void Dispose()
    {
        Object.Destroy(_gameHUD);
        Object.Destroy(_camera);
    }
}