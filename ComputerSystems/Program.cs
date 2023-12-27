using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using ComputerSystems.Data;
using ComputerSystems.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ComputerSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config =new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);

            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

            // Console.WriteLine(rightNow.ToString());

            Computer myComputer = new Computer()
            {
                MotherBoard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();


            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                MotherBoard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.MotherBoard
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                    + "','" + myComputer.VideoCard
            + "')";

            // Console.WriteLine(sql);

            // int result = dapper.ExecuteSqlWithRowCount(sql);
            bool result = dapper.ExecuteSql(sql);

            // Console.WriteLine(result);

            string sqlSelect = @"SELECT 
                Computer.ComputerId,
                Computer.MotherBoard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);


            foreach (Computer singleComputer in computers)
            {
                Console.WriteLine("ComputerId: " + singleComputer.ComputerId
                    + "', MotherBoard: '" + singleComputer.MotherBoard
                    + "', HasWifi: '" + singleComputer.HasWifi
                    + "', HasLTE: '" + singleComputer.HasLTE
                    + "', Release Date: '" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "', Price: '" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                    + "', VideoCard: '" + singleComputer.VideoCard
            + "'");
            }

            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

            if (computersEf != null) {

            foreach (Computer singleComputer in computersEf)
            {
                Console.WriteLine("ComputerId: " + singleComputer.ComputerId
                    + "',MotherBoard: " + singleComputer.MotherBoard
                    + "', HasWifi: '" + singleComputer.HasWifi
                    + "', HasLTE: '" + singleComputer.HasLTE
                    + "', Release Date: '" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "', Price: '" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                    + "', VideoCard: '" + singleComputer.VideoCard
            + "'");
            }
            }

            // myComputer.HasWifi = false;
            // Console.WriteLine(myComputer.MotherBoard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.ReleaseDate);
            // Console.WriteLine(myComputer.VideoCard);
        }

    }
}
