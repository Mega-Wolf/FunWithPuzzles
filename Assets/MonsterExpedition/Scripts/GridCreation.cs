using System.Collections;
using UnityEngine;
using UnityEditor;

using static Tobi.MathsAdditions;

[ExecuteInEditMode]
public class GridCreation : MonoBehaviour {
    
    [SerializeField]
    private int Width;

    [SerializeField]
    private int Height;

    [SerializeField]
    private Color AverageColor;

    [SerializeField]
    private GameObject PrefabTile;

    private void OnValidate() {
        // NOTE(Tobi): I could only destroy the ones that I don't need but those Tiles don't have references anyway
        for (int child_i = transform.childCount; --child_i >= 0; ) {
            UnityEditor.EditorApplication.delayCall += () => DestroyImmediate(transform.GetChild(0).gameObject);
        }

        float h;
        float s;
        float v;
        Color.RGBToHSV(AverageColor, out h, out s, out v);

        for (int y_i = 0; y_i < Height; ++y_i) {
            for (int x_i = 0; x_i < Width; ++x_i) {
                GameObject generatedObject = (GameObject) PrefabUtility.InstantiatePrefab(PrefabTile, transform);
                generatedObject.transform.position = new Vector3(x_i, y_i, 0);
                SpriteRenderer spriteRenderer = generatedObject.GetComponent<SpriteRenderer>();
                
                spriteRenderer.color = Color.HSVToRGB(
                    RandomGaussianMeanDev(h, 0.05f),
                    RandomGaussianMeanDev(s, 0.05f),
                    RandomGaussianMeanDev(v, 0.05f)
                );
            }
        }
    }

}
