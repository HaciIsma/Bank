using System;

namespace ATM
{
    public class Controller
    {
        enum Operation { Balance = 1, Cash, OperationList, CardToCard }

        private int Find(string pin)
        {
            for (int i = 0; i < user.Length; i++)
            {
                if (pin == user[i].CreditCard.PIN)
                {
                    return i;
                }
            }
            return -1;
        }
        public void control()
        {
            user[0] = new User
            {
                Name = "Haci",
                Surname = "Ismayilov",
                CreditCard = new Card
                {
                    PAN = "3214551441026642",
                    PIN = "4046",
                    CVC = "442",
                    ExpireDate = "11/26/2019",
                    Balance = 1000m
                }
            };
            user[1] = new User
            {
                Name = "Kami",
                Surname = "Aliyev",
                CreditCard = new Card
                {
                    PAN = "3412047888426353",
                    PIN = "4359",
                    CVC = "641",
                    ExpireDate = "11/26/2019",
                    Balance = 1000m
                }
            };
            user[2] = new User
            {
                Name = "Hakuna",
                Surname = "Matata",
                CreditCard = new Card
                {
                    PAN = "6452182498202064",
                    PIN = "6139",
                    CVC = "483",
                    ExpireDate = "11/26/2019",
                    Balance = 1000m
                }
            };
            user[3] = new User
            {
                Name = "Eloset",
                Surname = "memmedov",
                CreditCard = new Card
                {
                    PAN = "3180033050866877",
                    PIN = "6923",
                    CVC = "942",
                    ExpireDate = "11/26/2019",
                    Balance = 1000m
                }
            };
            user[4] = new User
            {
                Name = "Ali",
                Surname = "Aliyev",
                CreditCard = new Card
                {
                    PAN = "6445314467522875",
                    PIN = "2182",
                    CVC = "976",
                    ExpireDate = "11/26/2019",
                    Balance = 1000m
                }
            };


            do
            {
                Console.Write("Pin daxil edin: ");
                pin = Console.ReadLine();
                id = Find(pin);
                Console.WriteLine("Sistemde bele bir pin yoxdur: {0}", pin);
                Console.Clear();
            } while (id == -1);

            Console.WriteLine("{0} {1} xos gelmisiniz zehmet olmasa asagidakilardan birini secerdiniz", user[id].Name, user[id].Surname);

            while (true)
            {
                input = default(int);
                Console.WriteLine("1.Balans\n2.Nagd pul\n3.Emeliyyatlarin siyahisi\n4.Kart'dan - kart'a pul kocurme");
                Console.Write("Seciminiz: ");
                do
                {
                    check = int.TryParse(Console.ReadLine(), out input);
                    if (check)
                    {
                        switch (input)
                        {
                            case (int)Operation.Balance:
                                Console.Clear();
                                Console.WriteLine("Balance: {0}", user[id].CreditCard.Balance);
                                dataBaseManager.AddDataForBase("Balansa baxis");
                                break;
                            case (int)Operation.Cash:
                                {
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1. 10 AZN\n2. 20 AZN\n3. 50 AZN\n4. 100 AZN\n5.Diger");
                                        Console.Write("Seciminiz: ");
                                        check = int.TryParse(Console.ReadLine(), out input);
                                        if (check)
                                        {
                                            switch (input)
                                            {
                                                case 1:
                                                    if (user[id].CreditCard.Balance - 10 < 0)
                                                    {
                                                        Console.WriteLine("Balansda yeterli qeder mebleg yoxdur");
                                                        break;
                                                    }
                                                    cash = 10;
                                                    user[id].CreditCard.Balance -= 10;
                                                    break;
                                                case 2:
                                                    if (user[id].CreditCard.Balance - 20 < 0)
                                                    {
                                                        Console.WriteLine("Balansda yeterli qeder mebleg yoxdur");
                                                        break;
                                                    }
                                                    cash = 20;
                                                    user[id].CreditCard.Balance -= 20;
                                                    break;
                                                case 3:
                                                    if (user[id].CreditCard.Balance - 50 < 0)
                                                    {
                                                        Console.WriteLine("Balansda yeterli qeder mebleg yoxdur");
                                                        break;
                                                    }
                                                    cash = 50;
                                                    user[id].CreditCard.Balance -= 50;
                                                    break;
                                                case 4:
                                                    if (user[id].CreditCard.Balance - 100 < 0)
                                                    {
                                                        Console.WriteLine("Balansda yeterli qeder mebleg yoxdur");
                                                        break;
                                                    }
                                                    cash = 100;
                                                    user[id].CreditCard.Balance -= 100;
                                                    break;
                                                case 5:
                                                    do
                                                    {
                                                        Console.Write("Istediyiniz meblegi daxil edin: ");
                                                        check = int.TryParse(Console.ReadLine(), out input);
                                                        if (check)
                                                        {
                                                            int num = input;
                                                            if (user[id].CreditCard.Balance - num < 0)
                                                            {
                                                                Console.WriteLine("Balansda yeterli qeder mebleg yoxdur");
                                                                break;
                                                            }
                                                            cash = num;
                                                            user[id].CreditCard.Balance -= num;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Xeta");
                                                            Console.ReadLine();
                                                        }
                                                    } while (!check);
                                                    break;
                                                default:
                                                    Console.WriteLine("Bele bir secim movcud deyil");
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Xeta");
                                            Console.ReadLine();
                                        }
                                    } while (!check);
                                    dataBaseManager.AddDataForBase($"Nagd: {cash} AZN");
                                }
                                break;
                            case (int)Operation.OperationList:
                                {
                                    dataBaseManager.ShowAllData();
                                }
                                break;
                            case (int)Operation.CardToCard:
                                {
                                    do
                                    {
                                        Console.Clear();
                                        Console.Write("Pin daxil edin: ");
                                        transferPin = Console.ReadLine();
                                        transferId = Find(transferPin);
                                        if (pin == transferPin)
                                        {
                                            Console.WriteLine("Xeta");
                                            Console.ReadLine();
                                            transferId = -1;
                                        }
                                        else
                                        {
                                            if (transferId == -1)
                                            {
                                                Console.WriteLine("Bu PIN koda aid kart tapilmadi");
                                                Console.ReadLine();
                                            }
                                        }
                                    } while (transferId == -1);
                                    do
                                    {
                                        Console.Write("Gondermek istediyiniz mebleg: ");
                                        check = int.TryParse(Console.ReadLine(), out input);
                                        if (check)
                                        {
                                            transferMoney = input;
                                            decimal persent = (transferMoney * 1.5m) / 100;
                                            if (user[id].CreditCard.Balance - (transferMoney + persent) < 0)
                                            {
                                                Console.WriteLine("Balans da lazimi qeder pul yoxdur");
                                            }
                                            else
                                            {
                                                user[id].CreditCard.Balance -= (transferMoney + persent);
                                                user[transferId].CreditCard.Balance += transferMoney;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Xeta");
                                            Console.ReadLine();
                                        }
                                    } while (!check);
                                    //
                                    dataBaseManager.AddDataForBase($"Kart'dan Karta pul kocurme: {transferMoney} AZN");
                                }
                                break;
                            default:
                                Console.WriteLine("Bele bir secim movcud deyil");
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Xeta");
                        break;
                    }
                    Console.WriteLine("Menu qayitmaq ucun basin");
                    Console.ReadLine();
                } while (!check);
                Console.Clear();
            }
        }
        User[] user = new User[5];
        DataBaseManager dataBaseManager = new DataBaseManager();
        int input = default(int);
        int cash = default(int);
        bool check = default(bool);
        int id = default(int);
        string pin = default(string);
        string transferPin = default(string);
        int transferId = default(int);
        int transferMoney = default(int);
    }
}