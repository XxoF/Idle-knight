using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;

    [SerializeField]
    private float disappearTimer;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        textColor = textMesh.color;
        disappearTimer = 1;
    }

    public void Setup(int dmgAmount)
    {
        this.textMesh.text = dmgAmount.ToString();
    }

    private void Update()
    {
        float moveSpeed = 2f;
        transform.position += new Vector3(0, moveSpeed) * Time.deltaTime;

        // Auto destroy popup after time
        disappearTimer -= Time.deltaTime;
        if (disappearTimer <= 0)
        {
            float disapearSpeed = 3f;
            textColor.a -= disapearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a <= 0)
            {
                Destroy(gameObject);
            }

        }
    }

    public static DamagePopup Create(Vector3 position, int dmgAmount)
    {
        string dmgPrejab = "Assets/Resources/Prefabs/DmgReceivedPopup.prefab";
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(dmgPrejab);

        GameObject dmgPopupTransform = Instantiate(prefab, position, Quaternion.identity);
        DamagePopup dmgPopup = dmgPopupTransform.GetComponent<DamagePopup>();
        dmgPopup.Setup(dmgAmount);

        return dmgPopup;
    }
}
