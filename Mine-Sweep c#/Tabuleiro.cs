using System;
using System.Collections;
using System.Collections.Generic;

public class Tabuleiro
{
    Celula[,] table;
    bool[,] bombs;
    List<String> opened= new List<String>();
    Random rd = new Random();
    int numBombs;
    int numCells;

    public void SetTables()
    {
        for(int a = 0; a < numCells; a++)
        {
            for(int b = 0; b < numCells; b++)
            {
                table[a,b] = new Celula(a,b);
                bombs[a,b] = false;
            }
        }
    }

    public void Show()
    {
        Console.WriteLine(opened.Count());
        for(int a = 0; a < numCells; a++)
        {
            for(int b = 0; b < numCells; b++)
            {
                Console.Write("|{0}", table[a,b].Display());
            }
            Console.Write("|\n");

            //Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", table[a,0].Display(), table[a,1].Display(), 
            //table[a,2].Display(), table[a,3].Display(), table[a,4].Display(), table[a,5].Display(), 
            //table[a,6].Display(), table[a,7].Display(), table[a,8].Display(), table[a,9].Display());
        }
        
    }

    public void SpreadOpen(int x, int y)
    {
        
        if (x-1 >= 0 && y-1 >= 0 && bombs[x-1,y-1] != true)
        {
            OpenCel(x-1,y-1);
        }
         if (x-1 >= 0 && bombs[x-1,y] != true)
        {
            OpenCel(x-1,y);
        }
         if (x-1 >= 0 && y+1 <= numCells-1 && bombs[x-1,y+1] != true)
        {
            OpenCel(x-1,y+1);
        }
         if (y-1 >= 0 && bombs[x,y-1] != true)
        {
            OpenCel(x,y-1);
        }
         if (y+1 <= numCells-1 && bombs[x,y+1] != true)
        {
            OpenCel(x,y+1);
        }
         if (x+1 <= numCells-1 && y-1 >= 0 && bombs[x+1,y-1] != true)
        {
            OpenCel(x+1,y-1);
        }
         if (x+1 <= numCells-1 && bombs[x+1,y] != true)
        {
            OpenCel(x+1,y);
        }
         if (x+1 <= numCells-1 && y+1 <= numCells-1 && bombs[x+1,y+1] != true)
        {
            OpenCel(x+1,y+1);
        }
    }

    public void SetBombs(int numBombs, int cels)
    {
        int i = 0;
        int a;
        int b;
        while(i < numBombs)
        {
            a = rd.Next(0,cels);
            b = rd.Next(0,cels);
            if(bombs[a,b] != true)
            {
                SetABomb(a,b);
            }
            else
            {
                i--;
            }
           
            i++;
        }
    }

    public void SetCelNum()
    {
        for(int a = 0; a < numCells; a++)
        {
            for(int b = 0; b < numCells; b++)
            {
                table[a,b].SetOpenDisplay(bombs, numCells);
            }
        }
    }

    public Tabuleiro(int numBombs, int numCells)
    {
        this.numBombs = numBombs;
        this.numCells = numCells;
        table = new Celula[this.numCells, this.numCells];
        bombs = new bool[this.numCells, this.numCells];
        SetTables();
        SetBombs(this.numBombs, this.numCells);
        SetCelNum();
    }

    public bool IsNull(int x, int y)
    {
        if(table[x,y].Display() == "   ")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OpenCel(int x, int y)
    {
        String a = x.ToString() + "." + y.ToString();
        if (opened.Contains(a))
        {
            return;    
        }
        else
        {     
            opened.Add(a);
            table[x,y].Open();
        }

    }

    public bool TestWin()
    {
        if (opened.Count >= numCells*numCells - numBombs)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetABomb(int a, int b)
    {
        bombs[a,b] = true;
        table[a,b].Bomba();
    }
}