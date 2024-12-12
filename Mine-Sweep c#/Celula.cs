using System;

public class Celula
{
    String closeDisplay;
    int[] space;
    String openDisplay = "ERROR";
    String display;
    bool isBomba = false;

    public void Open()
    {
        if (!isBomba)
        {
            display = openDisplay;
            Jogo.SpreadOpenCicle(space[0], space[1]);
        }
        else{Jogo.Kaboom();}
    }

    public void SetOpenDisplay(bool[,] matriz, int numCells)
    {
        int num = 0;
        int x = space[0];
        int y = space[1];

        if (x-1 >= 0 && y-1 >= 0 && matriz[x-1,y-1] == true) {num += 1;}
        if (x-1 >= 0 && matriz[x-1,y] == true) {num += 1;}
        if (x-1 >= 0 && y+1 <= numCells-1 && matriz[x-1,y+1] == true) {num += 1;}
        if (y-1 >= 0 && matriz[x,y-1] == true) {num += 1;}
        if (y+1 <= numCells-1 && matriz[x,y+1] == true) {num += 1;}
        if (x+1 <= numCells-1 && y-1 >= 0 && matriz[x+1,y-1] == true) {num += 1;}
        if (x+1 <= numCells-1 && matriz[x+1,y] == true) {num += 1;}
        if (x+1 <= numCells-1 && y+1 <= numCells-1 && matriz[x+1,y+1] == true) {num += 1;}

        if (num > 0){openDisplay = " " + num.ToString() + " ";}
        else{openDisplay = "   ";}
    }

    public void Bomba()
    {
        isBomba = true;
    }

    public Celula(int x, int y)
    {
        space = new int[2]{x, y};
        closeDisplay = Jogo.SetCloseDisplay(x, y).ToString();
        if(Jogo.SetCloseDisplay(x, y) < 10)
        {
            closeDisplay = "00" + closeDisplay;
        }
        else if(Jogo.SetCloseDisplay(x, y) < 100)
        {
            closeDisplay = "0" + closeDisplay;
        }
        display = closeDisplay;
    }

    public String Display()
    {
        return display;
    }



}