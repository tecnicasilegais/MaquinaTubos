package com.siberio;

import java.nio.file.NoSuchFileException;
import java.text.MessageFormat;

public class App
{
	public static void main(String[] args)
	{
		for (int i = 1; i <= 8; i++)
		{
			System.out.println("=== \t TESTE " + i + " \t ===");
			new Maquina("data/caso" + i + ".txt");
			System.out.println();
		}
	}
}
