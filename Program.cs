using System;
using System.Collections.Generic;

namespace ph
{
    public class Programm
    {
        /*
         Вывод выбора действий программы
        1) Создание новой записи в телефонной книге
        2) Редактирование информации в записи
        3) Удаление записи
        4) Вывод информации из выбранной записи
        5) Вывод краткой информации о всех записях
        6) Завершение работы программы
        */
        static void Intro() 
        {
            Console.WriteLine("PPPPP P   P PPPPP P   P PPPPP  PPPP  PPPPP PPPPP P    P");
            Console.WriteLine("P     P   P P   P P   P P      P   P P   P P   P P P P");
            Console.WriteLine("PPPPP PPPPP P   P PP  P P      PPPP  P   P P   P PP");
            Console.WriteLine("P     P   P P   P P P P PPPPP  P   P P   P P   P P  P");
            Console.WriteLine("P     P   P P   P P  PP P      P   P P   P P   P P   P");
            Console.WriteLine("P     P   P PPPPP P   P PPPPP  PPPPP PPPPP PPPPP P    P" + "\n");
            //Красивый ввывод названия программы в консоль ^
            Console.WriteLine("Нажмите a, чтобы создать контакт" + "\n" + "Нажмите b, чтобы редактировать информацию о контакте" + "\n" + "Нажмите c, чтобы удалить контакт");
            Console.WriteLine("Нажмите d, чтобы увидеть выбранный контакт" + "\n" + "Нажмите e, чтобы увидеть список всех контактов" + "\n" + "Нажмите x, чтобы завершить работу" + "\n");
        }

        public static bool IsNeccesaryValue(string value) //Проверка на ввод для обязательных пунктов
        {
            if (value.Length == 0) return false;
            else return true;
            Console.WriteLine("Эти сведения обязательны для заполнения");
        }

        static void Main(string[] args)
        {
            Intro();
            string button;
            PhoneBook phonebook = new PhoneBook();
            while (true)
            {
                Console.WriteLine("Выберите действие"); // выбор действия для пользователя (с проверкой, есть ли записи в телефонной книге)
                button = Console.ReadLine();
                switch (button)
                {
                    case "a":
                        phonebook.contactnew();
                        break;
                    case "b":
                        {
                            if (PhoneBook.phonebook.Count == 0) Console.WriteLine("Необходимо добавить запись");
                            else
                            {
                                int contactNumber = int.Parse(Console.ReadLine());
                                phonebook.contactedit(contactNumber);
                                break;
                            }
                            break;
                        }
                    case "c":
                        {
                            if (PhoneBook.phonebook.Count == 0) Console.WriteLine("Необходимо добавить запись");
                            else
                            {
                                int contactNumber = int.Parse(Console.ReadLine());
                                phonebook.contactdelete(contactNumber);
                                break;
                            }
                            break;
                        }
                    case "d":
                        {
                            if (PhoneBook.phonebook.Count == 0) Console.WriteLine("Необходимо добавить запись");
                            else
                            {
                                int contactNumber = int.Parse(Console.ReadLine());
                                phonebook.contactviewselected(contactNumber);
                                break;
                            }
                            break;
                        }
                    case "e":
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("Необходимо добавить запись");
                        else
                        {
                            phonebook.contactviewall();
                            break;
                        }
                        break;
                    case "x":
                        Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Введенна неправильная команда");
                        break;
                }

            }


        }
    }
    public class PhoneBook
    {
        public static List<Person> phonebook = new List<Person>();

        public List<Person> contactnew() //Создание новой записи в списке
        {
            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите отчество: ");
            string patronymic = Console.ReadLine();

            string phone;
            while (true)
            {
                Console.WriteLine("Введите номер телефона (доступны только цифры): ");
                    phone = Console.ReadLine();
                if (int.TryParse(phone, out int number))
                {
                    break;
                }
                Console.WriteLine("Неверный ввод");
            }

            Console.WriteLine("Введите страну: ");
            string country = Console.ReadLine();
            Console.WriteLine("Введите дату рождения (в формате: дд.мм.гггг): ");
            string dateofbirth = Console.ReadLine();
            Console.WriteLine("Введите компанию: ");
            string corp = Console.ReadLine();
            Console.WriteLine("Введите позицию в списке: ");
            string pos = Console.ReadLine();
            Console.WriteLine("Введите доп. информацию: ");
            string info = Console.ReadLine();

            Person person = new Person(surname, name, patronymic, phone, country, dateofbirth, corp, pos, info);
            phonebook.Add(person);
            return phonebook;

        }
        public List<Person> contactedit(int entrynumber) //Редактирование элементов из списка путем создания новых
        {
            Console.Write("1 - фамилия" + "\n" + "2 - имя" + "\n" + "3 - отчество" + "\n" + "4 - номер телефона" + "\n" + "5 - страна" + "\n" + "6 - дата рождения" + "\n" );
            Console.WriteLine("7 - компания" + "\n" + "8 - позиция в списке" + "\n" + "9 - доп. информация" + "\n" + "Для выхода в главное меню дважды нажмите Enter");
            while (true)
            {
                Console.Write("Введите номер параметра: ");
                int parameter;
                int.TryParse(Console.ReadLine(), out parameter);
                Console.Write("Введите новое значение: ");
                string newValue = Console.ReadLine();

                if (parameter == 4)
                {
                    while (true)
                     {
                        if (Programm.IsNeccesaryValue(newValue))
                        {
                             if (int.TryParse(newValue, out int number))
                             {
                                 phonebook[entrynumber].Phone = newValue;
                                        
                             }
                            Console.WriteLine("Доступны только цифры: ");
                            Console.Write("Введите новое значение: ");
                            newValue = Console.ReadLine();
                        }
                    }
                }
                if (newValue == "stop" || parameter == 0) break;

                if (parameter == 1)
                {
                    while (true)
                    {
                        if (Programm.IsNeccesaryValue(newValue))
                        {
                            phonebook[entrynumber].SurName = newValue;
                            break;
                        }
                        Console.Write("Введите новое значение: ");
                        newValue = Console.ReadLine();
                    }
                }
                else if (parameter == 2)
                {
                    while (true)
                    {
                        if (Programm.IsNeccesaryValue(newValue))
                        {
                            phonebook[entrynumber].Name = newValue;
                            break;
                        }
                        Console.Write("Введите новое значение: ");
                        newValue = Console.ReadLine();
                    }
                }
                else if (parameter == 3) phonebook[entrynumber].Patronymic = newValue;
                else if (parameter == 5)
                {
                    while (true)
                    {
                        if (Programm.IsNeccesaryValue(newValue))
                        {
                            phonebook[entrynumber].Country = newValue;
                            break;
                        }
                        Console.Write("Введите новое значение: ");
                        newValue = Console.ReadLine();
                    }
                }
                else if (parameter == 6) phonebook[entrynumber].DateOfBirth = newValue;
                else if (parameter == 7) phonebook[entrynumber].Corp = newValue;
                else if (parameter == 8) phonebook[entrynumber].Pos = newValue;
                else phonebook[entrynumber].Info = newValue;
            }
            return phonebook;
        }
        public List<Person> contactdelete(int entrynumber) //Удаление записи из телефонной книги
        {
            phonebook.RemoveAt(entrynumber);
            return phonebook;
        }

        public void contactviewselected(int entrynumber) //Просмотр выбранной записи (полная информация)
        {
            Console.WriteLine($"Фамилия: {phonebook[entrynumber].SurName}");
            Console.WriteLine($"Имя: {phonebook[entrynumber].Name}");
            Console.WriteLine($"Отчество {phonebook[entrynumber].Patronymic}");
            Console.WriteLine($"Номер телефона {phonebook[entrynumber].Phone}");
            Console.WriteLine($"Старан: {phonebook[entrynumber].Country}");
            Console.WriteLine($"Дата рождения: {phonebook[entrynumber].DateOfBirth}");
            Console.WriteLine($"Компания: {phonebook[entrynumber].Corp}");
            Console.WriteLine($"Место в списке: {phonebook[entrynumber].Pos}");
            Console.WriteLine($"Доп. информация: {phonebook[entrynumber].Info}");
        }

        public void contactviewall() //Просмотр краткой информации о всех записях из телефонной книги
        {
            foreach (Person person in phonebook)
            {
                Console.Write($"Фамилия: {person.SurName}, ");
                Console.Write($"Имя: {person.Name}, ");
                Console.WriteLine($"Номер телефона: {person.Phone}");

            }
        }
    }


    public class Person //Пременные используемые для создания записей в списке
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; } 
        public string Corp { get; set; }
        public string Pos { get; set; }
        public string Info { get; set; }

        public Person(string surname, string name, string patronymic, string phone, string country, string dateofbirth, string corp, string pos, string info)
        {
            SurName = surname;
            Name = name;
            Patronymic = patronymic;
            Phone = phone;
            Country = country;
            DateOfBirth = dateofbirth;
            Corp = corp;
            Pos = pos;
            Info = info;
        }
    }
}