using UnityEngine;
using Managers.GameModes;

namespace Managers
{
    public class GameManager : AncientGameManager
    {
        public static GameManager instance;

        public static event GameEvents OnGameInitialized;
        public static event GameEvents OnGameEnded;

        [SerializeField] private GameMode _defaultGameMode;

        public Transform defaultParent;

        private GameMode _currentGameMode;

        public bool IsPlaying { get; private set; }

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            InitializeGameMode(_defaultGameMode);
        }
        public void InitializeGameMode(GameMode gameMode)
        {
            if (_currentGameMode != null) _currentGameMode.DeinitializeGameMode();
            _currentGameMode = gameMode;
            _currentGameMode.InitializeGameMode();
            LevelInitialize();
        }

        public void StartGameMode()
        {
            _currentGameMode.StartGameMode(LevelStart);
            IsPlaying = true;
        }
        public void CompleteGameMode()
        {
            LevelEnd();
            LevelComplete();
            IsPlaying = false;
            _currentGameMode.CompleteGameMode();
        }

        public override void RestartLevel()
        {
            JumpToLevel(GetSavedLevel());
        }

        public override void SkipLevel()
        {
            JumpToLevel(GetSavedLevel() + 1);
        }

        public override void JumpToLevel(int targetLevel)
        {
            SaveLevel(targetLevel);
            InitializeGameMode(_currentGameMode);
        }

        public override void PreviousLevel()
        {
            JumpToLevel(GetSavedLevel() - 1);
        }

        public void FailGameMode()
        {
            IsPlaying = false;
            _currentGameMode.FailGameMode();
            LevelEnd();
            LevelFail();
        }

        public override int GetLevel()
        {
            return GetSavedLevel();
        }

        public override string GetLevelString()
        {
            return GetLevel().ToString();
        }

        protected void LevelInitialize()
        {
            OnGameInitialized?.Invoke();
        }

        protected void LevelEnd()
        {
            OnGameEnded?.Invoke();
        }
        //public void FailTheLevel()
        //{
        //    Singleton.Instance.UIManager.DisplayFailUI();
        //    GameState = GameState.INACTIVE;
        //    //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Level" + (LevelManager.currentLevel + 1));
        //}
        //public void PassTheLevel()
        //{
        //    Singleton.Instance.UIManager.DisplayPassUI();
        //    GameState = GameState.INACTIVE;
        //    //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level" + (LevelManager.currentLevel + 1));
        //    PlayerPrefs.SetInt("currentLevel", ++LevelManager.currentLevel);
        //}
        //public void LoadNextLevel()
        //{
        //    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    Singleton.Instance.LevelManager.InitializeNextLevel();
        //}
        //public void RetryLevel()
        //{
        //    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    Singleton.Instance.LevelManager.InitializeNextLevel();
        //}
    }
}