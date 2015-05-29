package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;

public class Main {
    private static final TABLE_CELL_COUNT = 9;

    public static void main(String[] args) {
        Tic tic = new Tic();

        try {
            tic.eval();
         
	   for (int i = 1; i <= TABLE_CELL_COUNT; i++) {
                System.out.print(tic.tab[i]);
                
		if (i % 3 == 0)
                    System.out.print("\n");
            }
        } catch (IOException exc){
            exc.printStackTrace();
        }
    }

}
