using UnityEngine.Events;
using UnityEngine;
public static class GlobalEvent
{
    public static event UnityAction CoinCollect;
    public static void OnCoinCollect() => CoinCollect?.Invoke();
}
