using UnityEngine;

public class SpawnScannerEffect : MonoBehaviour
{
    [SerializeField] private Material scannerMaterial; // TerrainScanner�̃}�e���A��
    [SerializeField] private float maxRadius = 10f;   // �L����ő唼�a
    [SerializeField] private float speed = 5f;        // �L���鑬�x

    private float currentRadius;
    private bool isActive = false;

    void OnEnable()
    {
        // Prefab���������ꂽ�^�C�~���O�Ŕ���
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
