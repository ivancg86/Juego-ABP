Resumen Github
=========================================

  - [Introducción](#introducción)
  - [Crear una rama](#crear-una-rama)
  - [Agregar commits](#agregar-commits)
  - [Abrir un Pull Request](#abrir-un-pull-request)
  - [Discutir y revisar tu código](#discutir-y-revisar-tu-código)
  - [Merge](#Merge)


## Introducción ##

La forma de trabajo de GitHub es ligera, su forma de trabajo basado-en-ramas soporta equipos y proyectos donde las asignaciones se realizan regularmente. Esta guía explica como funciona la forma de trabajo de GitHub.


## Crear una rama ##

Nunca: editar sobre la rama MASTER directamente. :exclamation:

Siempre: Crear una rama (new branch) que duplicá la rama master para trabajar con la copia libremente. :thumbsup:


## Agregar _commits_ ##

Cuando agregas, editas o borras un archivo, estás haciendo un _commit_, y agregando eso a tu rama. Este proceso de agregar _commits_ mantiene un registro de tu progreso mientras trabajas en una rama.

Los _commits_ también crean un historial de manera transparente a tu trabajo que otros pueden seguir para entender que has hecho y por qué. Cada _commit_ tiene asociado un mensaje, que es una descripción explicando el por qué de un cambio en particular.

#### Consejo Pro ####

Los mensajes de _commit_ son importantes. Escribiendo mensajes de _commit_ claros, puedes hacer fácil para otras personas seguirte y proveer retroalimentación.


## Abrir un _Pull Request_ ##

“Petición de Validación”. Una Pull Request es la acción de validar un código que se va a hacer "merge" de una rama a otra (Ej: mi-rama a master). 

Los _Pull Requests_ te ayudan a comenzar revisiones y conversaciones acerca del código antes de aplicarse a la rama _master_.

Puedes seguir enviando tus cambios a la rama en plena discusión de tus _commits_. Si alguien comenta que olvidaste hacer algo o que hay un _bug_ en tu código, puedes arreglarlo en tu rama y enviar el cambio. GitHub mostrará tus nuevos _commits_ y cualquier comentario adicional que quizás recibas en la vista unificada de _Pull Request_.


## Merge ##

Después del _Pull Request_ la nueva rama se fusiona con la rama master

Una vez hecho, los _Pull Requests_ se guardan en un registro del historial de cambios de tu código. Gracias a esto puedes buscar y volver a cualquier punto atrás en el tiempo para entender por qué y cómo una decisión fue tomada.
