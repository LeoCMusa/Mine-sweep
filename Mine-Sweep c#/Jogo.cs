using System;

public abstract class Jogo
{
    static bool lose = false;
    static Tabuleiro tab = new Tabuleiro(numBombs, numCells);
    static int numBombs = 0;
    static int numCells = 0;

    static void Main(string[] args)
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao jogo Campo Minado!");
            Console.WriteLine("Gostaria de começar um novo jogo?(s/n)");
            String a = Console.ReadLine();
            if(a == "n"){break;}
            Console.Clear();
            Console.WriteLine("Ótimo!");
            Console.WriteLine("Com qual tamanho de tabuleiro você gostaria de jogar? Max de 25(ex: um tabuleiro tamanho 10 será um quadrado de 10x10)");
            numCells = Int16.Parse(Console.ReadLine());
            if (numCells > 25)
            {
                Console.WriteLine("Você excedeu o tamanho máximo do tabuleiro...");
                break;
            }
            Console.Clear();
            Console.WriteLine("E quantas bombas você gostaria de ter no seu jogo?");
            numBombs = Int16.Parse(Console.ReadLine());
            if(numBombs < numCells*numCells)
            {
                Console.Clear();
                lose = false;
                tab = new Tabuleiro(numBombs, numCells);
                while(true)
                {
                    Jogada(tab);
                    if(lose)
                    {
                        break;
                    }
                    if(tab.TestWin())
                    {
                        Win();
                        break;
                    }
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("HAHAHAHA você quer jogar com mais bombas do que espaços? Boa piada amigão, mas você vai ter que recomeçar");
            }
        }
        
    }
    
    static public void Kaboom()
    {
        lose = true;
    }

    static public void Lose()
    {
        Console.Clear();
        Console.WriteLine("       ||     ||");
        Console.WriteLine("       ||     ||");
        Console.WriteLine("       ||     ||");
        Console.WriteLine(" ");
        Console.WriteLine("   __________________");
        Console.WriteLine("  //                \\\\");
        Console.WriteLine(" //                  \\\\");
        Console.WriteLine("Você acertou uma bomba, infelizmente isso significa uma derrota para você, clique qualquer botão para recomeçar");
        Console.ReadKey();
    }

    static public void Jogada(Tabuleiro tab)
    {
        int jog = 0;
        int jog1 = 0;
        int jog2 = 0;
        Console.Clear();
        tab.Show();
        Console.WriteLine("Por favor insira a sua jogada abaixo:");
        jog = (Int16.Parse(Console.ReadLine()));
        jog1 = (jog % numCells) -1;
        jog2 = ((jog - (jog%numCells)) / numCells);
        if(jog1 < 0)
        {
            jog1 = numCells - 1;
            jog2 = jog/numCells - 1;
        }
        tab.OpenCel(jog2, jog1);
        if (lose)
        {
            Console.Clear();
            Lose();
        }
        Console.Clear();
        tab.Show();
    }

    static public void Win()
    {
        Console.Clear(); 
        Console.WriteLine("      ||     ||");
        Console.WriteLine("      ||     ||");
        Console.WriteLine("      ||     ||");
        Console.WriteLine(" ");
        Console.WriteLine("\\\\                  //");
        Console.WriteLine(" \\\\________________//");
        Console.WriteLine("");
        Console.WriteLine("Você venceu! Parabéns por achar todas as bombas! Clique qualquer botão para recomeçar");
        Console.ReadKey();
    }

    static public void SpreadOpenCicle(int x, int y)
    {

        if(tab.IsNull(x,y))
        {
            tab.SpreadOpen(x,y);
        }
        else
        {
            return;
        }
    }
    static public int SetCloseDisplay(int x, int y)
    {
        int i = 0;
        for(int a = 0; a < numCells; a++)
        {
            for(int b = 0; b < numCells; b++)
            {
                i++;
                if(a == x && b == y)
                {
                    return i;
                }
            }
        }
        return i;

    }
}