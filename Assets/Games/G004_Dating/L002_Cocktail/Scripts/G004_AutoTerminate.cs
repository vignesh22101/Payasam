using DG.Tweening;
using UnityEngine;

public class G004_AutoTerminate : MonoBehaviour
{
    public float time = 2f;

    private void Update()
    {
        time -= Time.deltaTime;

        transform.Translate(Vector3.up*Time.deltaTime*120);

        if (time <= 0f)
            Destroy(gameObject);
    }
}