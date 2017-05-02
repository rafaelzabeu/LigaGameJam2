public interface ICollectbleReceiver
{
    int Group { get; set; }

    UnityEngine.GameObject GameObject { get; }
    bool CanInteract { get; }

    UnityEngine.Vector2 LocalPos { get; }

    void ReceiveCollectble(ICollectble collectble);
    void RemoveCollectble(PlayerInteractBehaviour player);
}
