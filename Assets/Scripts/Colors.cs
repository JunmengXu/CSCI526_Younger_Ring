using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class Colors : MonoBehaviour
{
    // Player's SpriteRenderer component
    public SpriteRenderer sprite;

    // Player's Instance
    public Player player;
    
    /// <summary>
    /// Player's color status
    /// </summary>
    public ColorSet colorSetSelection;
    public Color currentColor;
    public Color nextColor;
    
    // List of available colors
    private List<Color> colorSetZero = new()
    {
        Color.black
    };
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
        { Color.yellow, "AllColor"}
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
            case ColorSet.Unchanged:
                selectedColorSet = colorSetZero;
                break;
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
        if(!player.isSuperStatus)
        {
            sprite.color = nextColor;
            currentColor = sprite.color;

            gameObject.layer = LayerMask.NameToLayer(colorDictionary[currentColor]);
            nextColor = NextColor();
        }
    }

    /// <summary>
    /// Called when the player get the super item.
    /// First, update the player's color to be yellow, then switch the player to the
    /// AllColor layer so it can collide with tiles with all color, lastly
    /// generate a new nextColor.
    /// </summary>
    public void HandleSuperItemColorAndLayer()
    {
        sprite.color = Color.yellow;
        currentColor = sprite.color;
        
        gameObject.layer = LayerMask.NameToLayer(colorDictionary[currentColor]);
        
        // coroutine = ItemEffect(itemDuration);
        // StartCoroutine(coroutine);
    }

    public void ExitSuperItemEffect()
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
        //If there is only one color (the color is unchanged), don't bother changing colors
        if(selectedColorSet.Count == 1) return selectedColorSet[currentColorIndex];

        // Exclude the currentColorIndex and randomly pick one from the rest
        var colorIndexRange = Enumerable.Range(0, numberOfColors).Where(i => i != currentColorIndex);
        var random = new System.Random();
        int newColorIndex = colorIndexRange.ElementAt(random.Next(0, numberOfColors - 1));
        
        return selectedColorSet[newColorIndex];
    }

    public enum ColorSet
    {
        Unchanged,
        BlackAndWhite, 
        RGB
    };
}
