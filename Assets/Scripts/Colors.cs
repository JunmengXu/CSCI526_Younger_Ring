using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Colors : MonoBehaviour
{
    // Player's SpriteRenderer component
    public SpriteRenderer sprite;

    /// <summary>
    /// Player's color status
    /// </summary>
    public ColorSet colorSetSelection;
    public Color currentColor;
    public Color nextColor;
    
    public int jumpTillNormal;
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
        { Color.red, "Red"},
        { Color.green, "Green" },
        { Color.blue, "Blue"}, 
        { Color.gray, "Default"}
    };

    void Start()
    {
        // Initialize the variable "currentColorSet", get the quantity of the colors in the chosen set
        InitColorSet();
        numberOfColors = selectedColorSet.Count;
        
        // Get player's current color, and generate the next color
        currentColor = sprite.color;
        nextColor = NextColor();
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
    /// Called when the player is grounded.
    /// First, use nextColor to update the player's color, then switch the player to the
    /// corresponding layer so it can collide with tiles with the same color, lastly
    /// generate a new nextColor.
    /// </summary>
    public void ChangeColorAndLayer()
    {
        sprite.color = nextColor;
        currentColor = sprite.color;

        gameObject.layer = LayerMask.NameToLayer(colorDictionary[currentColor]);

        nextColor = NextColor();
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

    // public void invince() 
    // {
    //     sprite.color = color.gray;
    //     currentColor = sprite.color;
    //     gameObject.layer = LayerMask.NameToLayer(colorDictionary[currentColor]);
    // }
}
