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

		static string tableName = "myazuretablechmilrv";

		static string partitionKey = "";

		static string rowKey = "";

		static async Task Main(string[] args)
		{

         Console.WriteLine("Работа с таблицами Azure!");

         AppSettings appSettings = new AppSettings();
         connectionString = appSettings.StorageConnectionString;
         tableName = appSettings.TableName;


         serviceClient = new TableServiceClient(connectionString);

         // Создание таблиц
         await Class_Table_Operation.CreateTable(tableName);

         
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
         var entity = new TableEntity("1", "1")
                {
                    { "Id", 1 },
                    { "Name", "Вася"  },
                    { "Price", 21.9 }
                };
         await Class_Entity_Operation.AddTableEntity(entity);

         entity = new TableEntity("1", "2")
                {
                    { "Id", 2 },
                    { "Name", "Федя"  },
                    { "Price", 33.5 },
                    { "Remark", "Без комментариев" }
                };
         await Class_Entity_Operation.AddTableEntity(entity);

         entity = new TableEntity("2", "3")
                {
                    { "Id", 3 },
                    { "Name", "Михаил"  },
                    { "Price", 77.22 },
                    { "Remark", "" },
                    { "Note", "Это примечание"}
                };
         await Class_Entity_Operation.AddTableEntity(entity);


         // Запрос сущностей
         Class_Entity_Operation.QueryToTableEntity();


         // Удаление сущностей
         //Console.WriteLine("\nУдаление сущностей:");

         //await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey);

         //await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey + "7");

         //await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey + "8");

         //await Class_Entity_Operation.DeleteTableEntity(partitionKey, rowKey + "9");


         // Удаление таблиц
         //Console.WriteLine("\nУдаление таблиц:");

         //await Class_Table_Operation.DropTable(tableName);
         //await Class_Table_Operation.DropTable(tableName + "2");


         Console.ReadKey();

      }
	}
}
