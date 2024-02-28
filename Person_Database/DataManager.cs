using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Person_Database
{
    internal class DataManager
    {
        private static readonly string filePath;
        private static readonly Encoding encoding;
        private static readonly char separator;

        public static string[][] Data { get; private set; }

        static DataManager()
        {
            filePath = "Data\\file.csv";
            encoding = Encoding.Latin1;
            separator = ';';

            Data = ReadFile();
        }

        private static string[][] ReadFile()
        {
            string[] lines = File.ReadAllLines(filePath, encoding);
            string[][] data = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                data[i] = lines[i].Split(separator);
            }
            return data;
        }

        public static void WriteToFile()
        {
            using StreamWriter writer = new(filePath, false, encoding);

            for (int i = 0; i < Data.Length; i++)
            {
                writer.WriteLine(string.Join(separator, Data[i]));
            }

        }

        public static void AddData(string[] newRow)
        {
            string[][] newData = Data;
            Array.Resize(ref newData, Data.Length + 1);
            newData[^1] = newRow;
            Data = newData;
        }

        public static void RemoveData(int rowIndex)
        {
            if ((uint)rowIndex >= Data.Length)
            {
                throw new ArgumentException("Invalid row index.");
            }
            if (rowIndex < 0 || rowIndex >= Data.Length)
            {

            }

            string[][] newData = new string[Data.Length - 1][];

            int newIndex = 0;
            for (int i = 0; i < Data.Length; i++)
            {
                if (i != rowIndex)
                {
                    newData[newIndex] = Data[i];
                    newIndex++;
                }
            }

            Data = newData;
        }

        public static void ReplaceData(int rowIndex, string[] newRow)
        {
            if ((uint)rowIndex >= Data.Length)
            {
                throw new ArgumentException("Invalid row index.");
            }

            if (newRow.Length != Data[rowIndex].Length)
            {
                throw new ArgumentException("New row length must match existing rows.");
            }

            Data[rowIndex] = newRow;
        }
        public static string[][] FindRows(string searchString)
        {
            List<string[]> foundRows = [];

            if (Data != null)
            {
                foreach (string[] row in Data)
                {
                    foreach (string item in row)
                    {
                        if (item.Contains(searchString))
                        {
                            foundRows.Add(row);
                            break;
                        }
                    }
                }
            }

            return [.. foundRows];
        }
        public static bool CheckData(string[] data)
        {
            foreach (string item in data)
            {
                if (string.IsNullOrEmpty(item))
                {
                    MessageBox.Show($"Töltse ki a mezőket.", "Üres mezők", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            // Ellenőrzés 2: Nagybetűvel kezdődjön
            for (int i = 0; i < 2; i++)
            {
                string item = data[i];
                if (!char.IsUpper(item[0]))
                {
                    MessageBox.Show($"Nem nagy betűs kezdés.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }


            // Ellenőrzés 3: "4db szám "." 2szám "." 2 szám
            if (!Regex.IsMatch(data[2], @"^\d{4}\.\d{2}\.\d{2}$"))
            {
                MessageBox.Show($"Hibás dátum.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Ellenőrzés 4: Vagy Férfi vagy Nő
            if (data[3] != "Férfi" && data[3] != "Nő")
            {
                MessageBox.Show($"Hibás nem.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Ellenőrzés 5: csak szám, 7-essel kezdődik és 11 számjegy
            if (!Regex.IsMatch(data[4], @"^7\d{10}$"))
            {
                MessageBox.Show($"Hibás diákigazolvány szám.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true; // Ha minden ellenőrzés sikeres
        }
    }
}

