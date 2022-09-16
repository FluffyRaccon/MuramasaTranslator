### Muramasa Translator (PS Vita)

Este proyecto tiene la finalidad de facilitar la traducción de archivos NMS principalmente, los cuales se encuentran en la siguiente ruta (tras descomprimir los archivos NinPriPatch.cpk de la actualización)

> Ruta:  blabla.../_US/msgsheet

Fuera de eso, este programa no hará milagros como ayudarte a editar las texturas que vienen en formato FTX -> GXT -> DDS (sí, triple procedimiento de conversión para poder editar las texturas)

## Respecto a la acentuación de palabras

Este programa viene codificado para funcionar con los reemplazos de las letras (no configurable de momento) **á,é,í que se reemplazan con  '¬', '{', '}'** respectivamente.
Es decir que si quisiera poner una palabra con acentos, tendría que reemplazar los caracteres de manera manual (o lo puede hacer el programa por tí) de la siguiente manera:

> Para palabras con tilde en la 'a': 'ápice' => '¬pice'
> Para palabras con tilde en la 'e': 'caminaré' => 'caminar}'
> Para palabras con tilde en la 'i': 'ansío' => 'ans{o'

## ¿Por qué tiene que ser así de complicado?

Los desarrolladores del juego o de la traducción, a pesar de que tienen en sus fuentes muchos de los caracteres de la tabla ASCII, no mapearon todos los caracteres para que sean reconocidos dentro de los archivos de textos del juego. ¿Qué significa esto? Pues muy simple; cuando el juego detecta alguno de los caracteres "válidos" pero no están mapeados, se pueden ocasionar fallos visuales tales que desaparece el caracter no válido junto con la siguiente letra/caracter que le acompaña.

Aún no tenemos la experiencia para modificar los ejecutables de PS Vita, por lo tanto no es algo que podamos solucionar con nuestra experiencia actual, si tienes experiencia y quieres aportar en este tema, puedes dejarnos un contacto [desde aquí](https://github.com/FluffyRaccon/MuramasaTranslator/discussions)

## No me gusta su traducción, ¿puedo hacer la mía o modificar la de ustedes?
No os vamos a negar que como todos, somos humanos, y pudiésemos llegar a cometer errores... así que os seremos sinceros: **SÍ, pueden hacer su propia versión**, pero no podéis tomar nuestra versión y modificarla, porque se puede prestar a que quieran hacerse pasar como los autores o de las herramientas o del parche. Es por eso que **de ninguna manera proporcionaremos archivos de desarrollo de nuestra versión**. Si gustan podemos ofreceros ayuda con los temas generales, pero no proporcionaremos las herramientas que hemos usado ya que algunas involucran a terceros que sólo han dado su consentimiento a "Muramasa Team" para usarlas. 