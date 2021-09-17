using Azure;
using Azure.Data.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3_Table_ChmilRV
{
	static class Class_Table_Operation
	{

      public static async Task CreateTable(string tableName)
      {
         try
         {
            // Create a new table. The TableItem class stores properties of the created table.
            TableItem table = await Program.serviceClient.CreateTableIfNotExistsAsync(tableName);
            Console.WriteLine($"Имя созданной таблицы - {table.Name}.");
         }
         catch
         {
            Console.WriteLine($"Таблица {tableName} была создана ранее.");
         }
         return;
      }


      public static async Task ListTable()
      {
         AsyncPageable<TableItem> queryTableResults = Program.serviceClient.QueryAsync();

         Console.WriteLine("\nСписок таблиц в хранилище:");

			await foreach (TableItem table in queryTableResults)
         {
            Console.WriteLine(table.Name);
         }
         return;
      }


      public static async Task DropTable(string tableName)
      {
         // Deletes the table made previously.
         await Program.serviceClient.DeleteTableAsync(tableName);
         Console.WriteLine($"Таблица {tableName} удалена.");
         return;
      }




   }
}
