using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using Managers;
using Managers.GameModes;

namespace UI
{
    public class FailUiController : UiController<FailUiController>
    {
        [SerializeField] private Button _retryButton;
        [SerializeField] private GameMode _gameMode;

        private Vector3 _buttonInitialScale;

        private void OnEnable()
        {
            _buttonInitialScale = _retryButton.transform.localScale;
            _retryButton.onClick.AddListener(RetryButtonPressed);
        }

        private void OnDisable()
        {
            _retryButton.onClick.RemoveListener(RetryButtonPressed);
        }

        private void RetryButtonPressed()
        {
            GameManager.instance.InitializeGameMode(_gameMode);
            Hide();
        }

        public override void Show()
        {
            base.Show();
            DOVirtual.DelayedCall(.5f, () => _retryButton.transform.DOScale(_buttonInitialScale * 1.05f, .5f).SetEase(Ease.InOutFlash).SetLoops(-1, LoopType.Yoyo));
        }
    }
}

