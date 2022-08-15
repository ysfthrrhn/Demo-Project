using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PaintingWall : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Texture2D brush;
    public Vector2Int textureArea;
    Texture2D texture;
    public Camera cam;
    public Image progressBar;
    public GameObject finishUI;
    public TextMeshProUGUI percentageText;

    void Start()
    {
        texture = new Texture2D(textureArea.x, textureArea.y, TextureFormat.ARGB32, false);
        meshRenderer.material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Paint(hit.textureCoord);
            }
        }
        PaintedPercent();
    }
    void Paint(Vector2 location)
    {
        location.x *= texture.width;
        location.y *= texture.height;
        
        Color32[] texColor32 = texture.GetPixels32();
        Color32[] brushColor32 = brush.GetPixels32();
        
        Vector2Int halfBrush = new Vector2Int(brush.width / 2, brush.height / 2);

        for(int x=0; x<brush.width; x++)
        {
            int locX = x - halfBrush.x + (int)location.x;
            if(locX < 0 || locX >= texture.width)
            {
                continue;
            }
            for(int y=0; y<brush.height; y++)
            {
                int locY = y - halfBrush.y + (int)location.y;
                if(locY < 0 || locY >= texture.height)
                {
                    continue;
                }
                if (brushColor32[x + (y * brush.width)].a > 0f)
                {
                    int locT = locX + (texture.width * locY);
                    
                    
                    if(brushColor32[x + (y * brush.width)].r > texColor32[locT].r)
                    {
                        texColor32[locT] = brushColor32[x+ (y * brush.width)];
                    }
                }
            }
        }
        texture.SetPixels32(texColor32);
        texture.Apply();
    }
    void PaintedPercent()
    {
        Color32[] texColor32 = texture.GetPixels32();
        Color32[] brushColor32 = brush.GetPixels32();
        float sizeOfWall = 384f * 384f, red = 0f;
        for(int x=0; x<texture.width; x++)
        {
            for(int y=0; y<texture.height; y++)
            {
                int locT = x + (texture.width * y);
                if (texColor32[locT].g != 205)
                {
                    red++;
                }
            }
        }
        float percantage = red / sizeOfWall * 100;
        progressBar.fillAmount = red / sizeOfWall;

        percentageText.text = percantage == 100f ? "%" + percantage : "%" + percantage.ToString("0.00");

        if (percantage > 99.95f)
        {
            finishUI.SetActive(true);
        }
    }
}
