package com.siberio;

import java.util.Comparator;

public class Nodo implements Comparable<Nodo>
{
	private int canoOrigem;
	private int alturaOrigem;
	private int canoDestino;
	private int alturaDestino;

	public Nodo(int canoOrigem, int alturaOrigem, int canoDestino, int alturaDestino)
	{
		this.canoOrigem = canoOrigem;
		this.alturaOrigem = alturaOrigem;
		this.canoDestino = canoDestino;
		this.alturaDestino = alturaDestino;
	}

	public boolean equals(Nodo nodoParam)
	{
		if (this == nodoParam) { return true; }
		if (nodoParam == null || getClass() != nodoParam.getClass()) { return false; }
		if (!super.equals(nodoParam)) { return false; }
		return canoOrigem == nodoParam.canoOrigem &&
				alturaOrigem == nodoParam.alturaOrigem &&
				canoDestino == nodoParam.canoDestino &&
				alturaDestino == nodoParam.alturaDestino;
	}

	public int hashCode()
	{
		return java.util.Objects.hash(super.hashCode(), canoOrigem, alturaOrigem, canoDestino, alturaDestino);
	}

	public int getCanoOrigem()
	{
		return canoOrigem;
	}

	public int getAlturaOrigem()
	{
		return alturaOrigem;
	}

	public int getCanoDestino()
	{
		return canoDestino;
	}

	public int getAlturaDestino()
	{
		return alturaDestino;
	}

	@Override
	public String toString()
	{
		return String.format("\tNodo (\t%d\t%d\t%d\t%d)\n", canoOrigem, alturaOrigem, canoDestino, alturaDestino);
	}

	@Override
	public int compareTo(Nodo o)
	{
		return Comparator
				.comparingInt(Nodo::getCanoOrigem)
				.thenComparingInt(Nodo::getCanoDestino)
				.thenComparingInt(Nodo::getAlturaOrigem)
				.thenComparingInt(Nodo::getAlturaDestino)
				.compare(this, o);
	}
}
