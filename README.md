# Cadena Larga

## Objetivo:  

Sea una matriz cuadrada de dos dimensiones, de caracteres (cualquiera), devuelva la cadena de caracteres adyacentes iguales más larga.  

### Ejemplo:  

B, B, D, A, D, E, F  
B, X, C, D, D, J, K  
H, Y, I, 3, D, D, 3  
R, 7, O, Ñ, G, D, 2  
W, N, S, P, E, 0, D  
A, 9, C, D, D, E, F  
B, X, D, D, D, J, K  

Debería devolver la cadena D, D, D, D, D, porque hay una diagonal de D de longitud 5 que es la más larga.  

Debes buscar en vertical, diagonal y horizontal.  

El programa que escribas debe tomar la entrada de un archivo de texto plano o de la entrada estándar (elige el método que te sea más cómodo) y debe sacar la cadena por salida estándar.  

## Requisitos para ejecutar la aplicación
1. Visual Studio 2019 o superior.
2. Tener instalado el .NET Framework 4.7.2

## Cómo compilar la aplicación

En Visual Studio, puedes compilar la aplicación presionando Ctrl+Mayús+B o seleccionando "Build Solution" en el menú "Build".

## Cómo Ejecutar la aplicación

Para ejecutar la aplicación desde Visual Studio, es necesario tener descargado el repositorio con la solución en cuestión. Adicionalmente podemos configurar la ruta por defecto para que tome el archivo .txt en el que introducimos la matriz para que haga el análisis del algoritmo.

1. Abrir el archivo app.config y configurar el path como en el siguiente ejemplo:

~~~
  <add key="RutaArchivo" value="C:\Users\jony_\source\repos\CadenaLarga\CadenaLarga\Archivo.txt"/>
~~~
2. De no configurarlo, podremos introducir el path desde la aplicación de consola (por default siempre toma la ruta de app.config).

## Como usar la aplicación

1. Al ejecutar la aplicación visualizamos el siguiente mensaje: 
  ~~~
  Ingrese la Ruta del archivo txt y presione Enter (en blanco para Default del app.config)
  ~~~

  - Ingresar la ruta del archivo .txt que tenga una matriz cuadrada. Ejemplo de matriz: 

    ~~~
    ABC  
    DEF  
    GHI  
    ~~~

2.  1. Si la matriz tiene caracteres no validos o la matriz no es cuadrada el proceso termina con mensaje de error.
    2. Si la matriz es valida, devuelve el resultado de la siguiente manera: 
    ~~~
    La cadena adyacente más larga es: D, D, D, D, D
    ~~~
    
3. Para finalizar el programa pulse cualquier tecla:

    ~~~
    Presione cualquier tecla para finalizar.
    ~~~



