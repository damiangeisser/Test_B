Se generan las clases de los alquileres en función de la periodicidad, si bien quizás en realidad lo que deberían modelarse serían las entidades involucradas
(alquileres, bicicletas, clientes), y dejar que la periodicidad sea una propiedad variable en la clase alquileres y no que defina clases derivadas de por sí.

Se modela a su vez, una clase promociones.

Tanto el valor de la los alquileres como el de los descuentos son una propiedad estática, lo que permite espefcificar el valor inicial para todas las instancias.
Para evitar que los cambios afecten a los cálculos de los objetos ya instanciados, se asigna el valor a una propiedad no estática, que es la que se utiliza en los métodos.

Lo ideal sería tomar el valor para esas propiedades estáticas desde un archivo de configuración, una tabla de constantes o una base de datos.

Sería recomendable implementar una capa de controladores, que gestiones las peticiones y esta acceda a la capa del negocio, en donde se resuelve la lógica de las peticiones.
Teniendo aparte una capa de modelo que sólo tenga la definición de las clases y por último una de datos que gestione la persistencia en una base de datos u otro método de almacenamiento.

Es posible complejizar mucho más lo desarrollado, como menciones sería necesario implementar al menos una clase para las bicicletas, otra para los clientes. También los rentals deberían
tener algún tipo de código que los identifique.

Los test unitarios implementados apuntan a los métodos más complejos que son los que calculan los valores finales (y que implican a su vez, pasar por todos los métodos de instanciación),
si bien entiendo que el propósito de los test unitarios es el de probar funciones o comportamientos aislados.
