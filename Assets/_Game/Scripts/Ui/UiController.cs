using UnityEngine;
using DG.Tweening;

namespace UI
{
    public class UiController<T> : GenericSingleton<T> where T : MonoBehaviour
    {
        [SerializeField] protected GameObject _gameObj;

        /// <summary>
        /// animation show
        /// </summary>
        public virtual void Show()
        {
            _gameObj.transform.localScale = Vector3.zero;
            _gameObj.SetActive(true);
            _gameObj.transform.DOScale(Vector3.one, .5f);
        }

        /// <summary>
        /// animation hide
        /// </summary>
        public virtual void Hide()
        {
            _gameObj.transform.DOScale(Vector3.zero, .5f).OnComplete(() => _gameObj.SetActive(false));
        }

        /// <summary>
        /// instant show
        /// </summary>
        public virtual void ShowInstant()
        {
            _gameObj.SetActive(true);
        }

        /// <summary>
        /// instant hide
        /// </summary>
        public virtual void HideInstant()
        {
            _gameObj.SetActive(false);
        }
    }
}