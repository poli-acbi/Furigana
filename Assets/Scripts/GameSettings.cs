using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private readonly Dictionary<EPuzzleCategories, string> _puzzleCatDirectory = new Dictionary<EPuzzleCategories, string>();
    private int _settings;
    private const int SettingsNumber = 2;

    public enum EPairNumber
    {
        NotSet = 0,
        E10Pairs = 10,
        E15Pairs = 15,
        E20Pairs = 20,

    }

    public enum EPuzzleCategories
    {
        NotSet,
        Hiragana,
        Katakana,
    }

    public struct Settings
    {
        public EPairNumber PairsNumber;
        public EPuzzleCategories PuzzleCategory;
    }

    private Settings _gameSettings;

    public static GameSettings Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        SetPuzzleCatDirectory();
        _gameSettings = new Settings();
        ResetGameSettings();
    }

    private void SetPuzzleCatDirectory()
    {
        _puzzleCatDirectory.Add(EPuzzleCategories.Hiragana, "Hiragana");
        _puzzleCatDirectory.Add(EPuzzleCategories.Katakana, "Katakana");
    }

    public void SetPairNumber(EPairNumber Number)
    {
        if (_gameSettings.PairsNumber == EPairNumber.NotSet)
            _settings++;

        _gameSettings.PairsNumber = Number;
    }

    public void SetPuzzleCategories(EPuzzleCategories cat)
    {
        if (_gameSettings.PuzzleCategory == EPuzzleCategories.NotSet)
            _settings++;

        _gameSettings.PuzzleCategory = cat;
    }

    public EPairNumber GetPairNumber()
    {
        return _gameSettings.PairsNumber;
    }

    public EPuzzleCategories GetPuzzleCategory()
    {
        return _gameSettings.PuzzleCategory;
    }

    public void ResetGameSettings()
    {
        _settings = 0;
        _gameSettings.PuzzleCategory = EPuzzleCategories.NotSet;
        _gameSettings.PairsNumber = EPairNumber.NotSet;
    }

    public bool AllSettingsReady()
    {
        return _settings == SettingsNumber;
    }

    public string GetMaterialDirectoryName()
    {
        return "Materials/";
    }

    public string GetPuzzleCategoryTextureDirectoryName()
    {
        if(_puzzleCatDirectory.ContainsKey(_gameSettings.PuzzleCategory))
        {
            return "Images/PuzzleCat/" + _puzzleCatDirectory[_gameSettings.PuzzleCategory] + "/";
        }
        else
        {
            Debug.LogError("ERRO");
            return "";
        }
    }
}
