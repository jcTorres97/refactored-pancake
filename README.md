# Pruebas de Desarrollo

¡Bienvenido a las pruebas! Estas pruebas te permitirán demostrar tus habilidades en el desarrollo de aplicaciones web utilizando .NET C# y tu capacidad para trabajar con proyectos y dependencias en GitHub. Asegúrate de seguir las instrucciones cuidadosamente y adherirte a las mejores prácticas de desarrollo de software en tus soluciones.

## Requisitos previos
Antes de comenzar con las pruebas, asegúrate de cumplir con los siguientes requisitos:

1. Tener una cuenta en [GitHub](https://github.com).
2. Tener instalado Visual Studio 2019 o una versión más reciente con el SDK .NET Framework 4.5 instalado.

## Proyectos a utilizar
Para estas pruebas, deberás trabajar con dos proyectos en GitHub:

1. [refactored-pancake](https://github.com/Lotharok/refactored-pancake): Una aplicación web que emula el front para consultar información de Actividades/Tours, incluyendo información general y tarifas.
2. [glowing-dollop](https://github.com/Lotharok/glowing-dollop): Una librería de dependencia utilizada en la aplicación web para obtener información de las Actividades/Tours.

## Instrucciones generales
1. Clona ambos proyectos en tu entorno de desarrollo utilizando Git o descargándolos como archivos ZIP desde GitHub.

2. Configura y ejecuta la aplicación web "refactored-pancake" en Visual Studio. Asegúrate de que la aplicación se ejecute sin errores.

3. Resuelve los ejercicios que se describen a continuación en la aplicación web:

## Ejercicio 1
- Ruta: `/Home/Test`
- Debes mostrar información que se consulta desde la librería "glowing-dollop".
- Debes mostrar el mensaje "Test 1 Correcto".
- Además, muestra la siguiente información de la Actividad/Tour:
  - Nombre: Traslados privados de ida y vuelta a parques temáticos
  - Código: E-U10-PRVPARKTRF
- **No se pueden modificar la fuente de datos en la librería.**
- Como regla de negocio, es válido que una consulta no regrese tarifas, pero debe regresar la información de la Actividad/Tour.

## Ejercicio 2
- Ruta: `/Home/Test2`
- La navegación a la ruta tiene un error en tiempo de ejecución.
- Asegúrate de que la navegación a esta ruta funcione correctamente.
- **Las vistas no deben de sufrir cambios.**

## Ejercicio 3
- Realiza una invocación a la siguiente API: `https://refactored-pancake.free.beeceptor.com/margin/{code}`.
- Debes recuperar el margen personalizado según el código de servicio `{code}` y mostrarlo en la vista.
- Considera las siguientes condiciones:
  - Si la API responde con un estado (status) 200, significa que existe el margen y debes regresar el valor de la respuesta.
  - Si la API responde con cualquier otro estado, debes regresar `{ "margin": 0.0 }`.
  - Codigos para probar los status: E-U10-UNILATIN 204, E-U10-DSCVCOVE 404 y E-E10-PF2SHOW 500.

## Ejercicio 4 (Opcional - Plus)
- Usando el patron decorador crear servicio para IMarginProvider que recupera el margen de una cotización.
- Debes utilizar la misma API del ejercicio 3.
- Si la API responde con un estado (status) 200, sustituye el margen default con el valor de la respuesta.
- Si la API responde con cualquier otro estado, debes mantener el margen default sin cambios.

## Consideraciones adicionales
- Se permite el uso de librerías externas para simplificar el desarrollo.
- Asegúrate de seguir las mejores prácticas de desarrollo de software en tus soluciones, incluyendo buenas prácticas de codificación, manejo de errores y documentación del código.

## Entrega
Una vez hayas completado los ejercicios, te pedimos que generes una branch de los repositorios con tus cambios y nos los compartas.

Si tienes alguna pregunta o necesitas aclaraciones adicionales, no dudes en contactarnos. ¡Buena suerte con las pruebas!