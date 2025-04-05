using System;
using System.IO;

public static class SQLiteHelper
{
    public static string GetConnectionString()
    {
        string klasorYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Veriler");
        string veritabaniYolu = Path.Combine(klasorYolu, "arsiv.db");

        return $"Data Source={veritabaniYolu};Version=3;";
    }
}
