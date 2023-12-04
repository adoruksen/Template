
namespace InteractionSystem
{
    public interface IBeginInteract 
    {
        bool IsInteractable { get;}
        void OnInteractBegin(IInteractor interactor);
    }
}

