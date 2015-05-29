package org.itakeunconf.legacyTicTacToe;

public class Board {
	char[] board = new char[10];

	boolean isWinner(char mark) {
		return isHorizontalComplete(mark) || isVerticalComplete(mark)
				|| isDiagonaleComplete(mark);
	}

	private boolean isDiagonaleComplete(char mark) {
		return isMainDiagonaleComplete(mark) || isSecondDiagonaleComplete(mark);
	}

	private boolean isVerticalComplete(char mark) {
		return isFirstVerticalLineComplete(mark)
				|| isSecondVerticalLineComplete(mark)
				|| isThirdVerticalLineComplete(mark);
	}

	private boolean isHorizontalComplete(char mark) {
		return isFirstHorizontalLineComplete(mark)
				|| isSecondHorizontalLineComplete(mark)
				|| isThirdHorizontalLineComplete(mark);
	}

	private boolean isSecondDiagonaleComplete(char mark) {
		return (board[3] == mark) && (board[5] == mark) && (board[7] == mark);
	}

	private boolean isMainDiagonaleComplete(char mark) {
		return (board[1] == mark) && (board[5] == mark) && (board[9] == mark);
	}

	private boolean isThirdVerticalLineComplete(char mark) {
		return (board[3] == mark) && (board[6] == mark) && (board[9] == mark);
	}

	private boolean isSecondVerticalLineComplete(char mark) {
		return (board[2] == mark) && (board[5] == mark) && (board[8] == mark);
	}

	private boolean isFirstVerticalLineComplete(char mark) {
		return (board[1] == mark) && (board[4] == mark) && (board[7] == mark);
	}

	private boolean isThirdHorizontalLineComplete(char mark) {
		return (board[7] == mark) && (board[8] == mark) && (board[9] == mark);
	}

	private boolean isSecondHorizontalLineComplete(char mark) {
		return (board[4] == mark) && (board[5] == mark) && (board[6] == mark);
	}

	private boolean isFirstHorizontalLineComplete(char mark) {
		return (board[1] == mark) && (board[2] == mark) && (board[3] == mark);
	}

	void setPositionWithMark(int number, char playerMark) {
		board[number] = playerMark;
	}

	public String toString() {
		StringBuilder sb = new StringBuilder();
		for (int i = 1; i <= getCountPositions(); i++) {
			sb.append(board[i]);
			if (i % 3 == 0)
				sb.append("\n");
		}
		return sb.toString();
	}

	int getCountPositions() {
		return 9;
	}
}
