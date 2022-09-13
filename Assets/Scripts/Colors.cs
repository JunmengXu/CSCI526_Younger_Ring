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
    public Color currentColor;
    public Color nextColor;
    
    // List of available colors
    private List<Color> colors = new()
    {
        Color.red,
        Color.green,
        Color.blue
    };
    private int numberOfColors = 0;
    
    void Start()
    {
        numberOfColors = colors.Count;
        
        // Get player's current color, and generate the next color
        currentColor = sprite.color;
        nextColor = NextColor();
    }

    /// <summary>
    /// Called when the player is grounded.
    /// First, use nextColor to update the player's color, then generate a new nextColor
    /// </summary>
    public void ChangeColor()
    {
        sprite.color = nextColor;
        currentColor = sprite.color;
        nextColor = NextColor();
    }

    /// <summary>
    /// Get a random next color
    /// </summary>
    private Color NextColor()
    {
        // Get the index of the player's current color in the List<Color> colors
        int currentColorIndex = colors.IndexOf(sprite.color);
        
        // Exclude the currentColorIndex and randomly pick one from the rest
        var colorIndexRange = Enumerable.Range(0, numberOfColors).Where(i => i != currentColorIndex);
        var random = new System.Random();
        int newColorIndex = colorIndexRange.ElementAt(random.Next(0, numberOfColors - 1));
        
        return colors[newColorIndex];
    }
}
