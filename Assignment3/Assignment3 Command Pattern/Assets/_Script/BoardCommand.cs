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
        this.cells = cells;
        this.originalCells = originalCells;
        this.newCells = newCells;
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
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                cells[x, y].state = originalCells[x, y];
            }
        }
        //cells = originalCells;
    }

}
