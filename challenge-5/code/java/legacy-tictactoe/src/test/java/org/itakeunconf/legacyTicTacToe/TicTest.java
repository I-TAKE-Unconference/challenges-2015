package org.itakeunconf.legacyTicTacToe;

import org.junit.Before;
import org.junit.Test;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.PrintStream;
import java.util.*;

import static org.junit.Assert.assertEquals;

public class TicTest {

    private final String playerAWinnerMessage = "the winner is : player A";
    private final String playerBWinnerMessage = "the winner is : player B";

    public String[] whenTestCombination(List<Integer> testCombination){
        StringBuilder fullInput = new StringBuilder();
        for(Integer oneInput : testCombination){
            fullInput.append(oneInput).append("\r\n");
        }
        System.setIn(new ByteArrayInputStream(fullInput.toString().getBytes()));

        ByteArrayOutputStream out = new ByteArrayOutputStream();
        System.setOut(new PrintStream(out));

        Tic tic = new Tic();
        try {
            tic.eval();
        } catch (IOException exc){
            exc.printStackTrace();
        }

        return out.toString().split("\n");
    }

    @Test
    public void testFirst(){
        String[] outputMessage = whenTestCombination(Arrays.asList(1,2,3,4,5,6,7,8,9));

        String fistPlayerMessage = outputMessage[0].split(":")[0];
        String playerName = fistPlayerMessage.substring(fistPlayerMessage.length()-1);

        String winnerMessage = outputMessage[1];

        assertEquals(winnerMessage, playerName.equals(Player.A.name())? playerAWinnerMessage : playerBWinnerMessage);
    }
}