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

## Arquitectura de la solución

La solución ha sido implementada mediante lenguage C#.NET usando el IDE Visual Studio 2019. Para realizar la misma, se ha empleado un diseño DDD (Domain Driven Design) y se ha dividido en 4 capas:

- **CAPA DE DOMINIO:**
	Es la capa principal sobre la que se sustentan las demás. Su objetivo es definir de forma fiel al mundo real, todos los elementos u objetos de negocio que componen el domínio del problema. Esta capa se mantiene "pura y limpia sin contaminación". No tiene dependencias de ninguna otra capa (proyecto).
	Está implementada mediante el proyecto __HexahedronIntersectionDomain__, desarrollado como una librería (dll) sobre la plataforma de destino [".NET Standard 2.0"](https://learn.microsoft.com/es-es/dotnet/standard/net-standard?tabs=net-standard-2-0). El motivo de hacerlo así es para que dicha libreria pueda ser utilizada tanto en aplicaciones desarrolladas en .NET Framework (4.6.1 a 4.8.1) como en otras implementadas sobre .NET Core (2.0 a 7.0), haciéndola así mucho más portable.
	A su vez, dicho proyecto está organizado en 3 carpetas en base a conceptos relativos a DDD:  
        __ENTITIES__: Entidades con identidad propia e identificación unívoca. En este caso, se define únicamente la entidad Hexahedron, a la cual hemos dotado de un identificador universal.  
  
		__VALUE OBJECTS__: Son todos los objetos usados para dar valor a determinadas propiedades y que no tienen identidad por sí mismos. Este diseño permite establecer para cada uno de ellos su lógica de validación de forma encapsulada y fuerza a que su creación se realice mediante un método estatico "Create" que garantiza la ejecución de dicha validación. En este caso se han definido los siguientes "value objects": Dimension, HexahedronId, Point1D, Point3D, Segment y Volume.  
  
		__REPOSITORIES__: Mediante la aplicación del patrón Repository, se encarga de definir mediante una interfaz la firma de todas las funciones necesarias para poder obtener, modificar o eliminar objetos de negocio sobre cualquier almacén de datos. Es de vital importancia observar que lo que se define es una interfaz, lo cual aisla por completo al dominio de la implementación y tipología de dicha fuente de datos (Base de datos, fichero excel, fichero JSON, ...), mantediéndolo así independiente de la misma y permitiendo fácilmente intercambiar la misma por otra si así fuese necesario.
- **CAPA DE INFRAESTRUCTURA:**
	Sustentada en el proyecto __HexahedronIntersectionInfrastructure__, en esta capa se definen claramente 2 conceptos: Por un lado el contexto (DbContext), donde se modela la fuente de datos donde almacenar los objetos de negocio y se mapean contra dicho modelado los objetos de negocio definidos en la capa de dominio. Por otro lado se define un Reposotorio acorde a la interfaz expuesta por la capa de dominio y sustentado sobre el contexto (DbContext) anterior. En definitiva, es la encargada de definir la infraestructura concreta del sistema.
- **CAPA DE APLICACIÓN:** Es la capa que contiene la lógica de negocio y que oferta determinados servicios al exterior que pueden ser consumidos por agentes externos. Digamos que es la capa que "trabaja" con los objetos de negocio y "explota" sus funcionalidades y relaciones para ofertar dichos servicios. La misma se ha implementado como una WebAPI en el proyecto __HexahedronIntersectionAPI__ y se compone fundamentelmente de dos partes: La clase __HexahedronServices__ donde se define y da cuerpo a todos los servicios a ofertar; y la clase __HexahedronController__, usada para exponer dichos servicios a traves de la API y que explota la anterior clase __HexahedronServices__ (pasada por inyección de dependencias)
- **CAPA DE INTERFAZ DE USUARIO:** Sería la capa con la que interactuaría el usuario. Podría ser una aplicación de cualquier tipo: Web, de escritorio, móvil, ... Más allá de esta explicación conceptual, en este ejercicio no se ha desarrollado ningún proyecto sobre el que sustentar dicha capa al entender que no es relevante para el mismo y que con las capas desarrolladas es suficiente para realizar la evaluación requerida con este ejercicio. Merece destacar el uso en esta capa del patrón [CQRS](https://learn.microsoft.com/es-es/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/apply-simplified-microservice-cqrs-ddd-patterns), que separa las lecturas (consultas) de las escrituras (comandos) sobre el repositorio.

Todo este diseño está realizado dentro del "Bounded Context" impuesto por este ejercicio, en el cual se ha usado el siguiente lenguaje ubicuo:

- Hexahedron: Poliedro de seis caras.
- HexahedronId: Identificador usado para identificar de forma unívoca un hexaedro de forma universal.
- Volume: Volumen de un poliedro.
- Point1D: Valor para especificar un punto en un espacio de una dimensión.
- Point3D: Valor para especificar un punto en un espacio de tres dimensiones.
- Segment: Sección de un espacio de una dimensión determina por dos Point1D, uno de comienzo y otro de fin.
- Dimension: Distancia entre los puntos de comienzo y de fin de un segmento.

## Solución matemática

La solución matemática se ha basado en la aplicación de la técnica "Divide y vencerás". Para determinar el hexaedro formado por la intersección de los dos originales, el problema se ha simplificado en obtener para cada dimensión, el segmento común a ambos hexaedros originales. Sólo en caso de que en todas las dimensiones exista dicho segmento, existirá intersección, siendo la longitud de dichos segmentos las distintas dimensiones del hexaedro buscado y pudiendo también calcular en base a ellos el punto central del mismo. Esta solución es válida por supuesto en las partes positivas y negativas de cada uno de los 3 ejes X, Y y Z.

## Detalles a considerar sobre el código

- En el proyecto API, además de exponer como EndPoint el servicio para calcular la intersección pedida, tambien se han creado otros 3 que permiten crear, eliminar y obtener un hexaedro en/desde el almacén de datos subyacente. De esta forma justificamos/ejemplificamos el uso del patrón Repository en este ejercicio.
- Para implementar dicho repositorio se ha optado por una base de datos SQLServer, cuya cadena de conexión se puede definir en el archivo appsettings.json del proyecto API. Al no disponer de una base de datos real, dicha cadena de conexión se encuentra vacía actualmente.
- Por la razón anteriormente expuesta, la aplicación no es usable como sí, aunque sí es ejecutable, visualizando en ese caso el Swagger que expone toda las funcionalidad de la API.
- Dado el volúmen de trabajo realizado en la prueba, no se ha tenido en este caso especial atención a los códigos de estado de respuesta HTTP a devolver en los distintos EndPoints ofertados por el controlador HexahedronController del proyecto API. Consecuentemente, tampoco se han usado en los mismos los DataAnnotations necesarios para documentarlos en el Swagger.
- Inyección de dependencias: Puede observarse en el método ConfigureServices de la clase __Startup__ del proyecto API cómo se registran los servicios HexahedronQueries, HexahedronServices y IHexahedronRepository para que puedan ser inyectados en donde proceda, como por ejemplo en el controlador HexahedronController. De especial interés es la inyección del repositorio a través de su interfaz y no de la implementación concreta. Esto permitirá poder cambiar en el futuro dicha implementación del repositorio por otra (otra técnología de base de datos, por ejemplo) si así se desease. También en este punto se registra la implementación concreta de DbContext creada en la capa de infraestructura, haciendola así también disponible por inyección de dependencias donde sea oportuno. Nótese también la inyección por dependencia del objeto Logger en el controlador del proyecto API, para poder registrar los logs necesarios.
- Obsérvese en la clase __HexahedronId__ de la capa de dominio, la definición del operador implícito Guid, el cual permite poder castear un objeto de tipo HexahedronId como un Guid en algunas partes del código.
- Nótese la definición de funciones asíncronas en el proyecto API para poder lanzar sus ejecuciones de esta forma donde fuese requerido.
- Obsérvese el empleo del patrón Singleton en la propiedad Vertexs de la clase __Hexahedron__, haciendo que se obtengan los vertices del mismo bajo demanda sólo la primera vez que se soliciten y quedando ya calculados para el resto de solicitudes. Esto permite a la vez evitar computo innecesario en caso de que no fuese necesario conocer los vertices de un hexaedro y asegurar que, de ser necesarios, sólo tendrían que calcularse una vez, estando ya disponibles para el resto de solicitudes posteriores.
- Observesé el empleo de buenas prácticas dando a cada entidad (clase) las responsabilidades que le corresponden. Por ejemplo, es responsabilidad de la clase __Hexahedron__ devolver cuál es su volumen puesto que es una propiedad suya intrínseca, en lugar de tener que ser calculado por alguna entidad externa de otro tipo.
- Obsérvese que el tipo empleado para definir tanto coordenadas como dimensiones es "Decimal". De esta forma no limitamos la solución a dar valores enteros a dichos parámetros, haciendola 100% realista.
- Obsérvense los modificadores "Public" y "Private" empleados en toda la solución, estándo cuidadosemente establecidos para permitir la visibilidad desde el exterior exclusivamente de aquellas propiedades y/o funciones que procedan.
- De igual forma, obsérvense las secciones "Get" y/o "Set" de todas las propiedades definidas en las diversas clases. De la misma manera, también se encuentran establecidas exclusivamente las extrictamente necesarias, no permitiendo así el acceso al resto.
- Obsérvese el control de casos límites mediante la generación de excepciones especificamente creadas, para controlar posibles ejecuciones en situaciones no realistas.
- Obsérvese el empleo de comentarios donde se han entendido que se requieren.
