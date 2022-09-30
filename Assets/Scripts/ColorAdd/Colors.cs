using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ColorAdd
{
    public class Colors : MonoBehaviour
    {
        // Player's SpriteRenderer component
        public SpriteRenderer sprite;

        /// <summary>
        /// Player's color status
        /// </summary>
        public ColorSet colorSetSelection;
        public Color currentColor;
        //public Color nextColor;

        // List of available colors
        private List<Color> colorSetOne = new()
        {
            Color.black,
            Color.white
        };
        private List<Color> colorSetTwo = new()
        {
            Color.red,
            Color.green,
            Color.blue
        };
        private int numberOfColors = 0;
        private List<Color> selectedColorSet;

        private Dictionary<Color, string> colorDictionary = new()
        {
            { Color.black, "Black" },
            { Color.white, "White" },
            { Color.red, "Red" },
            { Color.green, "Green" },
            { Color.blue, "Blue" }
        };

        private Dictionary<int, Color> touchToColorDictionary = new()
        {
            { 10, Color.white },
            { 11, Color.black },
            { 12, Color.red },
            { 13, Color.green },
            { 14, Color.blue }
        };

        void Start()
        {
            // Initialize the variable "currentColorSet", get the quantity of the colors in the chosen set
            InitColorSet();
            numberOfColors = selectedColorSet.Count;

            // Get player's current color, and generate the next color
            currentColor = sprite.color;
            //nextColor = NextColor();
        }

        private void InitColorSet()
        {
            switch (colorSetSelection)
            {
                case ColorSet.BlackAndWhite:
                    selectedColorSet = colorSetOne;
                    break;
                case ColorSet.RGB:
                    selectedColorSet = colorSetTwo;
                    break;
                default:
                    selectedColorSet = colorSetOne;
                    break;
            }
        }

        /// <summary>
        /// Change the color of object when the player touch ColorAdd object
        /// </summary>
        public void ChangeColorAndLayer(int layer)
        {
            //sprite.color = nextColor;
            //currentColor = sprite.color;

            sprite.color = touchToColorDictionary[layer];
            currentColor = sprite.color;
            gameObject.layer = LayerMask.NameToLayer(colorDictionary[currentColor]);

            //nextColor = NextColor();
        }

        /// <summary>
        /// Get a random next color
        /// </summary>
        private Color NextColor()
        {
            // Get the index of the player's current color in the List<Color> currentColorSet
            int currentColorIndex = selectedColorSet.IndexOf(sprite.color);

            // Exclude the currentColorIndex and randomly pick one from the rest
            var colorIndexRange = Enumerable.Range(0, numberOfColors).Where(i => i != currentColorIndex);
            var random = new System.Random();
            int newColorIndex = colorIndexRange.ElementAt(random.Next(0, numberOfColors - 1));

            return selectedColorSet[newColorIndex];
        }

        public enum ColorSet
        {
            BlackAndWhite,
            RGB
        };
    }
}

