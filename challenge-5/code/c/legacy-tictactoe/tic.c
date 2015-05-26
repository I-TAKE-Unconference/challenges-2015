#include <stdio.h>
#include <stdlib.h>


int i,a;
char tab[10];

char choice()
{
	float tirage = 0;
	srand(time(NULL));
	tirage = (float)rand() / (float)RAND_MAX;

	if (tirage<0.5)
	{for(i=1;i<=9;i++)
		{if(i%2!=0)
			{
			printf("player A:");
			scanf("%d",&a);
			tab[a]='x';
			}
		else
			{printf("player B:");
			scanf("%d",&a);
			tab[a]='o';
	}	}	}

	if (tirage>=0.5)
	{for(i=1;i<=9;i++)
		{if(i%2!=0)
			{printf("player B:");
			scanf("%d",&a);
			tab[a]='o';
			}
		else
			{printf("player A:");
			scanf("%d",&a);
			tab[a]='x';
}	}	}	}

char eval()
{
	choice();
	if ((tab[1]=='x')&&(tab[2]=='x')&&(tab[3]=='x')||
	    (tab[4]=='x')&&(tab[5]=='x')&&(tab[6]=='x')||
	    (tab[7]=='x')&&(tab[8]=='x')&&(tab[9]=='x')||
	    (tab[1]=='x')&&(tab[4]=='x')&&(tab[7]=='x')||
	    (tab[2]=='x')&&(tab[5]=='x')&&(tab[8]=='x')||
	    (tab[3]=='x')&&(tab[6]=='x')&&(tab[9]=='x')||
	    (tab[1]=='x')&&(tab[5]=='x')&&(tab[9]=='x')||
	    (tab[3]=='x')&&(tab[5]=='x')&&(tab[7]=='x'))

		printf("\nthe winner is : player A\n");

	if ((tab[1]=='o')&&(tab[2]=='o')&&(tab[3]=='o')||
	    (tab[4]=='o')&&(tab[5]=='o')&&(tab[6]=='o')||
	    (tab[7]=='o')&&(tab[8]=='o')&&(tab[9]=='o')||
	    (tab[1]=='o')&&(tab[4]=='o')&&(tab[7]=='o')||
	    (tab[2]=='o')&&(tab[5]=='o')&&(tab[8]=='o')||
	    (tab[3]=='o')&&(tab[6]=='o')&&(tab[9]=='o')||
	    (tab[1]=='o')&&(tab[5]=='o')&&(tab[9]=='o')||
	    (tab[3]=='o')&&(tab[5]=='o')&&(tab[7]=='o'))

		printf("\nthe winner is : player B\n");
}

int main(int argc, char *argv[])
{ 
	eval();
	for(i=1;i<=9;i++)
		{printf(" %c",tab[i]);
			if(i==3||i==6||i==9)
				printf("\n");
}		}
