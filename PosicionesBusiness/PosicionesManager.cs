using PosicionesNegocio.Models;
using System.Linq;
using System.Collections;
using PosicionesDatos;
using System;
using System.Collections.Generic;

namespace PosicionesNegocio
{
    public class PosicionesManager
    {
        public RespuestaBusqueda TraerPosiciones(ParamBusqueda oParam)
        {
            RespuestaBusqueda modelo = new RespuestaBusqueda();

            if (string.IsNullOrEmpty(oParam.Palabra))
            {
                modelo.Errores = "La palabra a buscar no puede estar vacía.";
                return modelo;
            }

            if (oParam.Palabra.Length > 10)
            {
                modelo.Errores = "La palabra a buscar no puede exceder los 10 caracteres.";
                return modelo;
            }

            
                PosicionesEntitiesRepositorio<Palabras> Palabras = new PosicionesEntitiesRepositorio<Palabras>();
                var buscarPalabra = Palabras.GetFirstOrDefault(x => x.Palabra == oParam.Palabra);

            

            if (buscarPalabra == null)
            {
                buscarPalabra = new PosicionesDatos.Palabras();
                buscarPalabra.Cantidad = 1;
                buscarPalabra.Palabra = oParam.Palabra;

                Palabras.Add(buscarPalabra);
                Palabras.SaveChanges();
            }
            else
            {
                buscarPalabra.Cantidad++;
                Palabras.SaveChanges();
            }
            

            
            

            oParam.Palabra = oParam.Palabra.ToUpper();

            if (oParam.Palabra != "JAVA" && oParam.Palabra != "TELEFE" && oParam.Palabra != "VIACOM")
            {
                modelo.Errores = "La palabra a buscar no está dentro de las posibles a elegir";
                return modelo;
            }

            char[][] matriz = new char[7][];
            matriz[0] = new char[5];
            matriz[1] = new char[5];
            matriz[2] = new char[5];
            matriz[3] = new char[5];
            matriz[4] = new char[5];
            matriz[5] = new char[5];
            matriz[6] = new char[5];

            string[] secuencias = { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" };

            for (int s = 0; s < secuencias.Length; s++)
            {
                matriz[s] = secuencias[s].ToCharArray();
            }            

            int[] posicionInicial = new int[] {  0 ,  0  };
            bool encontroLetra = false;
            char[] letras =  oParam.Palabra.ToCharArray();
            for (int i = 0; i < letras.Length; i++)
            {
                encontroLetra = false;
                for (int j = posicionInicial[0]; j < matriz.Length; j++)
                {
                    for (int k = posicionInicial[1]; k < matriz[j].Length; k++)
                    {
                        if (matriz[j][k] == letras[i])
                        {
                            if (i + 1 < letras.Length)
                            {
                                //Buscar una posicion mas a la derecha
                                if (j+1 < matriz.Length)
                                {
                                    if (matriz[j + 1][k] == letras[i + 1])
                                    {
                                        modelo.Resultados.Add(new int[] {  j + 1 ,  k + 1  });
                                        posicionInicial = new int[] { j, k };
                                        encontroLetra = true;
                                    }
                                }
                                //Buscar una posicion mas abajo
                                if (k+1 < matriz[j].Length)
                                {
                                    if (matriz[j][k + 1] == letras[i + 1])
                                    {
                                        modelo.Resultados.Add(new int[]  { j + 1 , k + 1 } );
                                        posicionInicial = new int[] { j, k };
                                        encontroLetra = true;
                                    }
                                }
                                //Buscar una posicion mas abajo y a la derecha

                                if (j + 1 < matriz.Length && k + 1 < matriz[j].Length) {
                                    if (matriz[j + 1][k + 1] == letras[i + 1])
                                    {
                                        modelo.Resultados.Add(new int[]  { j + 1 , k + 1 } );
                                        posicionInicial = new int[] { j, k };
                                        encontroLetra = true;
                                    }
                                }

                            }else if (i+1  == letras.Length)
                            {
                                modelo.Resultados.Add(new int[]  { j + 1 , k + 1 } );
                                posicionInicial = new int[] { j, k };
                                encontroLetra = true;
                            }
                            
                            
                        }
                        if (encontroLetra)
                            break;
                    }
                    if (encontroLetra)
                        break;
                }
            }
            modelo.Errores = "No hubo errores";
            return modelo;
        }

        public List<ListadoPalabras> TraerPalabras()
        {
            List<ListadoPalabras> modelo = new List<ListadoPalabras>();

            PosicionesEntitiesRepositorio<Palabras> Palabras = new PosicionesEntitiesRepositorio<Palabras>();

            modelo = Palabras.AsQueryable().Select(x=> new ListadoPalabras {
                Cantidad = x.Cantidad,
                Id = x.Id,
                Palabra = x.Palabra
            }).ToList();

            return modelo;
        }

    }
}
