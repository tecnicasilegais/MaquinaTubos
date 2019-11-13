package com.siberio;

import java.io.IOException;
import java.util.Collections;
import java.util.LinkedList;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Maquina
{
	public LinkedList<Nodo> caminhos;

	public Maquina(String strArquivo)
	{
		caminhos = stringStreamToOptimizedList(strArquivo);
	}

	private LinkedList<Nodo> stringStreamToOptimizedList(String strArquivo)
	{
		LinkedList<Nodo> lista = new LinkedList<Nodo>();
		try
		{
			Stream<String> stringStream = Leitor.lerArquivo(strArquivo);
			lista = stringStream.map(str ->
					str.split(" "))
					.filter(arrayStr -> arrayStr.length >= 4)
					.map(arrayStr -> new Nodo(
							Integer.parseInt(arrayStr[0]),
							Integer.parseInt(arrayStr[1]),
							Integer.parseInt(arrayStr[2]),
							Integer.parseInt(arrayStr[3])))
					.collect(Collectors.toCollection(LinkedList::new));

			//Collections.sort(lista);
		}
		catch (IOException e)
		{
			e.printStackTrace();
		}
		return lista;
	}

	public String calcularResultado()
	{
		return caminhos.toString();
	}
}
