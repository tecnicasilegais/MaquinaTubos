package com.siberio;

import java.io.IOException;
import java.util.LinkedList;
import java.util.stream.Stream;

public class Maquina
{
	public LinkedList<Nodo> caminhos;

	public Maquina(String strArquivo) throws IOException
	{
		caminhos = stringStreamToOptimizedList(Leitor.lerArquivo(strArquivo));
	}

	private LinkedList<Nodo> stringStreamToOptimizedList(Stream<String> strStream)
	{
		return null;
	}

	public String calcularResultado()
	{
		return "";
	}
}
