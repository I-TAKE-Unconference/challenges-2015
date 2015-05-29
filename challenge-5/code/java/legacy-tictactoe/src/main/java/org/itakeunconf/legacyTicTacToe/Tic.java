package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.Random;
import java.util.Scanner;

public class Tic {
    String PLAYER_1_NAME = "player A";
    String PLAYER_2_NAME = "player B";
    char PLAYER_1_SYMBOL = 'x';
    char PLAYER_2_SYMBOL = 'o';
    int BOARD_SIZE = 9;
    int boardSizeSquared = (int)Math.sqrt(BOARD_SIZE);

    int i, a;
//    for making easy to accept the inputs starting from 1 to 9
    char[] gameBoard = new char[BOARD_SIZE + 1];
    Scanner scanner;

    public Tic() {
        scanner = new Scanner(System.in);
    }

    void runGame(){
        try {
            choice();
            eval();
            displayGameBoard();
        } catch (IOException exc){
            exc.printStackTrace();
        }
    }

    private void displayGameBoard(){
        for (int i = 1; i <= BOARD_SIZE; i++) {
            System.out.print(this.gameBoard[i]);
            if (i% boardSizeSquared == 0)
                System.out.print("\n");
        }
    }

    private String[] choosePlayerStartOrder(){
        Random random = new Random(new Date().getTime());
        random.nextFloat();
        String [] playerOrder = new String[2];
        if(random.nextFloat() < 0.5){
            playerOrder[0] = PLAYER_1_NAME;
            playerOrder[1] = PLAYER_2_NAME;
        }
        else{
            playerOrder[0] = PLAYER_2_NAME;
            playerOrder[1] = PLAYER_1_NAME;
        }
        return playerOrder;
    }

    private void readIndividualChoice(String playerName){
        a = scanner.nextInt();
        scanner.nextLine();
        gameBoard[a] = playerName.equals(PLAYER_1_NAME) ? PLAYER_1_SYMBOL : PLAYER_2_SYMBOL;
    }

    private void choice() throws IOException {
        String [] playerOrder = choosePlayerStartOrder();
        for (i = 1; i <= BOARD_SIZE; i++) {
            if (i % 2 != 0) {
                System.out.print(playerOrder[1] + ":");
                readIndividualChoice(playerOrder[1]);
            } else {
                System.out.print(playerOrder[0] + ":");
                readIndividualChoice(playerOrder[0]);
            }
        }
    }

    private boolean checkWinCondition(char playerSymbol) {
        return checkRowWin(playerSymbol) || checkColumnWin(playerSymbol) || checkDiagonalWin(playerSymbol);
    }

    private boolean checkRowWin(char playerSymbol){
        boolean result;
        for(int row = 0; row < boardSizeSquared; row++){
            result = true;
            int rowStart = 1 + row * boardSizeSquared;
            int rowEnd = rowStart + boardSizeSquared -1;
            for(i=rowStart; i <= rowEnd; i++){
                if (gameBoard[i]!= playerSymbol){
                    result = false;
                    break;
                }
            }
            if(result) return result;
        }
        return false;
    }

    private boolean checkColumnWin(char playerSymbol){
        boolean result;
        for(int column = 0; column < boardSizeSquared; column++){
            int columnStart = 1 + column;
            result = true;
            for(i=columnStart; i < BOARD_SIZE; i+= boardSizeSquared){
                if (gameBoard[i]!= playerSymbol){
                    result = false;
                    break;
                }
            }
            if(result) return result;
        }
        return false;
    }

    private boolean checkDiagonalWin(char playerSymbol){
        boolean result;

        Map diagonal1 = new HashMap<String,Integer>();
        diagonal1.put("start", 1);
        diagonal1.put("step", boardSizeSquared +1);

        Map diagonal2 = new HashMap<String,Integer>();
        diagonal2.put("start", boardSizeSquared);
        diagonal2.put("step", boardSizeSquared - 1);

        Map [] diagonals  = {diagonal1, diagonal2};

        for(Map diagonal:diagonals){
            int diagonalStart = (Integer)diagonal.get("start");
            int diagonalStep = (Integer)diagonal.get("step");
            result = true;
            for(i=diagonalStart; i < BOARD_SIZE; i+= diagonalStep){
                if (gameBoard[i]!= playerSymbol){
                    result = false;
                    break;
                }
            }
            if(result) return result;
        }
        return false;
    }

    void eval() throws IOException {
        if(checkWinCondition(PLAYER_1_SYMBOL)){
            System.out.println("\nthe winner is : " + PLAYER_1_NAME + "\n");
        }else if(checkWinCondition(PLAYER_2_SYMBOL)){
            System.out.println("\nthe winner is : " + PLAYER_2_NAME +"\n");
        }
    }
}