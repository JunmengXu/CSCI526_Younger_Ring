using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorAdd
{
    public class ColorSphere : MonoBehaviour
    {

        public ColorSet colorSetSelection;
        private int layer;
        public Colors playerColor;

        // Start is called before the first frame update
        void Start()
        {
            switch (colorSetSelection)
            {
                case ColorSet.White:
                    layer = 10;
                    break;
                case ColorSet.Black:
                    layer = 11;
                    break;
                case ColorSet.Red:
                    layer = 12;
                    break;
                case ColorSet.Green:
                    layer = 13;
                    break;
                case ColorSet.Blue:
                    layer = 14;
                    break;
                default:
                    layer = 10;
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerColor.ChangeColorAndLayer(layer);

            }
        }

        public enum ColorSet
        {
            Black,
            White,
            Red,
            Green,
            Blue
        };
    }

}
