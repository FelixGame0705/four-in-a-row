using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSetup
{
    public enum BOARDTYPE
    {
        Wood, Plastic
    }
    private string RMS_BOARD = "KeyBoard";
    private string RMS_SOUND = "Sound";
    private static OptionSetup instance;
    private OptionSetup() { }
    public static OptionSetup Instance
    {
        get {
            if (instance == null)
            {
                instance = new OptionSetup();
                OptionSetup.Instance.Init();
            }
            return instance;
        }
    }
    private void Init()
    {

    }
    #region BoardType
    public BOARDTYPE _boardType;
    public void SetBoardType(BOARDTYPE boardType)
    {
        _boardType = boardType;
        PlayerPrefs.SetInt(RMS_BOARD, _boardType==BOARDTYPE.Wood?0:1); 

    }
    public BOARDTYPE GetBoardType()
    {
        return _boardType;
    }
   
    #endregion


}
