package com.siberio;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.ArrayList;

public class Leitor
{
	public ArrayList<ArrayList<Destino>> lerGabarito(String strArquivo)
	{
		File arquivo = new File(strArquivo);
		BufferedReader br = new BufferedReader(new FileReader(arquivo));
	}
}
