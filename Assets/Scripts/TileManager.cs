using UnityEngine;

public class TileManager : MonoBehaviour
{
    public int Width = 20;
    public int Height = 20;
    public Tile[,] Array;
    private float xOffset = 19 * 17.5f / 2;
    private float yOffset = 19 * 17.5f / 2;

    void Awake()
    {
        Array = new Tile[Width, Height];

        for(int i = 0; i < Width; i++)
        {
            for(int k = 0; k < Height; k++)
            {
                Vector3 WorldPos = new Vector3(i * 17.5f - xOffset, 0, k * 17.5f - yOffset);
                Array[i,k] = new Tile {Position = WorldPos};
                Tile tile = Array[i,k];
            }
        }
    }
    //Debug To See The Diffrent Tiles - Made with help from AI
    void OnDrawGizmos()
    {   
        //Ai made this If statement to prevent Unity from giving error messages when the game isnt being played
        if (Array == null)
            return;

        for (int i = 0; i < Width; i++)
        {
            for (int k = 0; k < Height; k++)
            {
                    Gizmos.color = Color.green;
                    //The next line was made with some help from AI.
                    Gizmos.DrawWireCube(Array[i,k].Position, Vector3.one * 0.9f);
            }
        }
    }
}

   
