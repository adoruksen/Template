using System;
using UnityEngine;

/// <summary>
/// Game Manager should inherit this class
/// </summary>
public abstract class AncientGameManager : MonoBehaviour
{
    public delegate void GameEvents();

    /// <summary>
    /// Subscribe to GameEvents if you like to know about level activity.
    /// To trigger an event, simply override and call [base.x()] one of the overriden methods (OnLevelStart).
    /// </summary>
    public static event GameEvents OnLevelStart;
    public static event GameEvents OnLevelFail;
    public static event GameEvents OnLevelComplete;

    /// <summary>
    /// Used to save level integer to PlayerPrefs
    /// </summary>
    private const string LevelSaveString = "level";

    /// <summary>
    /// Flag to control GameManager PlayerPref level saves. Set this to false to disable saving levels.
    /// Editor only.
    /// </summary>
    public bool ShouldSaveProgress = true;

    /// <summary>
    /// returns the current level. You should override this method.
    /// </summary>
    /// <returns></returns>
    public virtual int GetLevel()
    {
        Debug.LogError(" Please override this method first! ");
        throw new NotImplementedException();
    }

    /// <summary>
    /// returns the current level in a string format, such as "level_1". You should override this method.
    /// </summary>
    /// <returns></returns>
    public virtual string GetLevelString()
    {
        Debug.LogError(" Please override this method first! ");
        throw new NotImplementedException();
    }

    /// <summary>
    /// go to previous level. You should override this method.
    /// </summary>
    public virtual void PreviousLevel()
    {
        Debug.LogError(" Please override this method first! ");
        throw new NotImplementedException();
    }

    /// <summary>
    /// restarts the level. You should override this method.
    /// </summary>
    public virtual void RestartLevel()
    {
        Debug.LogError(" Please override this method first! ");
        throw new NotImplementedException();
    }

    /// <summary>
    /// Skips the level. You should override this method.
    /// mostyl used for testing purposes and ads.
    /// </summary>
    public virtual void SkipLevel()
    {
        Debug.LogError(" Please override this method first! ");
        throw new NotImplementedException();
    }

    /// <summary>
    /// Jumps to the level.You should override this method.
    /// Mostly used for testing purposes.
    /// </summary>
    /// <param name="targetLevel"></param>
    public virtual void JumpToLevel(int targetLevel)
    {
        Debug.LogError(" Please override this method first! ");
        throw new NotImplementedException();
    }

    /// <summary>
    /// override and call this method to save level as an integer.
    /// you can skip saving by setting ShouldSaveProgress to false, althought this only works in the Editor.
    /// </summary>
    /// <param name="targetLevel"></param>
    public virtual void SaveLevel(int targetLevel)
    {
        if(Application.isEditor && !ShouldSaveProgress)
        {
            Debug.Log("ShouldSaveProgress is false. Saving is disabled");
            return;
        }
        PlayerPrefs.SetInt(LevelSaveString, targetLevel);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// returns the saved level from PlayerPrefs using the constant key LevelSaveString.
    /// </summary>
    /// <returns></returns>
    public int GetSavedLevel()
    {
        return PlayerPrefs.GetInt(LevelSaveString);
    }

    /// <summary>
    /// call this method to record LevelStart event
    /// </summary>
    protected void LevelStart()
    {
        OnLevelStart?.Invoke();
    }

    /// <summary>
    /// Call this method to record LevelFail event 
    /// </summary>
    protected void LevelFail()
    {
        OnLevelFail?.Invoke();
    }

    /// <summary>
    /// Call this method to record LevelComplete event 
    /// </summary>
    protected void LevelComplete()
    {
        OnLevelComplete?.Invoke();
    }
}
