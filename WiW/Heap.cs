using System;
using System.Collections.Generic;
using tp1;

namespace tpfinal
{
	public class Heap
	{
		private List<Proceso> heap;
		private bool esMaxHeap;
		
		
		public Heap(bool esMaxHeap)
		{
			this.esMaxHeap = esMaxHeap;
			heap = new List<Proceso>();
		}
		
		
		public void BuildHeap(List<Proceso> procesos)
		{
			heap.AddRange(procesos);
            
			for (int i = (heap.Count - 1) / 2; i >= 0; i--)
			{
				RestaurarOrden(i);
			}
		}
		
		
		public void RestaurarOrden(int indice)
		{
			int indiceHijoIzquierdo = 2 * indice + 1;
			int indiceHijoDerecho = 2 * indice + 2;
			int indiceRaiz = indice;

			if (indiceHijoIzquierdo < heap.Count && Comparar(indiceHijoIzquierdo, indiceRaiz))
				indiceRaiz = indiceHijoIzquierdo;

			if (indiceHijoDerecho < heap.Count && Comparar(indiceHijoDerecho, indiceRaiz))
				indiceRaiz = indiceHijoDerecho;

			if (indiceRaiz != indice) 
			{
				Proceso aux = heap[indice];
				heap[indice] = heap[indiceRaiz];
				heap[indiceRaiz] = aux;
				RestaurarOrden(indiceRaiz);
			}
		}
		
		
		public bool Comparar(int indiceHijo, int indicePadre)
		{
			if (esMaxHeap)
				return heap[indiceHijo].prioridad > heap[indicePadre].prioridad;
			else
				return heap[indiceHijo].tiempo < heap[indicePadre].tiempo;
		}
		
		
		public Proceso Eliminar()
		{
			if (EsVacia())
			{
				throw new InvalidOperationException("La heap está vacía");
			}

			Proceso raiz = heap[0];
			heap[0] = heap[heap.Count - 1];
			heap.RemoveAt(heap.Count - 1);
			RestaurarOrden(0);

			return raiz;
		}
		
		
		public bool EsVacia()
		{
			return heap.Count == 0;
		}
		
		
		public int GetTamaño()
		{
			return heap.Count;
		}
		
		
		public List<Proceso> GetHojas()
		{
			List<Proceso> hojas = new List<Proceso>();
			int tamaño = GetTamaño();
			
			for (int i = tamaño / 2; i < tamaño; i++)
			{
				hojas.Add(heap[i]);
			}

			return hojas;
		}
		
		
		public int GetAltura()
		{
			int altura = (int)Math.Floor(Math.Log(GetTamaño())/Math.Log(2));
			
			return altura;
		}
		
		
		public string RecorrerPorNiveles()
		{
			string texto = "";
			
			Cola<Proceso> cola = new Cola<Proceso>();
			
			cola.Encolar(heap[0]);
			
			int nivel = 0;
			
			while (!cola.EsVacia())
			{
				int tamañoNivel = cola.CantidadElementos();
				
				List<Proceso> procesosEnNivelActual = new List<Proceso>();
				
				for (int i = 0; i < tamañoNivel; i++)
				{
					Proceso proceso = cola.Desencolar();
					procesosEnNivelActual.Add(proceso);
					
					int indice = heap.IndexOf(proceso);
					int indiceHijoIzquierdo = 2 * indice + 1;
					int indiceHijoDerecho = 2 * indice + 2;
					
					if (indiceHijoIzquierdo < heap.Count)
						cola.Encolar(heap[indiceHijoIzquierdo]);
					
					if (indiceHijoDerecho < heap.Count)
						cola.Encolar(heap[indiceHijoDerecho]);
				}
				
				texto += "\n\nNivel " + nivel + ":\n";
				
				foreach(Proceso elem in procesosEnNivelActual)
				{
					texto += ("\nNombre: " + elem.nombre + ", Tiempo: " + elem.tiempo + ", Prioridad " + elem.prioridad + "\n");
				}
				
				Console.WriteLine("\n*************************************************************************");
				
				nivel++;
			}
			
			return texto;
		}
	}
}