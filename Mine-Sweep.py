import random

def bomb(bombas, roll):
    celist = []
    for a in range(0, 10):
        for b in range(0, 10):
            celist.append(roll[a][b])
    quant = int(input("Quantas bombas você quer no seu jogo?: "))
    for c in range(0, quant):
        a = True
        while a:
            ale = (random.choice(celist))
            if ale not in bombas:
                bombas.append(ale)
                a = False


def tab(roll):
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[0][0], roll[0][1], roll[0][2], roll[0][3], roll[0][4], roll[0][5], roll[0][6], roll[0][7], roll[0][8], roll[0][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[1][0], roll[1][1], roll[1][2], roll[1][3], roll[1][4], roll[1][5], roll[1][6], roll[1][7], roll[1][8], roll[1][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[2][0], roll[2][1], roll[2][2], roll[2][3], roll[2][4], roll[2][5], roll[2][6], roll[2][7], roll[2][8], roll[2][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[3][0], roll[3][1], roll[3][2], roll[3][3], roll[3][4], roll[3][5], roll[3][6], roll[3][7], roll[3][8], roll[3][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[4][0], roll[4][1], roll[4][2], roll[4][3], roll[4][4], roll[4][5], roll[4][6], roll[4][7], roll[4][8], roll[4][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[5][0], roll[5][1], roll[5][2], roll[5][3], roll[5][4], roll[5][5], roll[5][6], roll[5][7], roll[5][8], roll[5][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[6][0], roll[6][1], roll[6][2], roll[6][3], roll[6][4], roll[6][5], roll[6][6], roll[6][7], roll[6][8], roll[6][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[7][0], roll[7][1], roll[7][2], roll[7][3], roll[7][4], roll[7][5], roll[7][6], roll[7][7], roll[7][8], roll[7][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[8][0], roll[8][1], roll[8][2], roll[8][3], roll[8][4], roll[8][5], roll[8][6], roll[8][7], roll[8][8], roll[8][9]))
    print("——   ——   ——   ——   ——   ——   ——   ——   ——   ——")
    print("{} | {} | {} | {} | {} | {} | {} | {} | {} | {}".format(roll[9][0], roll[9][1], roll[9][2], roll[9][3], roll[9][4], roll[9][5], roll[9][6], roll[9][7], roll[9][8], roll[9][9]))

def jogo():
    while True:
        ini = input("Você quer começar um novo jogo?(s/n): ")
        if ini == "n":
            break
        
        roll0 = ["00", "01", "02", "03", "04", "05", "06", "07", "08", "09"]
        roll1 = ["10", "11", "12", "13", "14", "15", "16", "17", "18", "19"]
        roll2 = ["20", "21", "22", "23", "24", "25", "26", "27", "28", "29"]
        roll3 = ["30", "31", "32", "33", "34", "35", "36", "37", "38", "39"]
        roll4 = ["40", "41", "42", "43", "44", "45", "46", "47", "48", "49"]
        roll5 = ["50", "51", "52", "53", "54", "55", "56", "57", "58", "59"]
        roll6 = ["60", "61", "62", "63", "64", "65", "66", "67", "68", "69"]
        roll7 = ["70", "71", "72", "73", "74", "75", "76", "77", "78", "79"]
        roll8 = ["80", "81", "82", "83", "84", "85", "86", "87", "88", "89"]
        roll9 = ["90", "91", "92", "93", "94", "95", "96", "97", "98", "99"]
        roll = [roll0, roll1, roll2, roll3, roll4, roll5, roll6, roll7, roll8, roll9]
        bombas = []
        clicados = []
        liber = []

        bomb(bombas, roll)

        for a in range(0, 10):
            lista = []
            for b in range(0, 10):
                lista.append(teste(roll[a][b], bombas, clicados, roll))
            liber.append(lista)
            
        while True:
            tab(roll)
            play = input("Digite o número da cédula que quer selecionar(ex: 00)")
            num = play[0:2]
            if num not in bombas:    
                clicados.append(num)
                roll[int(play[0])][int(play[1])] = liber[int(play[0])][int(play[1])]
                if liber[int(play[0])][int(play[1])] == "  ":
                    Spread(liber, clicados, bombas, roll)

            if clicados == 100 - len(bombas):
                print("Você venceu! Conseguiu escavar todas as cédulas sem atingir nenhuma bomba!")
                break

            if num in bombas:
                        print("Você perdeu! Infelizmente você atingiu uma bomba, na cédula {}".format(num))
                        break

def teste(num, bombas, clicados, roll):
    if num not in bombas:
        controle = []
        env = 0
        f = int(num[0])
        c = int(num[1])
        if f-1 >= 0 and c-1 >=0:
            if roll[f-1][c-1] in bombas:
                env += 1

        if f-1 >= 0:
            if roll[f-1][c] in bombas:
                env += 1 

        if f-1 >= 0 and c+1 <= 9:
            if roll[f-1][c+1] in bombas:
                env += 1

        if c-1 >= 0:
            if roll[f][c-1] in bombas:
                env += 1

        if c+1 <= 9:
            if roll[f][c+1] in bombas:
                env += 1

        if f+1 <= 9 and c-1 >= 0:
            if roll[f+1][c-1] in bombas:
                env += 1

        if f+1 <= 9:
            if roll[f+1][c] in bombas:
                env += 1

        if f+1 <= 9 and c+1 <= 9:
            if roll[f+1][c+1] in bombas:
                env += 1
        
        if env == 0:
            return("  ")
        
        else:
            return(str(env) + " ")
    else:
        env = 0
        return("B" + " ")

def Spread(liber, clicados, bombas, roll):
    fir = 0
    sec = 10
    for f in range(fir, sec):
        for c in range(fir, sec):
            env = False
            n = roll[f][c]
            if n not in bombas:
                    if n not in clicados:
                        if f-1 >= 0 and c-1 >=0:
                            if liber[f-1][c-1] == "  " and str(f-1)+str(c-1) in clicados:
                                env = True
                        if f-1 >= 0:
                            if liber[f-1][c] == "  " and str(f-1)+str(c) in clicados:
                                env = True
                        if f-1 >= 0 and c+1 <= 9:
                            if liber[f-1][c+1] == "  " and str(f-1)+str(c+1) in clicados:
                                env = True
                        if c-1 >= 0:
                            if liber[f][c-1] == "  " and str(f)+str(c-1) in clicados:
                                env = True
                        if c+1 <= 9:
                            if liber[f][c+1] == "  " and str(f)+str(c+1) in clicados:
                                env = True
                        if f+1 <= 9 and c-1 >= 0:
                            if liber[f+1][c-1] == "  " and str(f+1)+str(c-1) in clicados:
                                env = True
                        if f+1 <= 9:
                            if liber[f+1][c] == "  " and str(f+1)+str(c) in clicados:
                                env = True
                        if f+1 <= 9 and c+1 <= 9:
                            if liber[f+1][c+1] == "  " and str(f+1)+str(c+1) in clicados:
                                env = True

                        if env:
                            clicados.append(n)
                            roll[f][c] = liber[f][c]

jogo()
