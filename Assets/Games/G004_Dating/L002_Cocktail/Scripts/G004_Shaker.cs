using DG.Tweening;
using UnityEngine;

public class G004_Shaker : MonoBehaviour
{
    public enum Component { Icecube, Vodka, CranBerryJuice, OrangeJuice, Orange, Cherry , PeachSchnapps, None}
    public enum CompPost { Outside, Inside}
    [SerializeField] float shakeDuration;
    [SerializeField] Transform shakerTransform;
    [SerializeField] G004_ScoreSystem scoreSysl;
    public static int shakeCount = 0;

    public void Shake()
    {
        shakerTransform.DOShakePosition(shakeDuration);
        shakeCount++;
        scoreSysl.RefreshScore();
    }
}