using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup 
{
    public const string RMS_GAMEMODE_SELECT = "GameModeSelect";

    public const string RMS_COLOR_SELECTED_ONE_PLAYER = "ColorSelectedOnePlayer";
    public const string RMS_TYPE_FIRST_MOVE_ONE_PLAY = "TypeFirstMoveOnePlay";
    public const string RMS_DIFFICULT_ONE_PLAY = "DifficultOnePlay";

    public const string RMS_COLOR_SELECTED_TWO_PLAYER = "ColorSelectedTwoPlayer";
    public const string RMS_TYPE_FIRST_MOVE_TWO_PLAY = "TypeFirstMoveTwoPlay";
   // public const string RMS_DIFFICULT_TWO_PLAY = "DifficultTwoPlay";

    public const string RMS_NAME_PLAYER1_SINGLE_PLAYER = "NamePlayer1Single";
    public const string RMS_NAME_PLAYER2_SINGLE_PLAYER = "NamePlayer2Single";
    public const string RMS_NAME_PLAYER1_TWO_PLAYER = "NamePlayer1TwoPlayer";
    public const string RMS_NAME_PLAYER2_TWO_PLAYER = "NamePlayer2TwoPlayer";

    public const string RMS_NUMBER_WIN = "NumberWin";
    public const string RMS_NUMBER_LOSE = "NumberLose";
    public const string RMS_NUMBER_DRAW = "NumberDraw";

    public const string RMS_SOUND="Sound";
    
    public  enum GAME_MODE{
        ONE_PLAY,TWO_PLAY
    }
    public enum COLOR_SELECT
    {
         GREEN, ORANGE, YELLOW
    }
    public enum FIRST_MOVE_TYPE
    {
        GREEN, ORANGE, YELLOW, RANDOMLY

    }
    public enum LEVEL_GAME
    {
        EASY, MEDIUM, HARD
    }
    //public bool RequestNewGameOnePlayer = false;
    //public bool RequestNewGameTwoPlayer = false;

    private string Player1ModeSinglePlayer = "Player";
    private string Player2ModeSinglePlayer = "Machine";
    private string Player1ModeTwoPlayer = "Player 1";
    private string Player2ModeTwoPlayer = "Player 2";

    private static GameSetup instance;

    private GameSetup() { }
    public static GameSetup Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameSetup();
                GameSetup.Instance.Init();

                
            }
            return instance;
        }
    }
    void Init()
    { 
        _gameModeSelected = PlayerPrefs.GetInt(RMS_GAMEMODE_SELECT,0)==0?GAME_MODE.ONE_PLAY:GAME_MODE.TWO_PLAY;

        _colorSelected = (COLOR_SELECT)PlayerPrefs.GetInt(RMS_COLOR_SELECTED_ONE_PLAYER, 0);
        _colorSelectedTwoPlayer = (COLOR_SELECT)PlayerPrefs.GetInt(RMS_COLOR_SELECTED_TWO_PLAYER, 1);

        _firstMoveType = (FIRST_MOVE_TYPE)PlayerPrefs.GetInt(RMS_TYPE_FIRST_MOVE_ONE_PLAY, 0);
        _firstMoveTypeTwoPlayer = (FIRST_MOVE_TYPE)PlayerPrefs.GetInt(RMS_TYPE_FIRST_MOVE_TWO_PLAY, 1);

        _levelGame = (LEVEL_GAME)PlayerPrefs.GetInt(RMS_DIFFICULT_ONE_PLAY,0);

        _namePlayer1ModeSinglePlayer = PlayerPrefs.GetString(RMS_NAME_PLAYER1_SINGLE_PLAYER, "Player");
        _namePlayer2ModeSinglePlayer = PlayerPrefs.GetString(RMS_NAME_PLAYER2_SINGLE_PLAYER, "Machine");
        _namePlayer1ModeTwoPlayer = PlayerPrefs.GetString(RMS_NAME_PLAYER1_TWO_PLAYER, "Player 1");
        _namePlayer2ModeTwoPlayer = PlayerPrefs.GetString(RMS_NAME_PLAYER2_TWO_PLAYER, "Player 2");

        _numberWin = PlayerPrefs.GetInt(RMS_NUMBER_WIN, 0);
        _numberLose = PlayerPrefs.GetInt(RMS_NUMBER_LOSE, 0);
        _numberDraw = PlayerPrefs.GetInt(RMS_NUMBER_DRAW, 0);

        _sound = PlayerPrefs.GetInt(RMS_SOUND, 1);

    }
    #region GAMEMODE
    private GAME_MODE _gameModeSelected = GAME_MODE.ONE_PLAY;
    public GAME_MODE GetCurrentSelectedGameMode()
    {
        return _gameModeSelected;
    }
    public void SetCurrentSelecteGameMode(GAME_MODE gameMode)
    {
        _gameModeSelected = gameMode;
        PlayerPrefs.SetInt(RMS_GAMEMODE_SELECT, _gameModeSelected==GAME_MODE.ONE_PLAY ? 0 : 1);
    }

    #endregion GAMEMODE

    #region COLOR_SELECT

    private COLOR_SELECT _colorSelected = COLOR_SELECT.GREEN;
    private COLOR_SELECT _colorSelectedTwoPlayer = COLOR_SELECT.GREEN;
    public COLOR_SELECT GetCurrentColorSelected()
    {
        return _colorSelected;
    }
    public void SetCurrentColorSelected(COLOR_SELECT colorSelected)
    {
        _colorSelected = colorSelected;
        PlayerPrefs.SetInt(RMS_COLOR_SELECTED_ONE_PLAYER, _colorSelected == COLOR_SELECT.GREEN ? 0 : 1);
    }
    public COLOR_SELECT GetCurrentColorSelectedTwoPlayer()
    {
        return _colorSelectedTwoPlayer;
    }
    public void SetCurrentColorSelectedTwoPlayer(COLOR_SELECT colorSelectedTwoPlayer)
    {
        _colorSelectedTwoPlayer = colorSelectedTwoPlayer;
        PlayerPrefs.SetInt(RMS_COLOR_SELECTED_TWO_PLAYER, _colorSelectedTwoPlayer == COLOR_SELECT.ORANGE ? 1 : 2);
    }
    #endregion
    #region FIRST_MOVE_TYPE
    private FIRST_MOVE_TYPE _firstMoveType = FIRST_MOVE_TYPE.GREEN;
    private FIRST_MOVE_TYPE _firstMoveTypeTwoPlayer = FIRST_MOVE_TYPE.GREEN;
    public FIRST_MOVE_TYPE GetCurrentFirstMoveType()
    {
        return _firstMoveType;
    }
    public FIRST_MOVE_TYPE GetCurrentFirstMoveTypeTwoPlayer()
    {
        return _firstMoveTypeTwoPlayer;
    }
    public void SetCurrentFirstMoveType(FIRST_MOVE_TYPE firstMoveType)
    {
        _firstMoveType = firstMoveType;
        PlayerPrefs.SetInt(RMS_TYPE_FIRST_MOVE_ONE_PLAY, UpdatesFirstMove());
    }
    public void SetCurrentFirstMoveTypeTwoPlayer(FIRST_MOVE_TYPE firstMoveTypeTwoPlayer)
    {
        _firstMoveTypeTwoPlayer = firstMoveTypeTwoPlayer;
        PlayerPrefs.SetInt(RMS_TYPE_FIRST_MOVE_TWO_PLAY, UpdatesFirstMove());
    }
    private int UpdatesFirstMove()
    {
        if(_firstMoveType == FIRST_MOVE_TYPE.GREEN)
        {
            return 0;
        }
        else if(_firstMoveType == FIRST_MOVE_TYPE.ORANGE)
        {
            return 1;
        }
        else if(_firstMoveType == FIRST_MOVE_TYPE.YELLOW)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    #endregion
    #region LEVEL_GAME
    private LEVEL_GAME _levelGame = LEVEL_GAME.EASY;
    public LEVEL_GAME GetCurrentLevelGame()
    {
        return _levelGame;
    }
    public void SetCurrentLevelGame(LEVEL_GAME levelGame)
    {
        _levelGame = levelGame;
        PlayerPrefs.SetInt(RMS_DIFFICULT_ONE_PLAY, _levelGame == LEVEL_GAME.EASY ? 0 : _levelGame == LEVEL_GAME.MEDIUM ? 1 : 2);
    }
    #endregion

    #region NameOfPlayer
    private string _namePlayer1ModeSinglePlayer;
    private string _namePlayer2ModeSinglePlayer;
    private string _namePlayer1ModeTwoPlayer;
    private string _namePlayer2ModeTwoPlayer;
    public string GetCurrentNamePlayer1ModeSinglePlayer()
    {
        return _namePlayer1ModeSinglePlayer;
    }
    public string GetCurrentNamePlayer2ModeSinglePlayer()
    {
        return _namePlayer2ModeSinglePlayer;
    }
    public string GetCurrentNamePlayer1ModeTwoPlayer()
    {
        return _namePlayer1ModeTwoPlayer;
    }
    public string GetCurrentNamePlayer2ModeTwoPlayer()
    {
        return _namePlayer2ModeTwoPlayer;
    }
    public void SetCurrentNamePlayer1ModeSinglePlayer(string name1SinglePlayer)
    {
        _namePlayer1ModeSinglePlayer = name1SinglePlayer;
        PlayerPrefs.SetString(RMS_NAME_PLAYER1_SINGLE_PLAYER, _namePlayer1ModeSinglePlayer);
    }
    public void SetCurrentNamePlayer2ModeSinglePlayer(string name2SinglePlayer)
    {
        _namePlayer2ModeSinglePlayer = name2SinglePlayer;
        PlayerPrefs.SetString(RMS_NAME_PLAYER2_SINGLE_PLAYER, _namePlayer2ModeSinglePlayer);
    }
    public void SetCurrentNamePlayer1ModeTwoPlayer(string name1TwoPlayer)
    {
        _namePlayer1ModeTwoPlayer = name1TwoPlayer;
        PlayerPrefs.SetString(RMS_NAME_PLAYER1_TWO_PLAYER, _namePlayer1ModeTwoPlayer);
    }
    public void SetCurrentNamePlayer2ModeTwoPlayer(string name2TwoPlayer)
    {
        _namePlayer2ModeTwoPlayer = name2TwoPlayer;
        PlayerPrefs.SetString(RMS_NAME_PLAYER2_TWO_PLAYER, _namePlayer2ModeTwoPlayer);
    }
    #endregion
    #region numberWin
    private int _numberWin;
    public void SetNumberWin(int numberWin)
    {
        _numberWin = numberWin;
        PlayerPrefs.SetInt(RMS_NUMBER_WIN, _numberWin);
    }
    public int GetNumberWin()
    {
        return _numberWin;
    }
    #endregion
    #region numberLose
    private int _numberLose;
    public void SetNumberLose(int numberLose)
    {
        _numberLose = numberLose;
        PlayerPrefs.SetInt(RMS_NUMBER_LOSE, _numberLose);
    }
    public int GetNumberLose()
    {
        return _numberLose;
    }
    #endregion
    #region numberDraw
    private int _numberDraw;
    public void SetNumberDraw(int numberDraw)
    {
        _numberDraw = numberDraw;
        PlayerPrefs.SetInt(RMS_NUMBER_DRAW, _numberDraw);
    }
    public int GetNumberDraw()
    {
        return _numberDraw;
    }
    #endregion
    #region sound
    private int _sound;
    public void SetSound(int sound)
    {
        _sound = sound;
        PlayerPrefs.SetInt(RMS_SOUND, _sound);
    }
    public int GetSound()
    {
        return _sound;
    }
    #endregion
}
