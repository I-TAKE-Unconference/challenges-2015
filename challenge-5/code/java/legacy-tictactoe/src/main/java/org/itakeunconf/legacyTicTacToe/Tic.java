package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;
import java.util.Date;
import java.util.Random;
import java.util.Scanner;

public class Tic {
  int i, a;
  char[] tab = new char[10];
  Scanner scanner;
  static char PlayerA = 'x';
  static char PlayerB = 'o';

  public Tic() {
    scanner = new Scanner(System.in);
  }

  void choice() throws IOException {
    float tirage = 0;
    Random random = new Random(new Date().getTime());
    random.nextFloat();
    tirage = random.nextFloat();

    if (tirage < 0.5) {
      for (i = 1; i <= 9; i++) {
        if (i % 2 != 0) {
          System.out.print("player A:");
          a = scanner.nextInt();
          scanner.nextLine();
          tab[a] = PlayerA;
        } else {
          System.out.print("player B:");
          a = scanner.nextInt();
          scanner.nextLine();
          tab[a] = PlayerB;
        }
      }
    }

    if (tirage >= 0.5) {
      for (i = 1; i <= 9; i++) {
        if (i % 2 != 0) {
          System.out.print("player B:");
          a = scanner.nextInt();
          scanner.nextLine();
          tab[a] = PlayerA;
        } else {
          System.out.print("player A:");
          a = scanner.nextInt();
          scanner.nextLine();
          tab[a] = PlayerB;
        }
      }
    }
  }

  void eval() throws IOException {
    choice();
    if (playerHasWon(PlayerA)) {
      System.out.println("\nthe winner is : player A\n");
    }
    if (playerHasWon(PlayerB)) {
      System.out.println("\nthe winner is : player B\n");
    }
  }

  private boolean playerHasWon(char player) {
    return (checkWinOnHorizontalLines(player) || checkWinOnVerticalLines(player) ||
        checkWinOnDiagonals(player));
  }

  private boolean checkWinOnDiagonals(char player) {
    return (tab[1] == player) && (tab[5] == player) && (tab[9] == player) ||
        (tab[3] == player) && (tab[5] == player) && (tab[7] == player);
  }

  private boolean checkWinOnHorizontalLines(char player) {
    return (tab[1] == player) && (tab[2] == player) && (tab[3] == player) ||
        (tab[4] == player) && (tab[5] == player) && (tab[6] == player) ||
        (tab[7] == player) && (tab[8] == player) && (tab[9] == player);
  }

  private boolean checkWinOnVerticalLines(char player) {
    return (tab[1] == player) && (tab[4] == player) && (tab[7] == player) ||
        (tab[2] == player) && (tab[5] == player) && (tab[8] == player) ||
        (tab[3] == player) && (tab[6] == player) && (tab[9] == player);
  }

}