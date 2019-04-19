using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StorageContext()) {
                while (true)
                {
                    Console.WriteLine("Что вы хотите сделать?");
                    Console.WriteLine("1)Просмотреть товары");
                    Console.WriteLine("2)Добавить товар");
                    Console.WriteLine("3)Изменить товар");
                    Console.WriteLine("4)Удалить товар");
                    Console.WriteLine("5)Выйти");

                    if (int.TryParse(Console.ReadLine(), out int result))
                    {
                        if (result == 1)
                        {
                            foreach (var product in context.Products)
                            {
                                Console.WriteLine($"{product.Name} - {product.Amount}");
                            }
                            Console.WriteLine("Нажмите enter для продолжения");
                        }
                        else if (result == 2)
                        {
                            Product product = new Product();
                            while (true)
                            {
                                Console.WriteLine("Введите название товара");
                                string name = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(name))
                                {
                                    product.Name = name;
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Введите количество товара на складе");
                                if (int.TryParse(Console.ReadLine(), out int amount))
                                {
                                    product.Amount = amount;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректные данные");
                                }
                            }
                            context.Products.Add(product);
                            Console.WriteLine("Товар успешно добавлен");
                        }
                        else if (result == 3)
                        {
                            int index = 1;
                            foreach (var product in context.Products)
                            {
                                Console.WriteLine($"{index}){product.Name} - {product.Amount}");
                                index++;
                            }
                            Console.WriteLine("Введите номер товара");
                            while (true)
                            {
                                if (int.TryParse(Console.ReadLine(), out int res) && res > 0 && res < context.Products.Count())
                                {
                                    Product product = new Product();

                                    Console.WriteLine("Введите новое название товара(если не нужно обновлять то нажмите enter)");

                                    string name = Console.ReadLine();

                                    if (string.IsNullOrEmpty(name))
                                    {
                                        product.Name = context.Products.ElementAt(res).Name;
                                    }
                                    else
                                    {
                                        product.Name = name;
                                    }

                                    Console.WriteLine("Введите новое количество товара(если не нужно обновлять то нажмите enter)");

                                    while (true)
                                    {
                                        string amount = Console.ReadLine();
                                        if (int.TryParse(amount, out int resAmount))
                                        {
                                            product.Amount = resAmount;
                                            break;
                                        }
                                        else if (string.IsNullOrEmpty(amount))
                                        {
                                            product.Amount = context.Products.ElementAt(res).Amount;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректный ввод");
                                        }
                                    }
                                    context.Products.ToList()[res] = product;
                                    context.SaveChanges();
                                    Console.WriteLine("Товар успешно обновлен");
                                }
                                else
                                {
                                    Console.WriteLine("Товара с таким номером не существует");
                                }
                            }
                        }
                        else if (result == 4)
                        {
                            int index = 1;
                            foreach (var product in context.Products)
                            {
                                Console.WriteLine($"{index}){product.Name} - {product.Amount}");
                                index++;
                            }
                            Console.WriteLine("Введите номер товара");
                            while (true)
                            {
                                if (int.TryParse(Console.ReadLine(), out int res) && res > 0 && res < context.Products.Count())
                                {
                                    for (int i = 0; i < context.Products.Count(); i++)
                                    {
                                        if (i + 1 == res)
                                        {
                                            context.Products.Remove(context.Products.ToList()[i + 1]);
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Товара с таким номером не существует");
                                }
                            }
                            context.SaveChanges();
                            Console.WriteLine("Товар успешно удален");
                        }
                        else if (result == 5)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Некорректные данные");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные");
                    }
                }
            }
        }
    }
}