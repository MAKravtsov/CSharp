using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping
{
    class Program
    {
        static void Main(string[] args)
        {
            //var group1 = new Group("2|3|5|6|1|4", 120);
            //var group2 = new Group("3|5|4", 65);
            //var group3 = new Group("1|2|4|5|6", 95);
            //var group4 = new Group("1|3|5|4|2", 100);
            //var group5 = new Group("4|5|1|2|3|6", 90);
            //var group6 = new Group("1|2", 40);
            //var group7 = new Group("3|6", 35);
            //var group8 = new Group("5|2", 55);
            //var group9 = new Group("2|6", 38);
            //var group10 = new Group("3|5|4|2|6|1", 107);
            //var group11 = new Group("3|5", 47);
            //var group12 = new Group("1", 23);
            //var groups = new Group[] { group5, group1, group4, group10, group3, group6, group7, group8, group9, group2, group11, group12 };

            //var group1 = new Group("1|2|3|4|5", 20);
            //var group2 = new Group("3|4|5|2|1", 40);
            //var group3 = new Group("3|5", 50);
            //var group4 = new Group("3|4|5", 20);
            //var group5 = new Group("2", 30);
            //var group6 = new Group("3", 90);
            //var group7 = new Group("2|3", 9);
            //var group8 = new Group("2|1", 17);
            //var group9 = new Group("3|2", 3);
            //var groups = new Group[] { group1, group2, group3, group4, group5, group6, group7, group8, group9 };

            //var group1 = new Group("1|2|3", 40);
            //var group2 = new Group("2|1", 50);
            //var group3 = new Group("2", 100);
            //var group4 = new Group("1", 20);
            //var group5 = new Group("3", 11);
            //var groups = new Group[] { group1, group2, group3, group4, group5 };

            //var groups = new List<Group>();
            //string ras = "Цех расточной обработки";
            //string sm = "Смешанный цех";
            //string fr = "Цех фрезерной обработки";
            //string tok_sv = "Цех токарно-сверлильной обработки";

            //groups.AddRange(DetailToGroup("Вал",$"{sm}", 195, 50));
            //groups.AddRange(DetailToGroup("Корпус", $"{fr}|{tok_sv}|{sm}", 225, 30));
            //groups.AddRange(DetailToGroup("Втулка", $"{ras}|{tok_sv}", 25, 500));
            //groups.AddRange(DetailToGroup("Ступица", $"{fr}|{sm}", 315, 40));
            //groups.AddRange(DetailToGroup("Стакан", $"{ras}|{tok_sv}|{sm}", 105, 200));
            //groups.AddRange(DetailToGroup("Колесо", $"{ras}|{fr}|{sm}", 265, 100));
            //groups.AddRange(DetailToGroup("Рычаг", $"{ras}|{tok_sv}|{sm}|{fr}", 150, 60));
            //groups.AddRange(DetailToGroup("Штуцер", $"{sm}", 12, 600));
            //groups.AddRange(DetailToGroup("Клапан", $"{sm}|{ras}|{tok_sv}", 35, 250));
            //groups.AddRange(DetailToGroup("Крыша", $"{fr}|{sm}", 330, 35));

            var group1 = new Group("detail1","2|3|5|1|4", 165);
            var group2 = new Group("detail2", "3|5|4", 160);
            var group3 = new Group("detail3", "1|2|4|5|3", 175);
            var group4 = new Group("detail4", "1|3|5|4|2", 185);
            var group5 = new Group("detail5", "1|2", 75);
            var group6 = new Group("detail6", "3|5", 85);
            var group7 = new Group("detail7", "1|4", 100);
            var group8 = new Group("detail8", "1|2|3", 140);
            var group9 = new Group("detail9", "2|5", 105);
            var group10 = new Group("detail10", "4|5|1|2", 160);
            var group11 = new Group("detail11", "4|5", 80);
            var group12 = new Group("detail12", "1", 45);
            var groups = new Group[] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10, group11, group12 };

            var allGroups = new AllGroups(groups.ToArray());

            ToUniqueGroups(ref allGroups, groups.ToArray());

            int avgTime = (int)Math.Ceiling((double)groups.Sum(y => y.time) / allGroups.uniqueGroups.Count());
            int maxTimeofGroup = groups.Max(y => y.time);
            int minTime = avgTime > maxTimeofGroup ? avgTime : maxTimeofGroup;

            List<int> calctime = new List<int>() { minTime };
            List<UniqueGroup> _uniqueGroups = null;
            int step = (int)Math.Ceiling(0.1 * minTime);
            while (_uniqueGroups == null)
            {
                _uniqueGroups = ToGrouping(allGroups, minTime);
                if (_uniqueGroups == null)
                {
                    //minTime += allGroups.nonuniqueGroups.Min(y => y.time);
                    //minTime += 1;
                    minTime += step;
                    Console.WriteLine(minTime);
                    calctime.Add(minTime);
                }
            }

            int cnt = calctime.Count();
            if (cnt > 1)
            {
                int timeLast = calctime[cnt - 1];
                int timePredLast = calctime[cnt - 2];

                while ((timeLast - timePredLast) > 1)
                {
                    int calcTime = timeLast - (timeLast - timePredLast) / 2;
                    var _endUniqueGroups = ToGrouping(allGroups, calcTime);
                    Console.WriteLine(calcTime);
                    if (_endUniqueGroups == null)
                        timePredLast = calcTime;
                    else
                    {
                        _uniqueGroups = _endUniqueGroups;
                        timeLast = calcTime;
                    }
                }
            }

            allGroups.uniqueGroups = _uniqueGroups;

            int cn = 1;
            foreach(var unique in allGroups.uniqueGroups)
            {
                Console.Write($"{cn} группа: Маршрут - {unique.itenerary.Replace("|", "->")}|");
                var result = unique.daughters.GroupBy(y => y).Select(y => new { y.Key, count = y.Count() });
                var _cn = 1;
                foreach(var elem in result)
                {
                    if (_cn < result.Count())
                        Console.Write("{0} - {1}шт.   ", elem.Key, elem.count);
                    else
                        Console.Write("{0} - {1}шт.", elem.Key, elem.count);
                    _cn++;
                }
                Console.WriteLine($"|time - {unique.time}");
                cn++;
            }
            Console.ReadLine();
        }

        public static void ToUniqueGroups(ref AllGroups allGroups, Group[] groups)
        {
            var uniqueGroups = allGroups.uniqueGroups;
            var nonuniqueGroups = allGroups.nonuniqueGroups;

            foreach (var group in groups.OrderByDescending(y => y.itenerary.Count()))
            {
                var arr = group.itenerary.Split('|');
                if (uniqueGroups.All(y => !IsArrayEqual(y.itenerary.Split('|').Intersect(arr).ToArray(), arr)))
                {
                    uniqueGroups.Add(new UniqueGroup(group.name, group.itenerary, group.time));
                    uniqueGroups.Last().daughters.Add(group.name);
                }
                else
                    nonuniqueGroups.Add(new NonuniqueGroup(group.name, group.itenerary, group.time));
            }

            foreach (var nonuniqueGroup in nonuniqueGroups)
            {
                var arr = nonuniqueGroup.itenerary.Split('|');

                nonuniqueGroup.parents.AddRange(uniqueGroups.Where(y => IsArrayEqual( y.itenerary.Split('|').Intersect(arr).ToArray(), arr)).Select(y => y.name));

                UniqueGroup uniqueGroup = uniqueGroups.FirstOrDefault(y => y.name == nonuniqueGroup.parents[0]);
                if (nonuniqueGroup.parents.Count() == 1)
                {
                    uniqueGroup.time += nonuniqueGroup.time;
                    uniqueGroup.daughters.Add(nonuniqueGroup.name);
                    nonuniqueGroup.parents = null;
                }

            }

            allGroups.uniqueGroups = uniqueGroups;
            allGroups.nonuniqueGroups = nonuniqueGroups.Where(y => y.parents != null).ToList();
        }

        public static List<UniqueGroup> ToGrouping(AllGroups allGroups, int minTime)
        {
            // Соаздаем дубли уникальных и неуникальных групп для дальнейшей работы с ними
            var _unique_groups = new List<UniqueGroup>();
            allGroups.uniqueGroups.ForEach(y => _unique_groups.Add(new UniqueGroup(y.name, y.itenerary, y.time, y.daughters)));
            var nonunique_groups = new List<NonuniqueGroup>();
            allGroups.nonuniqueGroups.ForEach(y => nonunique_groups.Add(new NonuniqueGroup(y.name, y.itenerary, y.time, y.parents))); ;

            // считаем суммарный стэк
            int stack = minTime * _unique_groups.Count() - allGroups.groups.Sum(y => y.time);

            // КОСТЫЛЬ с порядком
            var unique_groups = new List<UniqueGroup>();
            foreach (var it in allGroups.groups)
            {
                var t = _unique_groups.FirstOrDefault(y => y.itenerary == it.itenerary);
                if (t != null && !unique_groups.Contains(t))
                    unique_groups.Add(t);
            }

            foreach (var unique_group in unique_groups)
            {
                // Если после расчета других уникальных групп оказалось так, что остались неуникальные с 1 родителем, то засовываем неуникальные к родителю сразу
                if (nonunique_groups.Any(y => y.parents.Count() == 1))
                {
                    var oneParent = new List<NonuniqueGroup>();
                    oneParent.AddRange(nonunique_groups.Where(y => y.parents.Count() == 1));
                    foreach (var non in oneParent)
                    {
                        nonunique_groups.RemoveAt(nonunique_groups.IndexOf(non));
                        var parent = unique_groups.Where(y => y.name == non.parents[0]).FirstOrDefault();
                        parent.daughters.Add(non.name);
                        parent.time += non.time;

                        if (parent.time > minTime)
                            return null;
                    }
                }

                int diff = minTime - unique_group.time;

                // Подходящие неуникальные группы (если стек станет < 0, то уберем максимальное время, чтобы рассмотреть другие вариантыы)
                var suitableGroups = new List<NonuniqueGroup>();
                suitableGroups.AddRange(nonunique_groups.Where(k => k.time <= diff && k.parents.Contains(unique_group.name)).OrderBy(y => y.parents.Count()).OrderByDescending(y => y.time));

                // Повторяем до тех пор, пока стэк не будет > 0 или если это невозможно, то пока не кончатся варианты
                while (suitableGroups.Any())
                {
                    // Запоминаем уникальные группы, которые куда-то распределили
                    var goodNonunique = new List<NonuniqueGroup>();
                    int difference = diff;
                    for (int i = 0; i < suitableGroups.Count(); i++)
                    {
                        // Проверяем, можно ли положить данную неуникальную группу в уникальную
                        if (difference - suitableGroups[i].time < 0)
                            continue;
                        // Если да, то запоминаем и отнимаем difference
                        difference -= suitableGroups[i].time;
                        goodNonunique.Add(suitableGroups[i]);
                    }

                    // Если стэк получился меньше 0, повторяем распределение с другими неуникальными группами
                    if (stack - difference < 0)
                    {
                        suitableGroups.RemoveAt(0);
                        continue;
                    }

                    // Если распределение прошло нормально, то добаляем дочку уникальной группе и увеличиваем ей время
                    unique_group.daughters.AddRange(goodNonunique.Select(y => y.name));
                    unique_group.time += goodNonunique.Sum(y => y.time);

                    diff = difference;

                    // Удаляем "забранные" уникальные группы
                    foreach (var elem in goodNonunique)
                        nonunique_groups.Remove(nonunique_groups.Where(y => y.itenerary == elem.itenerary && y.time == elem.time).FirstOrDefault());
                    // у оставшихся уникальных групп удаляем родителя, который только что расссматривали
                    foreach (var n in nonunique_groups.Where(y => y.parents.Contains(unique_group.itenerary)))
                        n.parents.Remove(unique_group.name);
                    // Если все рассчиталос. выходим из цикла
                    break;
                }

                // Если все возможные распределения к этой уникальной группе были рассмотрены, а стэк меньше 0, то выходим из метода
                if (!suitableGroups.Any() && stack - diff < 0)
                    return null;

                stack -= diff;
            }

            // после полного расчета проверяем, чтобы стэк был равен 0 и все неуникальные группы мы включили
            if (stack != 0 || nonunique_groups.Any())
                return null;

            return unique_groups;
        }

        public static bool IsArrayEqual(string[] a, string[] b)
        {
            if (a.Count() != b.Count())
                return false;

            for(int i = 0; i < a.Count(); i++)
                if (a[i] != b[i])
                    return false;

            return true;
        }

        public static Group[] DetailToGroup (string name, string iten, int time, int cnt)
        {
            var toReturn = new List<Group>();
            for (int i = 0; i < cnt; i++)
            {
                toReturn.Add(new Group(name, iten, time));
            }
            return toReturn.ToArray();
        }
    }
}
