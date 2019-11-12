package com.siberio;

import java.io.IOException;
import java.util.ArrayList;
import java.util.stream.Stream;

public class Maquina
{
	public ArrayList<Nodo> caminhos;

	public Maquina(String strArquivo) throws IOException
	{
		caminhos = stringStreamToOptimizedList(Leitor.lerArquivo(strArquivo));
	}

	private ArrayList<Nodo> stringStreamToOptimizedList(Stream<String> strStream)
	{
		strStream.findFirst();
		return null;
	}

	public String calcularResultado()
	{
		return "";
	}
}
