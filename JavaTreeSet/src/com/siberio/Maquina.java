package com.siberio;

import sun.reflect.generics.tree.Tree;

import java.io.IOException;
import java.nio.file.NoSuchFileException;
import java.text.MessageFormat;
import java.util.Collections;
import java.util.LinkedList;
import java.util.TreeSet;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Maquina
{
	public TreeSet<Nodo> caminhos;

	public Maquina(String strArquivo)
	{
		caminhos = stringStreamToOptimizedList(strArquivo);
	}

	private TreeSet<Nodo> stringStreamToOptimizedList(String strArquivo)
	{
		TreeSet<Nodo> lista = new TreeSet<Nodo>();
		try
		{
			long inicio = System.nanoTime();
			Stream<String> stringStream = Leitor.lerArquivo(strArquivo);
			lista = stringStream.map(str ->
					str.split(" "))
					.filter(arrayStr -> arrayStr.length >= 4)
					.map(arrayStr -> new Nodo(
							Integer.parseInt(arrayStr[0]),
							Integer.parseInt(arrayStr[1]),
							Integer.parseInt(arrayStr[2]),
							Integer.parseInt(arrayStr[3])))
					.collect(Collectors.toCollection(TreeSet::new));

			long leitura = System.nanoTime();
			System.out.println("Tempo de leitura: " + ((leitura - inicio) / 1000000000.0) + "s");
		}
		catch (NoSuchFileException e)
		{
			System.out.println(MessageFormat.format("Arquivo {0} não encontrado.", strArquivo));
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
