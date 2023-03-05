# Cube Intersection
## Prueba técnica para incorporación a Capitole Consulting

## Descripcion

Esta solución software ha sido realizada para presentar mi candidatura como Senior Developer .NET a la compañía Capitole Consulting.

En la misma se persigue obtener el volumen de la intersección entre dos cubos en un espacio 3D en caso de que estos colisionen.

## Consideración inicial

Con el debido permiso y para argumentar el por qué de la decisión adoptada, es necesario aclarar previamente dos conceptos:

- Hexaedro: Poliedro de seis caras.
- Cubo: Hexaedro de seis caras cuadradas iguales.

Es decir, un cubo no es más que un caso particular de un hexaedro en el que todas sus dimensiones (Alto, Ancho, Fondo) son iguales.

Aunque el enunciado del ejercicio se refiere al caso concreto de Cubos, el ejercicio se ha desarrollado por completo a nivel de hexaedro por los siguientes motivos:

- A la hora de definir un cubo, basta con definir un hexaedro al que se de el mismo valor para todas sus dimensiones.
- La intersección de dos hexaedros devolverá otro hexaedro pero la intersección de dos cubos también devolverá siempre un hexaedro (aunque en casos específicos pueda ser un cubo).
- Aunque el ejercicio solicita exclusivamente devolver el volumen de la intersección, y dado que este en realidad no es más que una propiedad del hexaedro formado por la misma, la solución diseñada no devuelve directamente dicho volumen, sino que devuelve el hexaedro formado por dicha intersección, del cual se puede conocer su volumen solicitando simplemente el valor de dicha propiedad.

A pesar de todo lo explicado y para cumplir fielmente con el enunciado del ejercicio, se ha implementado la clase "Cube" que hereda de la clase "Hexahedron" y permite en su constructor definir el único valor del que dispondrá en sus tres dimensiones (Alto, Ancho, Fondo).

## Arquitectura de la solución

La solución ha sido implementada mediante lenguage C#.NET usando el IDE Visual Studio 2019. Se compone de 3 proyectos:

- HexahedronIntersection: Es el proyecto principal y el que contiene toda la lógica y objetos de negocio. Es el que realmente da solución al problema y se mantiene separado de cualquier capa de UI. Este proyecto ha sido desarrollado como una librería (dll) sobre la plataforma de destino [".NET Standard 2.0"](https://learn.microsoft.com/es-es/dotnet/standard/net-standard?tabs=net-standard-2-0). El motivo de hacerlo así es para que dicha libreria pueda ser utilizada tanto en aplicaciones desarrolladas en .NET Framework (4.6.1 a 4.8.1) como en otras implementadas sobre .NET Core (2.0 a 7.0), haciéndola así mucho más portable.
- HexahedronIntersectionUnitTest: Es un proyecto simple de pruebas unitarias usado tan sólo para testar el correcto funcionamiento de la librería anterior, incluyendo casos límites (dimensiones erróneas, ...). A través de la ventana "Explorador de pruebas" del entorno Visual Studio, pueden ejecutarse todas las pruebas y comprobar sus resultados.
- HexahedronIntersectionApp: Es el proyecto de uso para el usuario final. Equivaldría a un proyecto en producción.

## Solución matemática

La solución matemática se ha basado en la aplicación de la técnica "Divide y vencerás". Para determinar el hexaedro formado por la intersección de los dos originales, el problema se ha simplificado en obtener para cada dimensión, el segmento común a ambos hexaedros originales. Sólo en caso de que en todas las dimensiones exista dicho segmento, existirá intersección, siendo la longitud de dichos segmentos las distintas dimensiones del hexaedro buscado y pudiendo también calcular en base a ellos el punto central del mismo. Esta solución es válida por supuesto en las partes positivas y negativas de cada uno de los 3 ejes X, Y y Z.

## Detalles a considerar sobre el código

- Obsérvese el empleo del patrón Singleton en la propiedad Vertexs de la clase Hexahedron, haciendo que se obtengan los vertices del mismo bajo demanda sólo la primera vez que se soliciten y quedando ya calculados para el resto de solicitudes. Esto permite a la vez evitar computo innecesario en caso de que no fuese necesario conocer los vertices de un hexaedro y asegurar que, de ser necesarios, sólo tendrían que calcularse una vez, estando ya disponibles para el resto de solicitudes posteriores.
- Observesé el empleo de buenas prácticas dando a cada entidad (clase) las responsabilidades que le corresponden. Por ejemplo, es responsabilidad de la clase Hexahedron devolver cuál es su volumen puesto que es una propiedad suya intrínseca, en lugar de tener que ser calculado por alguna entidad externa de otro tipo.
- Obsérvese que el tipo empleado para definir tanto coordenadas como dimensiones es "Decimal". De esta forma no limitamos la solución a dar valores enteros a dichos parámetros, haciendola 100% realista.
- Obsérvense los modificadores "Public" y "Private" empleados en toda la solución, estándo cuidadosemente establecidos para permitir la visibilidad desde el exterior exclusivamente de aquellas propiedades y/o funciones que procedan.
- De igual forma, obsérvense las secciones "Get" y/o "Set" de todas las propiedades definidas en las diversas clases. De la misma manera, también se encuentran establecidas exclusivamente las extrictamente necesarias, no permitiendo así el acceso al resto.
- Obsérvese el control de casos límites mediante la generación de excepciones especificamente creadas, para controlar posibles ejecuciones en situaciones no realistas.
- Obsérvese el empleo de comentarios donde se han entendido que se requieren.
- Obsérvese que la clase HexahedronIntersectionManager ha sido definida como estática, ya que no es necesaria la instanciación de objetos sobre la misma para poder obtener la intersección entre dos hexaedros. Lo mismo ocurre con la clase SegmentIntersectionManager.
