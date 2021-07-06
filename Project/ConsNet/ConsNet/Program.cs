using System;
using System.IO;
using LingvoNET;

namespace ConsNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //подключение файлов (отзыв : словарь)
            
            string review_path = @"D:\Menu\Work\WorkPractice\Key1_ClassificationOfTreatment\Project\ConsoleIMP\review.txt";
            string libre_path = @"D:\Menu\Work\WorkPractice\Key1_ClassificationOfTreatment\KartaSlov\dataset\emo_dict_history\v2_2019_nov\emo_dict.txt";


            using (StreamReader srR = new StreamReader(review_path))          //открытие отзывов
            {
                using (StreamReader srL = new StreamReader(libre_path))       //открытие словаря
                {
                    //Читаем оба файла
                    libre_path = srL.ReadToEnd();
                    review_path = srR.ReadToEnd();

                    //разделяем сплошной текст на слова
                    String[] RP = review_path.Split(' ');
                    String[] LB = libre_path.Split(';', '\n');

                    //====================================Сравнение и определение оценки===========================================================================
                    // 2 конечных счётчика 
                    int SplitEnd_LB = LB.Length;
                    int SplitEnd_RP = RP.Length;
                    //Настроение ( буду переделывать и переносить в класссс)
                    int Mood = 0;
                    for (int RP_i = 0; (RP_i < SplitEnd_RP); RP_i++) //каждое слово из отзыва подвергается оценке из словаря ( Без веса )
                    {
                        for (int LB_i = 0; (LB_i < SplitEnd_LB); LB_i++)
                        {
                            int Strong = 0;
                            //первая версия фильтра сравнения слов. Определяем насколько слово можно приблизить к словарному варианту. (не был найден способ сравнивать слова с учетом склонений без подключения БД и использования библиотеки LingvoNET. В будущем возможно будет через БД)
                            if ((RP[RP_i].Length > 3) && (LB[LB_i].Length > 3))
                            {
                                Strong = (3);
                            }
                            if ((RP[RP_i].Length > 4) && (LB[LB_i].Length > 4))
                            {
                                Strong = (4);
                            }
                            if ((RP[RP_i].Length > 5) && (LB[LB_i].Length > 5))
                            {
                                Strong = (5);
                            }
                            if ((RP[RP_i].Length > 6) && (LB[LB_i].Length > 6))
                            {
                                Strong = (6);
                            }
                            if ((RP[RP_i].Length > 7) && (LB[LB_i].Length > 7))
                            {
                                Strong = (7);
                            }
                            if ((RP[RP_i].Length > 8) && (LB[LB_i].Length > 8))
                            {
                                Strong = (8);
                            }
                            int step = 0; //шаг для сброса цикла в случае успешного сравнивания

                            //для удобного отслеживания на стадии поиска багов
                           /* var RRPp = RP[RP_i];
                            var RLBb = LB[LB_i];*/


                            switch (Strong)
                            {
                                case 3:
                                    {
                                        var RRP = RP[RP_i].Remove(3);
                                        var RLB = LB[LB_i].Remove(3);
                                        if (RRP == RLB)
                                        {
                                            step++;
                                            var Key = (LB[LB_i + 1]); //Берем из библиотеки оценку слова
                                            switch (Key)
                                            {
                                                case "PSTV":
                                                    {
                                                        Mood++;
                                                        //Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NGTV":
                                                    {
                                                        Mood--;
                                                        // Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NEUT":
                                                    {
                                                        //Console.WriteLine(RP[RP_i]);
                                                        break;
                                                    }
                                                default:
                                                    //Console.WriteLine("Lost");
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        var RRP = RP[RP_i].Remove(4);
                                        var RLB = LB[LB_i].Remove(4);
                                        if (RRP == RLB)
                                        {
                                            step++;
                                            var Key = (LB[LB_i + 1]); //Берем из библиотеки оценку слова
                                            switch (Key)
                                            {
                                                case "PSTV":
                                                    {
                                                        Mood++;
                                                        //Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NGTV":
                                                    {
                                                        Mood--;
                                                        // Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NEUT":
                                                    {
                                                        //Console.WriteLine(RP[RP_i]);
                                                        break;
                                                    }
                                                default:
                                                    Console.WriteLine("Lost");
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 5:
                                    {
                                        var RRP = RP[RP_i].Remove(5);
                                        var RLB = LB[LB_i].Remove(5);;
                                        if (RRP == RLB)
                                        {
                                            step++;
                                            var Key = (LB[LB_i + 1]); //Берем из библиотеки оценку слова
                                            switch (Key)
                                            {
                                                case "PSTV":
                                                    {
                                                        Mood++;
                                                        //Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NGTV":
                                                    {
                                                        Mood--;
                                                        // Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NEUT":
                                                    {
                                                        //Console.WriteLine(RP[RP_i]);
                                                        break;
                                                    }
                                                default:
                                                    Console.WriteLine("Lost");
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 6:
                                    {
                                        var RRP = RP[RP_i].Remove(6);
                                        var RLB = LB[LB_i].Remove(6);
                                        step++;
                                        if (RRP == RLB)
                                        {
                                            step++;
                                            var Key = (LB[LB_i + 1]); //Берем из библиотеки оценку слова
                                            switch (Key)
                                            {
                                                case "PSTV":
                                                    {
                                                        Mood++;
                                                        //Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NGTV":
                                                    {
                                                        Mood--;
                                                        // Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NEUT":
                                                    {
                                                        Console.WriteLine(RP[RP_i]);
                                                        break;
                                                    }
                                                default:
                                                    Console.WriteLine("Lost");
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 7:
                                    {
                                        var RRP = RP[RP_i].Remove(7);
                                        var RLB = LB[LB_i].Remove(7);
                                        if (RRP == RLB)
                                        {
                                            step++;
                                            var Key = (LB[LB_i + 1]); //Берем из библиотеки оценку слова
                                            switch (Key)
                                            {
                                                case "PSTV":
                                                    {
                                                        Mood++;
                                                        //Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NGTV":
                                                    {
                                                        Mood--;
                                                        // Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NEUT":
                                                    {
                                                        //Console.WriteLine(RP[RP_i]);
                                                        break;
                                                    }
                                                default:
                                                    Console.WriteLine("Lost");
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 8:
                                    {
                                        var RRP = RP[RP_i].Remove(8);
                                        var RLB = LB[LB_i].Remove(8);
                                        if (RRP == RLB)
                                        {
                                            step++;
                                            var Key = (LB[LB_i + 1]); //Берем из библиотеки оценку слова
                                            switch (Key)
                                            {
                                                case "PSTV":
                                                    {
                                                        Mood++;
                                                        //Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NGTV":
                                                    {
                                                        Mood--;
                                                        // Console.WriteLine(Mood);
                                                        //Console.WriteLine(LB[LB_i]);
                                                        break;
                                                    }
                                                case "NEUT":
                                                    {
                                                        //Console.WriteLine(RP[RP_i]);
                                                        break;
                                                    }
                                                default:
                                                    Console.WriteLine("Lost");
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    //Console.WriteLine("LostStrong");
                                    break;
                            }

                            if (step == 1) //выход после успешного сравнения
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine(Mood); //(Конечная оценка, в будущем будет вызываться ответ с класса MOOD)
                    Console.ReadKey();
                }

            }
        }
    }
}