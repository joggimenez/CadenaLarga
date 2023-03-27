using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CadenaLarga
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Cargar la matriz de caracteres desde un archivo de texto plano
                Console.WriteLine("Ingrese la Ruta del archivo txt y presione Enter (en blanco para Default del app.config):");
                string rutaArchivo = Console.ReadLine();
                if( string.IsNullOrEmpty(rutaArchivo))
                {
                    rutaArchivo = ConfigurationManager.AppSettings["RutaArchivo"];
                }
                StreamReader reader = new StreamReader(rutaArchivo);
                string content = reader.ReadToEnd();
                reader.Close();
                char[,] matrix = ConvertToCharMatrix(content);

                var isValid = ValidateMatrix(matrix);
                if (isValid)
                {
                    var longestString = CalculateLongestString(matrix);
                    Console.WriteLine("La cadena adyacente más larga es: " + string.Join(", ", longestString.ToCharArray()));
                }
                Console.WriteLine("Presione cualquier tecla para finalizar.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static char[,] ConvertToCharMatrix(string text)
        {
            // Eliminar los saltos de línea al final del texto
            text = text.TrimEnd('\r', '\n');

            // Dividir el texto en líneas
            string[] lines = text.Split('\n');

            // Eliminar los retornos de carro
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimEnd('\r');
            }

            // Crear una matriz de caracteres
            char[,] matrix = new char[lines.Length, lines[0].Length];

            // Rellenar la matriz con los caracteres de cada línea
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    matrix[i, j] = lines[i][j];
                }
            }

            return matrix;
        }

        private static bool ValidateMatrix(char[,] matrix)
        {
            string regex = @"^[a-zA-Z\dñÑ]+$";
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) < 2)
            {
                Console.WriteLine("La matriz no es válida (no es cuadrada o no cumple la dimension mínima).");
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string rowStr = new String(Enumerable.Range(0, matrix.GetLength(1)).Select(j => matrix[i, j]).ToArray());
                    if (!Regex.IsMatch(rowStr, regex))
                    {
                        Console.WriteLine("La matriz no es válida. Caracteres no Permitidos");
                        return false;
                    }
                }
            }
            return true;
        }

        private static string CalculateLongestString(char[,] matrix)
        {
            string longestString = "";
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // Horizontal
                    StringBuilder horizontal = new StringBuilder();
                    for (int i = col; i < matrix.GetLength(1) && matrix[row, i] == matrix[row, col]; i++)
                    {
                        horizontal.Append(matrix[row, i]);
                    }
                    if (horizontal.Length > longestString.Length)
                    {
                        longestString = horizontal.ToString();
                    }

                    // Vertical
                    StringBuilder vertical = new StringBuilder();
                    for (int i = row; i < matrix.GetLength(0) && matrix[i, col] == matrix[row, col]; i++)
                    {
                        vertical.Append(matrix[i, col]);
                    }
                    if (vertical.Length > longestString.Length)
                    {
                        longestString = vertical.ToString();
                    }

                    // Diagonal hacia abajo
                    StringBuilder diagonalDown = new StringBuilder();
                    for (int i = row, j = col; i < matrix.GetLength(0) && j < matrix.GetLength(1) && matrix[i, j] == matrix[row, col]; i++, j++)
                    {
                        diagonalDown.Append(matrix[i, j]);
                    }
                    if (diagonalDown.Length > longestString.Length)
                    {
                        longestString = diagonalDown.ToString();
                    }

                    // Diagonal hacia arriba
                    StringBuilder diagonalUp = new StringBuilder();
                    for (int i = row, j = col; i >= 0 && j < matrix.GetLength(1) && matrix[i, j] == matrix[row, col]; i--, j++)
                    {
                        diagonalUp.Append(matrix[i, j]);
                    }
                    if (diagonalUp.Length > longestString.Length)
                    {
                        longestString = diagonalUp.ToString();
                    }
                }
            }
            return longestString;
        }
    }
}
