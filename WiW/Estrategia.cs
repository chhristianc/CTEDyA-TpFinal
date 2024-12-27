using System;
using System.Collections.Generic;
using System.Numerics;
using tp1;

namespace tpfinal
{
    public class Estrategia
    {
        public String Consulta1(List<Proceso> datos)
        {
        	string result = "";
        	
        	Heap minHeap = new Heap(false);
        	minHeap.BuildHeap(datos);

        	Heap maxHeap = new Heap(true);
        	maxHeap.BuildHeap(datos);
            
        	List<Proceso> hojasMinHeap = minHeap.GetHojas();
        	List<Proceso> hojasMaxHeap = maxHeap.GetHojas();

        	result += "Hojas de la MinHeap (SJF):\n\n";
            
        	foreach (Proceso hoja in hojasMinHeap)
        	{
        		result += "Nombre: " + hoja.nombre + ", Tiempo: " + hoja.tiempo + ", Prioridad: " + hoja.prioridad + "\n\n";
        	}
            
        	result += "\n\n**************************************************************\n\n";
        	result += "\nHojas de la MaxHeap (PPCSA):\n\n";
            
        	foreach (Proceso hoja in hojasMaxHeap)
        	{
        		result += "Nombre: " + hoja.nombre + ", Tiempo: " + hoja.tiempo + ", Prioridad: " + hoja.prioridad + "\n\n";
        	}

        	return result;
        }
        

        public String Consulta2(List<Proceso> datos)
        {
        	string result = "";
        	
        	Heap minHeap = new Heap(false);
        	minHeap.BuildHeap(datos);
            
        	Heap maxHeap = new Heap(true);
        	maxHeap.BuildHeap(datos);

        	int alturaMinHeap = minHeap.GetAltura();
        	int alturaMaxHeap = maxHeap.GetAltura();
            
        	result += "Altura de las Heaps:\n\n";
        	result += "Altura de la MinHeap: " + alturaMinHeap + "\n";
        	result += "Altura de la MaxHeap: " + alturaMaxHeap + "\n";
            
        	return result;
        }
        
        
        public String Consulta3(List<Proceso> datos)
        {
        	string result = "";
        	
        	Heap minHeap = new Heap(false);
        	minHeap.BuildHeap(datos);
            
        	Heap maxHeap = new Heap(true);
        	maxHeap.BuildHeap(datos);

        	result = "Procesos en Cada Nivel de la MinHeap (SJF):\n" + minHeap.RecorrerPorNiveles();
        	result += "\n\n**************************************************************\n\n\n";
        	result += "Procesos en Cada Nivel de la MaxHeap (PPCSA):\n" + maxHeap.RecorrerPorNiveles();
            	
        	return result;
        }
        
        
        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {
        	Heap minHeap = new Heap(false);
        	minHeap.BuildHeap(datos);
        	
        	while (!minHeap.EsVacia())
        	{
        		Proceso proceso = minHeap.Eliminar();
        		collected.Add(proceso);
        	}
        }
        
        
        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
        	Heap maxHeap = new Heap(true);
        	maxHeap.BuildHeap(datos);

        	while (!maxHeap.EsVacia())
        	{
        		Proceso proceso = maxHeap.Eliminar();
        		collected.Add(proceso);
        	}
        }
    }
}