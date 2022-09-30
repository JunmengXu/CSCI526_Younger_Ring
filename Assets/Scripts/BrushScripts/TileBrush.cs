using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BrushScripts
{
    public class TileBrush : MonoBehaviour
    {
        public Sprite square;
        public Sprite noColor;
        
        public Player player;
        public Colors playerColor;

        public int brushes;
        public TMP_Text brushesText;
        
        private Dictionary<Color, string> colorDictionary = new()
        {
            { Color.black, "Black" },
            { Color.white, "White" }
        };
        
        private Queue<GameObject> brushedTiles = new();

        private void Start()
        {
            UpdateBrushesText();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetAllTiles();
            }
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("NoColorTile") && player.GetVelocity() <= 0)
            {
                if (brushes > 0)
                {
                    brushedTiles.Enqueue(col.gameObject);
                    col.gameObject.GetComponent<SpriteRenderer>().color = playerColor.currentColor;
                    col.gameObject.GetComponent<SpriteRenderer>().sprite = square;
                    col.gameObject.layer = LayerMask.NameToLayer(colorDictionary[playerColor.currentColor]);
                    col.gameObject.tag = "Tile";
                    brushes -= 1;
                    UpdateBrushesText();
                }
            }
        }

        void ResetAllTiles()
        {
            int length = brushedTiles.Count;
            for (int i = 0; i < length; i++)
            {
                ResetTile();
            }
        }

        void ResetTile()
        {
            GameObject noColorTile = brushedTiles.Dequeue();
            
            brushes += 1;
            noColorTile.tag = "NoColorTile";
            noColorTile.layer = LayerMask.NameToLayer("NoColor");
            noColorTile.GetComponent<SpriteRenderer>().sprite = noColor;
            noColorTile.GetComponent<SpriteRenderer>().color = Color.white;
            UpdateBrushesText();
        }

        void UpdateBrushesText()
        {
            brushesText.text = "Magic Brushes: " + brushes;
        }

    }
}
