package org.itakeunconf.legacyTicTacToe;

/**
 * Created by claudiubar on 5/29/2015.
 */
public class TicValidator {
    char[] board;

    TicValidator(char[] board){
        this.board = board;
    }

    String testVictory(){
        StringBuilder accumulator = new StringBuilder();
        for(int idx=0; idx<3; idx++){
            accumulator.append(testLineVictory(idx)).append(testColumnVictory(idx + 1));
        }
        accumulator.append(testDiagonalVictory());
        return accumulator.toString();
    }

    private char testLineVictory(int idx){
        int pos = 2*idx + idx + 1;
        return board[pos] == board[pos+1] && board[pos+1] == board[pos+2] ? board[pos] : '\0';
    }

    private char testColumnVictory(int idx){
        return board[idx] == board[idx+3] && board[idx+3] == board[idx+6] ? board[idx] : '\0';
    }

    private char testDiagonalVictory(){
        if(board[1] == board[5] && board[5] == board[9])
            return board[1];
        if(board[3] == board[5] && board[5] == board[7])
            return board[3];
        return '\0';
    }
}
