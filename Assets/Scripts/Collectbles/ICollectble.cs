public interface ICollectble
{
    int Group { get; set; }

    bool IsBeingHeld { get; }
    bool IsPlugged { get; }

    CollectbleInfo OnCollect(PlayerInteractBehaviour player);

    void OnReceived(ICollectbleReceiver receiver);
    void OnRemovedFromReceiver();

    void Drop();
    void OnDrop(PlayerInteractBehaviour player);

    CollectbleInfo CollectbleInfo { get; set; }

}

[System.Serializable]
public struct CollectbleInfo
{
    public string animation;
    public UnityEngine.Sprite collectbleSprite;
    public UnityEngine.Vector2 localPosition;
}