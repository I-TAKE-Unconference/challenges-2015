#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <assert.h>

#define MATRIX_SIZE 3
#define TABLE_SIZE 9
#define TRUE 1
#define FALSE 0

typedef enum {
	ePlayerA = 0,
	ePlayerB,
	eNumPlayers
} PlayerEnum;

static PlayerEnum table[TABLE_SIZE + 1];
static char *player_names[eNumPlayers] = {"player A", "player B"};
static char player_marks[eNumPlayers] = {'x', 'o'};

static PlayerEnum next_player(PlayerEnum player)
{
	assert(player != eNumPlayers);
	return (player == ePlayerA ? ePlayerB : ePlayerA);
}

static char *player_name(PlayerEnum player)
{
	assert(player != eNumPlayers);
	return player_names[player];
}

static char player_mark(PlayerEnum player)
{
	assert(player != eNumPlayers);
	return player_marks[player];
}

static int get_user_move(void)
{
	int move;
	scanf("%d",&move);
	return move;
}

void play(void)
{
	int i;
	float tirage = 0;
	PlayerEnum current_player;

	srand(time(NULL));
	tirage = (float)rand() / (float)RAND_MAX;

	if (tirage<0.5)
		current_player = ePlayerA;
	else
		current_player = ePlayerB;

	for (i = 1; i <= TABLE_SIZE; i++)
	{
		printf("%s:", player_name(current_player));
		table[get_user_move()] = current_player;
		current_player = next_player(current_player);
	}
}

static PlayerEnum table_value(int row, int column)
{
	return table[(row - 1) * MATRIX_SIZE + column];
}

int player_wins(PlayerEnum player)
{
	int i, j;
	int diagonal_matches = 1;
	int antidiagonal_matches = 1;
	for (i = 1; i <= MATRIX_SIZE; i++)
	{
		int row_matches = 1;
		int column_matches = 1;
		for (j = 1; j <= MATRIX_SIZE; j++)
		{
			row_matches &= (table_value(i, j) == player);
			column_matches &= (table_value(j, i) == player);
		}
		if (row_matches || column_matches)
			return TRUE;
		diagonal_matches &= (table_value(i, i) == player);
		antidiagonal_matches &= (table_value(i, MATRIX_SIZE - i + 1) == player);
	}
	return (diagonal_matches || antidiagonal_matches);
}

void eval(void)
{
	PlayerEnum player;
	int num;
	for (num = 0, player = ePlayerA; num < eNumPlayers; num++, player = next_player(player))
		if (player_wins(player))
			printf("\nthe winner is : %s\n", player_name(player));
}

void print(void)
{
	int i;
	for (i = 1; i <= TABLE_SIZE; i++)
	{
		printf(" %c", player_mark(table[i]));
		if (i % MATRIX_SIZE == 0)
			printf("\n");
	}
}

int main(int argc, char *argv[])
{ 
	play();
	eval();
	print();
}
