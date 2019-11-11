package com.siberio;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.stream.Stream;

public class Leitor
{
	public static Stream<String> lerArquivo(String strArquivo) throws IOException
	{
		Stream<String> stringStream = Files.lines(Paths.get(strArquivo), StandardCharsets.US_ASCII);
		return stringStream;
	}
}
