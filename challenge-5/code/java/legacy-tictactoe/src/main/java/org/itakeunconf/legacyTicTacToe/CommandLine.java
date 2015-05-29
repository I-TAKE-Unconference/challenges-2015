package org.itakeunconf.legacyTicTacToe;

import java.util.Scanner;

public class CommandLine {
	private Scanner scanner;
	private String content; 

	public String getContent() {
		return content;
	}

	public CommandLine() {
		scanner = new Scanner(System.in);
		content = "";
	}
	
	int getNumber(){
		int number = scanner.nextInt();
		content += number;
		
		scanner.nextLine();
		content += "\n"; 
				
		return number;
	}

	public void print(String str) {
		content += str;
		System.out.print(str);
	}
}