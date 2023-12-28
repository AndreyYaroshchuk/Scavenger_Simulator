using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LevelName { Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10, Level_11, Level_12, Level_13, Level_14, Level_15, Level_16, Level_17, Level_18, Level_19, Level_20 }

public class SaveLevel : MonoBehaviour
{
    public static SaveLevel Instan;
    public static LevelName levelName;
    public bool isClear;

    private int levelSave;

    private string timeString;

    private void Awake()
    {
        Instan = this;
    }
    private void Update()
    {
        //if (isClear)
        //{
        //    PlayerPrefs.DeleteAll();
        //}
  
    
    }
    public void SetSaveFileLevelInt(int levelNumber, int victory)
    {
        switch (levelNumber)
        {
            case 1:
                SaveBridge.ES3Save(LevelName.Level_1.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_1.ToString(), victory);
                break;
            case 2:
                SaveBridge.ES3Save(LevelName.Level_2.ToString(), victory);
                SaveBridge.SaveAllData();
                //SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_2.ToString(), victory);            
                break;
            case 3:
                SaveBridge.ES3Save(LevelName.Level_3.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_3.ToString(), victory);
                break;
            case 4:
                SaveBridge.ES3Save(LevelName.Level_4.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_4.ToString(), victory);
                break;
            case 5:
                SaveBridge.ES3Save(LevelName.Level_5.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_5.ToString(), victory);
                break;
            case 6:
                SaveBridge.ES3Save(LevelName.Level_6.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_6.ToString(), victory);
                break;
            case 7:
                SaveBridge.ES3Save(LevelName.Level_7.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_7.ToString(), victory);
                break;
            case 8:
                SaveBridge.ES3Save(LevelName.Level_8.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_8.ToString(), victory);
                break;
            case 9:
                SaveBridge.ES3Save(LevelName.Level_9.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_9.ToString(), victory);
                break;
            case 10:
                SaveBridge.ES3Save(LevelName.Level_10.ToString(), victory);
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetInt(LevelName.Level_10.ToString(), victory);
                break;
            case 11:
                //PlayerPrefs.SetInt(LevelName.Level_11.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_11.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_11.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();
                //PlayerPrefs.SetString(LevelName.Level_11.ToString() + "string", Timer.Instan.GetTimer());
                break;
            case 12:
                //PlayerPrefs.SetInt(LevelName.Level_12.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_12.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_12.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_12.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();
                break;
            case 13:
                //PlayerPrefs.SetInt(LevelName.Level_13.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_13.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_13.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_13.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();
                break;
            case 14:
                //PlayerPrefs.SetInt(LevelName.Level_14.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_14.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_14.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_14.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();
                break;
            case 15:
                //PlayerPrefs.SetInt(LevelName.Level_15.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_15.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_15.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_15.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();
                break;
            case 16:
                //PlayerPrefs.SetInt(LevelName.Level_16.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_16.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_16.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_16.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();
                break;
            case 17:
                //PlayerPrefs.SetInt(LevelName.Level_17.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_17.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_17.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_17.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();

                break;
            case 18:
                //PlayerPrefs.SetInt(LevelName.Level_18.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_18.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_18.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_18.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();

                break;
            case 19:
                //PlayerPrefs.SetInt(LevelName.Level_19.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_19.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_19.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_19.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();

                break;
            case 20:
                //PlayerPrefs.SetInt(LevelName.Level_20.ToString(), victory);
                //PlayerPrefs.SetString(LevelName.Level_20.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.ES3Save(LevelName.Level_20.ToString(), victory);
                SaveBridge.ES3Save(LevelName.Level_20.ToString() + "string", Timer.Instan.GetTimer());
                SaveBridge.SaveAllData();

                break;
        }
        
    }
    public string GetSaveFileLevelString(LevelName levelName)
    {
        
        switch (levelName)
        {
            case LevelName.Level_11:
                if (SaveBridge.ES3KeyExists(LevelName.Level_11.ToString()) == false)
                {
                    SaveBridge.ES3Save(LevelName.Level_11.ToString() + "string", "null");
                    SaveBridge.SaveAllData();
                }
                return /*PlayerPrefs.GetString(LevelName.Level_11.ToString() + "string");*/  SaveBridge.ES3Load(LevelName.Level_11.ToString() + "string", timeString);
            case LevelName.Level_12:
                return /*PlayerPrefs.GetString(LevelName.Level_12.ToString() + "string");*/  SaveBridge.ES3Load(LevelName.Level_12.ToString() + "string", timeString);
            case LevelName.Level_13:
                
                return /*PlayerPrefs.GetString(LevelName.Level_13.ToString() + "string");*/SaveBridge.ES3Load(LevelName.Level_13.ToString() + "string", timeString);
            case LevelName.Level_14:
                
                return/* PlayerPrefs.GetString(LevelName.Level_14.ToString() + "string");*/SaveBridge.ES3Load(LevelName.Level_14.ToString() + "string", timeString);
            case LevelName.Level_15:

                return /*PlayerPrefs.GetString(LevelName.Level_15.ToString() + "string");*/   SaveBridge.ES3Load(LevelName.Level_15.ToString() + "string", timeString);
            case LevelName.Level_16:
                
                return /*PlayerPrefs.GetString(LevelName.Level_16.ToString() + "string");*/SaveBridge.ES3Load(LevelName.Level_16.ToString() + "string", timeString);
            case LevelName.Level_17:
                
                return /*PlayerPrefs.GetString(LevelName.Level_17.ToString() + "string");*/SaveBridge.ES3Load(LevelName.Level_17.ToString() + "string", timeString);
            case LevelName.Level_18:
              
                return /*PlayerPrefs.GetString(LevelName.Level_18.ToString() + "string");*/   SaveBridge.ES3Load(LevelName.Level_18.ToString() + "string", timeString);
            case LevelName.Level_19:

                return /*PlayerPrefs.GetString(LevelName.Level_19.ToString() + "string");*/  SaveBridge.ES3Load(LevelName.Level_19.ToString() + "string", timeString);
            case LevelName.Level_20:
                return/* PlayerPrefs.GetString(LevelName.Level_20.ToString() + "string");*/  SaveBridge.ES3Load(LevelName.Level_20.ToString() + "string", timeString);
        }

        return "null";
    }
    public bool IsGetFile(LevelName levelName)
    {
        switch (levelName)
        {
            case LevelName.Level_11:
                if (SaveBridge.ES3KeyExists(LevelName.Level_11.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_12:
                if (SaveBridge.ES3KeyExists(LevelName.Level_12.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_13:
                if (SaveBridge.ES3KeyExists(LevelName.Level_13.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_14:
                if (SaveBridge.ES3KeyExists(LevelName.Level_14.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_15:
                if (SaveBridge.ES3KeyExists(LevelName.Level_15.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_16:
                if (SaveBridge.ES3KeyExists(LevelName.Level_16.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_17:
                if (SaveBridge.ES3KeyExists(LevelName.Level_17.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_18:
                if (SaveBridge.ES3KeyExists(LevelName.Level_18.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_19:
                if (SaveBridge.ES3KeyExists(LevelName.Level_19.ToString()) == false)
                {
                    return false;
                }
                return true;
            case LevelName.Level_20:
                if (SaveBridge.ES3KeyExists(LevelName.Level_20.ToString()) == false)
                {
                    return false;
                }
                return true;
        }
        return false;
    }
    public int GetSaveFileLevel(LevelName levelName)
    {

        switch (levelName)
        {
            case LevelName.Level_1:           
                return /*PlayerPrefs.GetInt(LevelName.Level_1.ToString());*/  SaveBridge.ES3Load(LevelName.Level_1.ToString(), levelSave);
            case LevelName.Level_2:
                return /*PlayerPrefs.GetInt(LevelName.Level_2.ToString());*/ SaveBridge.ES3Load(LevelName.Level_2.ToString(), levelSave);
            case LevelName.Level_3:
                return/* PlayerPrefs.GetInt(LevelName.Level_3.ToString());*/ SaveBridge.ES3Load(LevelName.Level_3.ToString(), levelSave);
            case LevelName.Level_4:
                return /*PlayerPrefs.GetInt(LevelName.Level_4.ToString());*/ SaveBridge.ES3Load(LevelName.Level_4.ToString(), levelSave);
            case LevelName.Level_5:
                return /*PlayerPrefs.GetInt(LevelName.Level_5.ToString());*/ SaveBridge.ES3Load(LevelName.Level_5.ToString(), levelSave);
            case LevelName.Level_6:
                return /*PlayerPrefs.GetInt(LevelName.Level_6.ToString());*/ SaveBridge.ES3Load(LevelName.Level_6.ToString(), levelSave);
            case LevelName.Level_7:
                return/* PlayerPrefs.GetInt(LevelName.Level_7.ToString());*/ SaveBridge.ES3Load(LevelName.Level_7.ToString(), levelSave);
            case LevelName.Level_8:
                return /*PlayerPrefs.GetInt(LevelName.Level_8.ToString());*/ SaveBridge.ES3Load(LevelName.Level_8.ToString(), levelSave);
            case LevelName.Level_9:
                return /*PlayerPrefs.GetInt(LevelName.Level_9.ToString());*/ SaveBridge.ES3Load(LevelName.Level_9.ToString(), levelSave);
            case LevelName.Level_10:
                return /*PlayerPrefs.GetInt(LevelName.Level_10.ToString());*/ SaveBridge.ES3Load(LevelName.Level_10.ToString(), levelSave);
            case LevelName.Level_11:
                return /*PlayerPrefs.GetInt(LevelName.Level_11.ToString());*/ SaveBridge.ES3Load(LevelName.Level_11.ToString(), levelSave);
            case LevelName.Level_12:
                return /*PlayerPrefs.GetInt(LevelName.Level_12.ToString());*/SaveBridge.ES3Load(LevelName.Level_12.ToString(), levelSave);
            case LevelName.Level_13:
                return /*PlayerPrefs.GetInt(LevelName.Level_1.ToString());*/  SaveBridge.ES3Load(LevelName.Level_13.ToString(), levelSave);
            case LevelName.Level_14:
                return /*PlayerPrefs.GetInt(LevelName.Level_2.ToString());*/ SaveBridge.ES3Load(LevelName.Level_14.ToString(), levelSave);
            case LevelName.Level_15:
                return/* PlayerPrefs.GetInt(LevelName.Level_3.ToString());*/ SaveBridge.ES3Load(LevelName.Level_15.ToString(), levelSave);
            case LevelName.Level_16:
                return /*PlayerPrefs.GetInt(LevelName.Level_4.ToString());*/ SaveBridge.ES3Load(LevelName.Level_16.ToString(), levelSave);
            case LevelName.Level_17:
                return /*PlayerPrefs.GetInt(LevelName.Level_5.ToString());*/ SaveBridge.ES3Load(LevelName.Level_17.ToString(), levelSave);
            case LevelName.Level_18:
                return /*PlayerPrefs.GetInt(LevelName.Level_6.ToString());*/ SaveBridge.ES3Load(LevelName.Level_18.ToString(), levelSave);
            case LevelName.Level_19:
                return/* PlayerPrefs.GetInt(LevelName.Level_7.ToString());*/ SaveBridge.ES3Load(LevelName.Level_19.ToString(), levelSave);
            case LevelName.Level_20:
                return /*PlayerPrefs.GetInt(LevelName.Level_8.ToString());*/ SaveBridge.ES3Load(LevelName.Level_20.ToString(), levelSave);
        }
        return 0;
    }
}
