# SearchNews

##Descripción General
API RESTful para obtener el detalle de las n mejores historias provenientes de API “Hackers News API”, determinadas por su “score”. 

##Diseño:
La API cuenta con un método GET de búsqueda el cual recibe como parámetros el número de historias a consultar y el número de página a consultar.
La respuesta se estructura en páginas, para optimizar las consultas  al API Hackers News. Se tiene establecido un tamaño de página de 10 noticas, lo cual se puede ajustar de acuerdo a las necesidades del caso de uso.

Los métodos establecidos son:

Método |	Inputs |	Outputs
GetBetsStoriesDetail (GET)	|num_stories|
indexPage	
 [ { "title": "…, 
      "uri": "…", 
      "postedBy": "…", 
        "time": "…", 
        "score": 0, 
        “commentCount": 572 
   },
     { ... }, { ... }, { ... }, ...
]

Se cuenta con una interfaz Swagger para probar su funcionalidad de manera sencilla.

##Consideraciones:
Al método principal de búsqueda se construyó de la tal manera que los resultados se pudieran recuperar a manera de segmentada, esto para evitar que en usa sólo petición se consumieran todos los resultados existentes y pudiera representar un problema de rendimiento en el 

##API Hackers New.
Aun existen mejoras sustanciales que hacer como:
•	Implementar un manejo de error más estricto
•	Incorporación de métodos para configuración del nivel de paginación deseado, conteo de noticias existentes, etc.
