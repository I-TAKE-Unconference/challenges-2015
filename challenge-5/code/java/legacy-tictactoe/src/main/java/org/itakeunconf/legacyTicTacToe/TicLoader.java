package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;
import java.util.Date;
import java.util.Random;
import java.util.Scanner;

/**
 * Created by claudiubar on 5/29/2015.
 */
public class TicLoader {
    Scanner scanner;

    TicLoader(){
        this.scanner = new Scanner(System.in);;
    }

    char[] load() throws IOException {
        float tirage = 0;
        Random random = new Random(new Date().getTime());
        random.nextFloat();
        tirage = random.nextFloat();

        if (tirage < 0.5) {
            return loopPlayerInput(Player.A);
        } else {
            return loopPlayerInput(Player.B);
        }
    }

    private char[] loopPlayerInput(Player playerToStart){
        char[] tab = new char[10];
        for (int i = 1; i <= 9; i++) {
            if (i % 2 != 0) {
                readPlayerInput(playerToStart, tab);
            } else {
                readPlayerInput(Player.A.equals(playerToStart)? Player.B : Player.A, tab);
            }
        }
        return tab;
    }

    private void readPlayerInput(Player player, char[] tab){
        System.out.print("player " + player.name() + ":");
        int pos = scanner.nextInt();
        scanner.nextLine();
        tab[pos] = player.getSymbol();
    }
}
