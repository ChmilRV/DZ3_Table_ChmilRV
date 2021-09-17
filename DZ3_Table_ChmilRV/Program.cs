using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3_Table_ChmilRV
{
	class Program
	{
		public static TableServiceClient serviceClient;

		public static TableClient tableClient;

		// Get the connection string from app settings
		static string connectionString = "";

		static string tableName = "";

		static string partitionKey = "partitionKey123";

		static string rowKey = "rowKey456";

		static async Task Main(string[] args)
		{

         Console.WriteLine("Работа с таблицами Azure!");

         AppSettings appSettings = new AppSettings();
         connectionString = appSettings.StorageConnectionString;
         tableName = appSettings.TableName;


         serviceClient = new TableServiceClient(connectionString);

         // Создание таблиц
         await Class_Table_Operation.CreateTable(tableName);

         await Class_Table_Operation.CreateTable(tableName + "2");


         // Список таблиц
         await Class_Table_Operation.ListTable();

         tableClient = new TableClient(connectionString, tableName);

         // Create the table in the service.
         try
         {
            tableClient.CreateIfNotExists();
         }
         catch
         {
            Console.WriteLine($"Таблица {tableName} была создана ранее.");
         }


         Console.WriteLine("\nСписок созданных данных:");

         // Создание сущностей
         var entity = new TableEntity(partitionKey, rowKey)
                {
                    { "Product", "Tee" },
                    { "Price", 5.00 },
                    { "Quantity", 21 }
                };

         await Class_Entity_Operation.AddTableEntity(entity);

         entity = new TableEntity(partitionKey, rowKey + "7")
                {
                    { "Product", "Broad" },
                    { "Price", 25.00 },
                    { "Quantity", 1 },
                    { "Remark1", "No comment" }
                };

         await Class_Entity_Operation.AddTableEntity(entity);

         entity = new TableEntity(partitionKey, rowKey + "8")
                {
                    { "Product", "Water" },
                    { "Price", 7.00 },
                    { "Quantity", 5 },
                    { "Note1", "Comment1" },
                    { "Note2", "Comment2" }
                };

         await Class_Entity_Operation.AddTableEntity(entity);

         entity = new TableEntity(partitionKey, rowKey + "9")
                {
                    { "Name", "Water" },
                    { "Remark1", "Comment1" },
                    { "Remark2", "Comment2" }
                };

         await Class_Entity_Operation.AddTableEntity(entity);


         // Запрос сущностей
         Class_Entity_Operation.QueryToTableEntity();


         // Удаление сущностей
         Console.WriteLine("\nУдаление сущностей:");

         await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey);

         await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey + "7");

         await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey + "8");

         await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey + "9");


         // Удаление таблиц
         Console.WriteLine("\nУдаление таблиц:");

         await Class_Table_Operation.DropTable(tableName);
         await Class_Table_Operation.DropTable(tableName + "2");


         Console.ReadKey();

      }
	}
}
