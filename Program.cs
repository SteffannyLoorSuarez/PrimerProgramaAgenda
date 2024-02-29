using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda._3.P
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string ruta = "";
            int o;
            do
            {
                Console.WriteLine("Ingrese una opción para su agenda");
                Console.WriteLine("1._ Crear una agenda");
                Console.WriteLine("2._ Revisar su agenda");
                Console.WriteLine("3._ Anexar a su agenda");
                Console.WriteLine("4._ Eliminar de su agenda");
                Console.WriteLine("5._Salir");


                o = int.Parse(Console.ReadLine());
                switch (o)
                {
                    case 1:
                        {
                            Console.WriteLine("Ingrese ruta y nombre del archivo");
                            ruta = Console.ReadLine();
                            break;
                        }
                    case 2:
                        {

                            Console.Clear();
                            Console.SetCursorPosition(70, 0);
                            Console.WriteLine("Revisando su agenda:");
                            Thread.Sleep(1000);
                            Console.Clear();
                            try
                            {

                                FileStream flujo = new FileStream(@ruta, FileMode.Open, FileAccess.Read);
                                StreamReader archivo = new StreamReader(flujo);
                                while (archivo.Peek() > -1)
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine(archivo.ReadLine());
                                }
                                flujo.Close();
                                archivo.Close();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error" + ex.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.SetCursorPosition(70, 0);
                            Console.WriteLine("Anexar texto a su agenda");
                            Console.WriteLine(" Nombre            Género            Número");
                            Console.WriteLine("Anexar texto a su agenda en una sola fila porfavor");
                            Thread.Sleep(1000);
                            Console.Clear();
                            try
                            {

                                FileStream flujo = new FileStream(@ruta, FileMode.Append, FileAccess.Write);

                                StreamWriter anexarPalabras = new StreamWriter(flujo);
                                string p = Console.ReadLine();
                                anexarPalabras.WriteLine(p);
                                anexarPalabras.Close();
                                flujo.Close();


                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error" + ex.Message);
                            }


                            Console.ReadKey();
                            Console.Clear();
                            //flujo.EndWrite(h);
                            break;
                        }
                    case 4:
                        {

                            try
                            {
                                FileStream flujo = new FileStream(@ruta, FileMode.Open, FileAccess.ReadWrite);
                                StreamReader archivo = new StreamReader(flujo);

                                Console.WriteLine("Ingrese el texto que desea eliminar según de como se encuentra enumerado");
                                int e = int.Parse(Console.ReadLine());
                                int cont = 0, cont2 = 0;
                                //while (archivo.Peek() > -1)
                                //{
                                //    cont2++;
                                //}
                                string[] arr = new string[30];
                                while (archivo.Peek() > -1)
                                {

                                    arr[cont] = archivo.ReadLine();
                                    cont++;

                                }

                                flujo.Close();
                                archivo.Close();
                                FileStream flujo2 = new FileStream(@ruta, FileMode.Create, FileAccess.Write);
                                StreamWriter archivo2 = new StreamWriter(flujo2);
                                for (int i = 0; i < arr.Length; i++)
                                {
                                    if (i != e - 1)
                                    {
                                        archivo2.WriteLine(arr[i]);
                                    }

                                }
                                archivo2.Close();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error " + ex.Message);
                            }


                            //for (int i = 0; i < arr.Length; i++)
                            //{
                            //    if (i != e)
                            //    {
                            //        eliminar.WriteLine(arr[i]);
                            //    }

                            //}



                            break;
                        }
                    case 5:
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Saliendo...");
                            break;
                        }

                }

            } while (o != 5);
        }

        //static FileInfo @"C:\Users\user\Documents\Agenda.txt"()
    }
}
