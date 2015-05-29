package org.itakeunconf.legacyTicTacToe;

/**
 * Created by claudiubar on 5/29/2015.
 */
public enum Player {
    A('x'), B('o');

    private char symbol;

    private Player(char symbol){
        this.symbol = symbol;
    }
    public char getSymbol(){
        return this.symbol;
    }
}
