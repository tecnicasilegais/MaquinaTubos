package com.siberio;

import java.io.IOException;

public class App
{
	public static void main(String[] args)
	{
		if (args.length <= 0)
		{
			throw new IllegalArgumentException("Informar o nome do arquivo txt");
		}
		else
		{
			try
			{
				System.out.println(new Maquina(args[0]).calcularResultado());
			}
			catch (IOException ex)
			{
				System.out.println(ex.getMessage());
			}
		}
	}
}
