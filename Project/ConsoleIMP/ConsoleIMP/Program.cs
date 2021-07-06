using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleIMP
{
    class Program
    {
        static void Main(string[] args)
        {
            //подключение файлов (отзыв : словарь)
            string review_path = @"D:\Menu\Work\WorkPractice\Key1_ClassificationOfTreatment\Project\ConsoleIMP\review.txt";
            string libre_path = @"D:\Menu\Work\WorkPractice\Key1_ClassificationOfTreatment\KartaSlov\dataset\emo_dict_history\v2_2019_nov\emo_dict.txt";


            using (StreamReader srR = new StreamReader(review_path, System.Text.Encoding.Default))
            {
                using (StreamReader srL = new StreamReader(libre_path, System.Text.Encoding.Default))
                {
                    //Читаем оба файла
                    libre_path = srL.ReadToEnd();
                    review_path = srR.ReadToEnd();

                    //разделяем сплошной текст на слова
                    String[] RP = review_path.Split(' ');
                    String[] LB = libre_path.Split(';');


                    //Сравнение и определение оценки
                    int SplitEnd_LB = LB.Length;
                    int SplitEnd_RP = RP.Length;
                    int Mood = 0;
                     for (int RP_i = 0; (RP_i < SplitEnd_RP); RP_i++) //каждое слово из отзыва подвергается оценке
                        {
                            for (int LB_i = 0; (LB_i < SplitEnd_LB); LB_i++)
                            {
                                if (RP[RP_i] == LB[LB_i])
                                {
                                    var Key = LB[LB_i+1];

                                    switch(Key)
                                    {
                                        case "PSTV":
                                            {
                                                Mood++;
                                            Console.WriteLine(Mood);
                                            Console.WriteLine(LB[LB_i]);
                                            break;
                                            }
                                        case "NGTV":
                                            {
                                                Mood--;
                                            Console.WriteLine(Mood);
                                            Console.WriteLine(LB[LB_i]);
                                            break;
                                            }
                                        case "NEUT":
                                            {
                                            //Console.WriteLine(LB[LB_i]);
                                            break;
                                            }
                                        default:
                                            
                                                break;
                                    }
                                 
                                }
                            }
                     }
                    Console.WriteLine(Mood);
                }

            }
        }
    }
}