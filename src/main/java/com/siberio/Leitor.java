package com.siberio;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;

public class Leitor
{
	public ArrayList<ArrayList<Destino>> lerGabarito(String strArquivo) throws FileNotFoundException
	{
		File arquivo = new File(strArquivo);
		try
		{
			BufferedReader br = new BufferedReader(new FileReader(arquivo));
		}
		catch (FileNotFoundException e)
		{
			e.printStackTrace();
		}
		return null;
	}
}
