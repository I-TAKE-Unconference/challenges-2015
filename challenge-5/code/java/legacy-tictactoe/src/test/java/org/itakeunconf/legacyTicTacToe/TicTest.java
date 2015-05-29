package org.itakeunconf.legacyTicTacToe;

import java.io.ByteArrayInputStream;
import java.io.InputStream;

import junit.framework.Assert;

import org.apache.commons.lang.StringUtils;
import org.junit.Test;

public class TicTest {

	@Test
	public void eval_validDataIncremental_boardCorrect() {
		String output = runWith("1\n2\n3\n4\n5\n6\n7\n8\n9\n").commandLine.getContent();
		String expected = "xox\noxo\nxox\n";
		String expectedReverse = expected.replaceAll("x", "1").replaceAll("o", "x").replaceAll("1", "o");
		Assert.assertTrue(StringUtils.countMatches(output, expected) == 1 || StringUtils.countMatches(output, expectedReverse) == 1);
	}

	@Test
	public void eval_validDataIncremental_noWinner() {
		String output = runWith("1\n5\n2\n3\n7\n4\n6\n8\n9\n").commandLine.getContent();
		Assert.assertTrue(StringUtils.countMatches(output, "winner") == 0);
	}

	@Test
	public void eval_validDataTwoCorrectLines_twoWinners() {
		String output = runWith("1\n4\n2\n5\n3\n6\n7\n8\n9\n").commandLine.getContent();
		Assert.assertTrue(StringUtils.countMatches(output, "winner") == 2);
	}

	@Test
	public void eval_sameValidNumber_noWinners() {
		String output = runWith("1\n1\n1\n1\n1\n1\n1\n1\n1\n").commandLine.getContent();
		Assert.assertTrue(StringUtils.countMatches(output, "winner") == 0);
	}

	@Test(expected = Exception.class)
	public void eval_numberNotInRange_exceptionThrown() {
		runWith("12\n1\n1\n1\n1\n1\n1\n1\n1\n").commandLine.getContent();
		Assert.fail();
	}

	@Test
	public void eval_numberZero_noWinner() {
		String output = runWith("0\n0\n0\n0\n0\n0\n0\n0\n0\n").commandLine.getContent();
		Assert.assertTrue(StringUtils.countMatches(output, "winner") == 0);
	}

	@Test(expected = Exception.class)
	public void eval_nonNumeric_exceptionThrown() {
		runWith("aaaaa\n").commandLine.getContent();
		Assert.fail();
	}

	@Test(expected = Exception.class)
	public void eval_novalue_exceptionThrown() {
		runWith("\n\n").commandLine.getContent();
		Assert.fail();
	}

	private Tic runWith(String data) {
		InputStream stdin = System.in;
		try {
			System.setIn(new ByteArrayInputStream(data.getBytes()));
			Tic tic = new Tic();
			tic.eval();
			return tic;
		} finally {
			System.setIn(stdin);
		}
	}
}
