package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;
import java.util.Date;
import java.util.Random;
import java.util.Scanner;

public class Tic {
    char[] tab = new char[10];
    Scanner scanner;
    private Player[] players = new Player[2];
    private IFiller fillStrategy;
    private IChecker checkStrategy;

    public Tic()
    {
        scanner = new Scanner(System.in);
        players[0] = new Player("A", 'x');
        players[1] = new Player("B", 'o');
        players[0].next = players[1];
        players[1].next = players[0];
        fillStrategy = new Filler(tab, 9, players[0]);
        checkStrategy = new Checker();
    }

    void choice() throws IOException {
        tab = fillStrategy.getFilledGrid();
    }

    void eval() throws IOException {
        choice();
        checkStrategy.setNewGrid(tab);
        for (Player p : players)
            p.checkVictory(checkStrategy);
    }

    private interface Winnerable
    {
        void claimVictory();
    }

    private class Player implements Winnerable
    {
        String name;
        char mark;
        Player next;

        Player(String n, char m)
        {
            name = n;
            mark = m;
        }

        public void checkVictory(IChecker checker)
        {
            checker.checkWinner(mark, this);
        }

        public void claimVictory()
        {
            System.out.println("\nthe winner is : player " + name + "\n");
        }

        public void askForCheck()
        {
            System.out.print("player " + name + ":");
        }
    }

    private interface IFiller
    {
        char[] getFilledGrid();
    }

    private class Filler implements IFiller
    {
        private char[] grid;
        private int nbChoices;
        private Player currentPlayer;
        public Filler(char[] g, int nb, Player startingPlayer)
        {
            grid = g;
            nbChoices = nb;
            currentPlayer = startingPlayer;
        }

        public char[] getFilledGrid()
        {
            Random random = new Random(new Date().getTime());
            random.nextFloat();
            if (random.nextFloat() >= 0.5)
                nextTurn();

            for (int i = 1; i <= nbChoices; i++)
            {
                askForCheck();
                nextTurn();
            }

            return grid;
        }

        private void nextTurn()
        {
            currentPlayer = currentPlayer.next;
        }

        void askForCheck()
        {
            currentPlayer.askForCheck();
            int a = scanner.nextInt();
            scanner.nextLine();
            tab[a] = currentPlayer.mark;
        }
    }

    private interface IChecker
    {
        void setNewGrid(char[] newGrid);
        void checkWinner(char mark, Winnerable w);
    }

    private class Checker implements IChecker
    {
        private char[] grid;
        private char[][] winCombinaisons = new char[][]{
            {1, 2, 3}, {4, 5, 6}, {7, 8, 9},
            {1, 4, 7}, {2, 5, 8}, {3, 6, 9},
            {1, 5, 9}, {3, 5, 9}
        };

        public void setNewGrid(char[] newGrid)
        {
            grid = newGrid;
        }

        public void checkWinner(char mark, Winnerable w)
        {
            if (isThereAWinConditionFilled(mark))
                w.claimVictory();
        }

        private Boolean isThereAWinConditionFilled(char mark)
        {
            Boolean winner;
            for (char[] possibility : winCombinaisons)
            {
                winner = true;

                for (char position : possibility)
                    winner = winner && grid[position] == mark;

                if (winner)
                    return true;
            }
            return false;
        }
    }
}
