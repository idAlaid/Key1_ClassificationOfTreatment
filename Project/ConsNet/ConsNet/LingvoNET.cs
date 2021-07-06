using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsNet
{
    class LingvoNET
    {
     /*
        
                    Для получения склонения в нужном падеже и числе, используйте следующий индексатор Noun:
 
            public string this[Case @case, Number number = Number.Singular]{ get; }

            Индексатор возвращает строку - склонение исходного существительного. Если данного склонения не существует - возвращается null.
 
            В целом, пример кода для склонения выглядит так:

            var noun = Nouns.FindOne("ласка", animacy : Animacy.Animate);//поиск одушевленного омонима слова "ласка"
            if (noun != null)
            {
                //получаем винительный падеж множественного числа
                var accusative = noun[Case.Accusative, Number.Plural]; // accusative -> (кого?) ласок
                //....
            }
        
     */
    }
}
