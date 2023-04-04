using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using Managers;
using Managers.GameModes;

namespace UI
{
    public class WinUiController : UiController<WinUiController>
    {
        [SerializeField] private Button _nextButton;
        [SerializeField] private GameMode _gameMode;

        private Vector3 _buttonInitialScale;

        private void OnEnable()
        {
            _buttonInitialScale = _nextButton.transform.localScale;
            _nextButton.onClick.AddListener(NextButtonPressed);  
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(NextButtonPressed);
        }

        private void NextButtonPressed()
        {
            GameManager.instance.InitializeGameMode(_gameMode);
            Hide();
        }

        public override void Show()
        {
            base.Show();
            DOVirtual.DelayedCall(.5f, () => _nextButton.transform.DOScale(_buttonInitialScale * 1.05f, .5f).SetEase(Ease.InOutFlash).SetLoops(-1, LoopType.Yoyo));
        }
    }
}

