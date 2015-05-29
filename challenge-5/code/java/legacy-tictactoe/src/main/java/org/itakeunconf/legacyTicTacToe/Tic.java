package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;
import java.util.Date;
import java.util.Random;
import java.util.Scanner;

public class Tic {
    char[] tab;

    void eval() throws IOException {
        tab = new TicLoader().load();
        TicValidator validator = new TicValidator(tab);
        writePlayerVictory(validator, Player.A);
        writePlayerVictory(validator, Player.B);
    }

    private void writePlayerVictory(TicValidator validator, Player player){
        if(validator.testVictory().contains("" + player.getSymbol())){
            System.out.println("\nthe winner is : player " + player.name() +"\n");
        }
    }
}