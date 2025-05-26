using System;

namespace DetectiveNovel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДЕТЕКТИВНАЯ ИСТОРИЯ: ТАЙНА СМЕРТИ ВОЛКОВА ===");
            Console.WriteLine("Вы — частный детектив, расследующий убийство бизнесмена Артема Волкова.\n");

            // Переменные для отслеживания выбора игрока
            bool hasEvidenceAgainstWife = false;
            bool hasEvidenceAgainstPartner = false;
            bool hasEvidenceAgainstMaid = false;
            bool knowsAboutSecretDeal = false;
            bool foundPoison = false;
            bool hasGun = false;
            bool knowsAboutGuard = false;
            bool foundKnife = false;
            bool hasVideoEvidence = false;
            bool isAlive = true;
            int stepsTaken = 0;

            while (isAlive && stepsTaken < 100) // Защита от бесконечного цикла
            {
                stepsTaken++;
                Console.WriteLine("\n=== Шаг " + stepsTaken + " ===");

                if (stepsTaken == 1)
                {
                    Console.WriteLine("Вы приезжаете в особняк Волкова. Где начнёте расследование?");
                    Console.WriteLine("1) Осмотреть кабинет, где нашли тело.");
                    Console.WriteLine("2) Поговорить с женой Волкова.");
                    Console.WriteLine("3) Расспросить горничную.");
                    Console.WriteLine("4) Позвать напарника для помощи.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("В кабинете следы борьбы. На столе — разбитая ваза и пятна крови.");
                            break;
                        case 2:
                            Console.WriteLine("Жена в слезах утверждает, что ничего не слышала, но её взгляд странный.");
                            hasEvidenceAgainstWife = true;
                            break;
                        case 3:
                            Console.WriteLine("Горничная нервничает и избегает прямых ответов.");
                            hasEvidenceAgainstMaid = true;
                            break;
                        case 4:
                            Console.WriteLine("Напарник помогает осмотреть дом, но вы теряете время.");
                            break;
                    }
                }
                else if (stepsTaken == 2)
                {
                    Console.WriteLine("Вы замечаете странный предмет. Что это?");
                    Console.WriteLine("1) Письмо с угрозами в ящике стола.");
                    Console.WriteLine("2) Ключ от сейфа под ковром.");
                    Console.WriteLine("3) Следы яда на бокале.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Письмо указывает на делового партнёра Волкова — Сергея Морозова.");
                            hasEvidenceAgainstPartner = true;
                            break;
                        case 2:
                            Console.WriteLine("В сейфе — документы о крупной сделке с тёмными махинациями.");
                            knowsAboutSecretDeal = true;
                            break;
                        case 3:
                            Console.WriteLine("Анализ покажет, был ли Волков отравлен.");
                            foundPoison = true;
                            break;
                    }
                }
                else if (stepsTaken == 3)
                {
                    Console.WriteLine("Вы решаете проверить телефон Волкова. Что ищете?");
                    Console.WriteLine("1) Последние звонки.");
                    Console.WriteLine("2) Переписку.");
                    Console.WriteLine("3) Удалённые файлы.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Последний звонок был от неизвестного номера.");
                            break;
                        case 2:
                            Console.WriteLine("В переписке угрозы от анонима.");
                            break;
                        case 3:
                            Console.WriteLine("Вы находите удалённое видео с подозрительной встречей.");
                            hasVideoEvidence = true;
                            break;
                    }
                }
                else if (stepsTaken == 4)
                {
                    Console.WriteLine("Вы замечаете, что горничная куда-то спешит. Что делать?");
                    Console.WriteLine("1) Проследить за ней.");
                    Console.WriteLine("2) Обыскать её комнату.");
                    Console.WriteLine("3) Игнорировать.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Она идёт в сад и что-то закапывает. Это может быть улика!");
                            hasEvidenceAgainstMaid = true;
                            break;
                        case 2:
                            Console.WriteLine("В её комнате находите украденные деньги.");
                            break;
                        case 3:
                            Console.WriteLine("Вы упускаете важный момент.");
                            break;
                    }
                }
                else if (stepsTaken == 5)
                {
                    Console.WriteLine("На столе в кабинете лежит пистолет. Что делать?");
                    Console.WriteLine("1) Взять его с собой.");
                    Console.WriteLine("2) Оставить на месте.");
                    Console.WriteLine("3) Проверить, стрелял ли он.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Теперь у вас есть оружие на случай опасности.");
                            hasGun = true;
                            break;
                        case 2:
                            Console.WriteLine("Вы оставляете пистолет, но кто-то может его украсть.");
                            break;
                        case 3:
                            Console.WriteLine("Оружие недавно стреляло. Это ключевая улика!");
                            break;
                    }
                }
                else if (stepsTaken == 6)
                {
                    Console.WriteLine("Вы встречаете охранника. Он ведёт себя подозрительно. Ваши действия?");
                    Console.WriteLine("1) Допросить его.");
                    Console.WriteLine("2) Пройти мимо.");
                    Console.WriteLine("3) Проверить его телефон.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Охранник нервничает, но ничего не говорит.");
                            break;
                        case 2:
                            Console.WriteLine("Вы упускаете возможного свидетеля.");
                            break;
                        case 3:
                            Console.WriteLine("В его телефоне переписка с неизвестным о 'больших деньгах'.");
                            knowsAboutGuard = true;
                            break;
                    }
                }
                else if (stepsTaken == 7)
                {
                    Console.WriteLine("Вы находите дневник Волкова. Что в нём?");
                    Console.WriteLine("1) Записи о конфликте с женой.");
                    Console.WriteLine("2) Финансовые махинации.");
                    Console.WriteLine("3) Упоминание тайного врага.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Он подозревал, что жена ему изменяет.");
                            hasEvidenceAgainstWife = true;
                            break;
                        case 2:
                            Console.WriteLine("Волков был замешан в отмывании денег.");
                            knowsAboutSecretDeal = true;
                            break;
                        case 3:
                            Console.WriteLine("Кто-то угрожал ему за неделю до смерти.");
                            break;
                    }
                }
                else if (stepsTaken == 8)
                {
                    Console.WriteLine("Вы слышите шум на втором этаже. Что делать?");
                    Console.WriteLine("1) Подняться и проверить.");
                    Console.WriteLine("2) Позвать на помощь.");
                    Console.WriteLine("3) Игнорировать.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вы застаёте делового партнёра Волкова, роющегося в бумагах. Он бросается на вас!");
                            if (hasGun)
                            {
                                Console.WriteLine("Вы достаёте пистолет и обезвреживаете его. Он признаётся в убийстве!");
                                hasEvidenceAgainstPartner = true;
                            }
                            else
                            {
                                Console.WriteLine("Он толкает вас с лестницы. Концовка: Смертельное падение.");
                                isAlive = false;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Напарник приходит, но преступник уже скрылся.");
                            break;
                        case 3:
                            Console.WriteLine("Шум прекращается. Вы упускаете шанс поймать преступника.");
                            break;
                    }
                }
                else if (stepsTaken == 9)
                {
                    Console.WriteLine("Вы обнаруживаете потайную комнату. Что там?");
                    Console.WriteLine("1) Деньги и документы.");
                    Console.WriteLine("2) Орудие убийства.");
                    Console.WriteLine("3) Ничего важного.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вы находите доказательства финансовых махинаций.");
                            knowsAboutSecretDeal = true;
                            break;
                        case 2:
                            Console.WriteLine("Это нож с кровью — вероятно, орудие убийства!");
                            foundKnife = true;
                            break;
                        case 3:
                            Console.WriteLine("Комната пуста.");
                            break;
                    }
                }
                else if (stepsTaken == 10)
                {
                    Console.WriteLine("Жена Волкова предлагает вам крупную сумму за прекращение расследования. Ваши действия?");
                    Console.WriteLine("1) Принять деньги и уйти.");
                    Console.WriteLine("2) Отказаться и продолжить расследование.");
                    Console.WriteLine("3) Притвориться, что согласен, но собрать доказательства.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вы берёте деньги, но позже вас находят мёртвым. Концовка: Предательство.");
                            isAlive = false;
                            break;
                        case 2:
                            Console.WriteLine("Вы продолжаете расследование.");
                            break;
                        case 3:
                            Console.WriteLine("Жена не подозревает, что вы записываете её признание.");
                            hasEvidenceAgainstWife = true;
                            break;
                    }
                }
                else if (stepsTaken == 11)
                {
                    Console.WriteLine("Вы сталкиваетесь с подозреваемым в тёмном коридоре. Что делать?");
                    Console.WriteLine("1) Напасть первым.");
                    Console.WriteLine("2) Попытаться договориться.");
                    Console.WriteLine("3) Спрятаться и наблюдать.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (hasGun)
                            {
                                Console.WriteLine("Вы обезвреживаете преступника.");
                            }
                            else
                            {
                                Console.WriteLine("Он ранит вас. Концовка: Смерть в темноте.");
                                isAlive = false;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Он убегает, но вы узнаёте важную деталь.");
                            break;
                        case 3:
                            Console.WriteLine("Вы подслушиваете его разговор — это ключ к разгадке!");
                            break;
                    }
                }
                else if (stepsTaken == 12)
                {
                    Console.WriteLine("Вы находите записи камер наблюдения. Что с ними делать?");
                    Console.WriteLine("1) Просмотреть последние часы.");
                    Console.WriteLine("2) Взять с собой и изучить позже.");
                    Console.WriteLine("3) Игнорировать.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вы видите, как кто-то подсыпал яд в бокал Волкова.");
                            foundPoison = true;
                            break;
                        case 2:
                            Console.WriteLine("Вы забираете записи, но позже их кто-то крадёт.");
                            break;
                        case 3:
                            Console.WriteLine("Вы упускаете важное доказательство.");
                            break;
                    }
                }
                else if (stepsTaken == 13)
                {
                    Console.WriteLine("К вам подходит неизвестный и предлагает информацию за деньги. Ваши действия?");
                    Console.WriteLine("1) Заплатить.");
                    Console.WriteLine("2) Отказаться.");
                    Console.WriteLine("3) Задержать его.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Он говорит, что убийца — деловой партнёр.");
                            hasEvidenceAgainstPartner = true;
                            break;
                        case 2:
                            Console.WriteLine("Он уходит, но вы теряете возможную зацепку.");
                            break;
                        case 3:
                            Console.WriteLine("Он оказывается мелким мошенником и ничего не знает.");
                            break;
                    }
                }
                else if (stepsTaken == 14)
                {
                    Console.WriteLine("Вы понимаете, что за вами следят. Что делать?");
                    Console.WriteLine("1) Устроить засаду.");
                    Console.WriteLine("2) Быстро уйти.");
                    Console.WriteLine("3) Игнорировать.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (hasGun)
                            {
                                Console.WriteLine("Вы ловите преследователя — это наёмный убийца!");
                            }
                            else
                            {
                                Console.WriteLine("Он нападает на вас. Концовка: Загадочная смерть.");
                                isAlive = false;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Вы скрываетесь, но теряете след убийцы.");
                            break;
                        case 3:
                            Console.WriteLine("Преследователь нападает ночью. Концовка: Трагический финал.");
                            isAlive = false;
                            break;
                    }
                }
                else if (stepsTaken == 15)
                {
                    Console.WriteLine("Вы находите письмо с угрозами от таинственного 'В.' Что делать?");
                    Console.WriteLine("1) Сравнить почерк с другими документами.");
                    Console.WriteLine("2) Показать жене.");
                    Console.WriteLine("3) Оставить как улику.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Почерк совпадает с деловым партнёром!");
                            hasEvidenceAgainstPartner = true;
                            break;
                        case 2:
                            Console.WriteLine("Она бледнеет и убегает. Подозрительно!");
                            hasEvidenceAgainstWife = true;
                            break;
                        case 3:
                            Console.WriteLine("Вы сохраняете улику для дальнейшего расследования.");
                            break;
                    }
                }
                else if (stepsTaken == 16)
                {
                    Console.WriteLine("Вы решаете проверить финансовые операции Волкова. Что находите?");
                    Console.WriteLine("1) Крупный перевод перед смертью.");
                    Console.WriteLine("2) Поддельные документы.");
                    Console.WriteLine("3) Ничего подозрительного.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Деньги ушли на счёт жены. Мотив налицо!");
                            hasEvidenceAgainstWife = true;
                            break;
                        case 2:
                            Console.WriteLine("Волков был замешан в афере.");
                            knowsAboutSecretDeal = true;
                            break;
                        case 3:
                            Console.WriteLine("Финансы в порядке, но это ничего не объясняет.");
                            break;
                    }
                }
                else if (stepsTaken == 17)
                {
                    Console.WriteLine("Вы сталкиваетесь с горничной в подвале. Она что-то прячет. Ваши действия?");
                    Console.WriteLine("1) Обыскать её.");
                    Console.WriteLine("2) Пригрозить полицией.");
                    Console.WriteLine("3) Пройти мимо.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вы находите ключ от тайника с деньгами.");
                            hasEvidenceAgainstMaid = true;
                            break;
                        case 2:
                            Console.WriteLine("Она сознаётся, что видела убийцу, но боится говорить.");
                            break;
                        case 3:
                            Console.WriteLine("Вы упускаете важную улику.");
                            break;
                    }
                }
                else if (stepsTaken == 18)
                {
                    Console.WriteLine("Вы понимаете, что кто-то пытается вас подставить. Что делать?");
                    Console.WriteLine("1) Уничтожить фальшивые улики.");
                    Console.WriteLine("2) Обратиться за помощью.");
                    Console.WriteLine("3) Игнорировать.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вы устраняете угрозу, но теряете время.");
                            break;
                        case 2:
                            Console.WriteLine("Напарник помогает вам раскрыть заговор.");
                            break;
                        case 3:
                            Console.WriteLine("Вас арестовывают по ложному обвинению. Концовка: Тюрьма.");
                            isAlive = false;
                            break;
                    }
                }
                else if (stepsTaken == 19)
                {
                    Console.WriteLine("Вы находите тайник с оружием и наркотиками. Что делать?");
                    Console.WriteLine("1) Взять как улику.");
                    Console.WriteLine("2) Вызвать полицию.");
                    Console.WriteLine("3) Оставить.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Это может быть связано с убийством.");
                            break;
                        case 2:
                            Console.WriteLine("Полиция забирает улики, но расследование усложняется.");
                            break;
                        case 3:
                            Console.WriteLine("Вы упускаете важную зацепку.");
                            break;
                    }
                }
                else if (stepsTaken == 20)
                {
                    Console.WriteLine("Вы собрали все улики. Кто убийца?");
                    Console.WriteLine("1) Жена (у неё был мотив — измена Волкова).");
                    Console.WriteLine("2) Деловой партнёр (конфликт из-за денег).");
                    Console.WriteLine("3) Горничная (она что-то скрывает).");
                    Console.WriteLine("4) Охранник (был подкуплен).");
                    Console.WriteLine("5) Это был несчастный случай.");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (hasEvidenceAgainstWife)
                            {
                                Console.WriteLine("Вы арестовали жену. Она признаётся — это месть за измену. Концовка: Правосудие восторжествовало!");
                            }
                            else
                            {
                                Console.WriteLine("Жена оказывается невиновна. Настоящий убийца скрылся. Концовка: Провал.");
                            }
                            isAlive = false;
                            break;
                        case 2:
                            if (hasEvidenceAgainstPartner)
                            {
                                Console.WriteLine("Партнёр сознаётся — убийство из-за финансовых махинаций. Концовка: Дело закрыто!");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно доказательств. Убийца остаётся на свободе. Концовка: Холодное дело.");
                            }
                            isAlive = false;
                            break;
                        case 3:
                            if (hasEvidenceAgainstMaid)
                            {
                                Console.WriteLine("Горничная пыталась скрыть кражу, но убийство совершил кто-то другой. Концовка: Частичный успех.");
                            }
                            else
                            {
                                Console.WriteLine("Горничная невиновна. Вы упустили настоящего преступника. Концовка: Позор.");
                            }
                            isAlive = false;
                            break;
                        case 4:
                            if (knowsAboutGuard)
                            {
                                Console.WriteLine("Охранник сознаётся, что его подкупили. Концовка: Заговор раскрыт!");
                            }
                            else
                            {
                                Console.WriteLine("Нет доказательств против охранника. Концовка: Несправедливость.");
                            }
                            isAlive = false;
                            break;
                        case 5:
                            Console.WriteLine("Вы ошиблись. Убийца остаётся безнаказанным. Концовка: Трагедия.");
                            isAlive = false;
                            break;
                    }
                }
            }

            Console.WriteLine("\n=== Игра окончена! Спасибо за участие! ===");
            Console.ReadLine();
        }
    }
}
