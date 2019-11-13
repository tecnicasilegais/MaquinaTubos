package com.siberio;

public class App
{
	public static void main(String[] args)
	{
		if (args.length <= 0)
		{
			args = new String[1];
			args[0] = "input/caso1.txt";
		}
		System.out.println(new Maquina(args[0]).calcularResultado());
	}
}
