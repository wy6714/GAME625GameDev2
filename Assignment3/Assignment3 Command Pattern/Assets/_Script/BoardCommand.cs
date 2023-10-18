using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCommand : Command
{
    int[,] originalCells;
    Cell[,] cells;
    int[,] newCells;
    int rows = 20;
    int columns = 20;

    public BoardCommand(Cell[,] cells, int[,] originalCells, int[,] newCells)
    {
        //deep copy array
        //this.cells = cells;
        //this.originalCells = originalCells;
        //this.newCells = newCells;
        this.cells = new Cell[rows, columns];
        this.originalCells = new int[rows, columns];
        this.newCells = new int[rows, columns];
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                this.cells[x, y] = cells[x, y];
                this.originalCells[x, y] = originalCells[x, y];
                this.newCells[x, y] = newCells[x, y];
            }
        }

    }

    public override void Execute()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                cells[x, y].state = newCells[x,y];
            }
        }

        //cells = newCells;
    }

    public override void Undo()
    {
        string printText = "";
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                printText += originalCells[x, y].ToString();
                cells[x, y].state = originalCells[x, y];
                cells[x, y].UpdateColor();
            }
        }
        Debug.Log(printText);
        //cells = originalCells;
    }

}
