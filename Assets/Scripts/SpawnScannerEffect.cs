using UnityEngine;

public class SpawnScannerEffect : MonoBehaviour
{
    [SerializeField] private Material scannerMaterial; // TerrainScannerのマテリアル
    [SerializeField] private float maxRadius = 10f;   // 広がる最大半径
    [SerializeField] private float speed = 5f;        // 広がる速度

    private float currentRadius;
    private bool isActive = false;

    void OnEnable()
    {
        // Prefabが生成されたタイミングで発動
        if (scannerMaterial != null)
        {
            scannerMaterial.SetVector("_RevealOrigin", transform.position);
            scannerMaterial.SetFloat("_Radius", 0f);
            isActive = true;
            currentRadius = 0f;
        }
    }

    void Update()
    {
        if (isActive)
        {
            currentRadius += Time.deltaTime * speed;
            scannerMaterial.SetFloat("_Radius", currentRadius);

            if (currentRadius >= maxRadius)
            {
                isActive = false;
            }
        }
    }
}
