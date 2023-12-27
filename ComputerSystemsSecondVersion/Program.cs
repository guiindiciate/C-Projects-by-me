using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.Json;
using ComputerSystems.Data;
using ComputerSystems.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ComputerSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

            DataContextDapper dapper = new(config);
            // Console.WriteLine(rightNow.ToString());

            // Computer myComputer = new Computer()
            // {
            //     MotherBoard = "Z690",
            //     HasWifi = true,
            //     HasLTE = false,
            //     ReleaseDate = DateTime.Now,
            //     Price = 943.87m,
            //     VideoCard = "RTX 2060"
            // };

            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     MotherBoard,
            //     HasWifi,
            //     HasLTE,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            // ) VALUES ('" + myComputer.MotherBoard
            //         + "','" + myComputer.HasWifi
            //         + "','" + myComputer.HasLTE
            //         + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //         + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
            //         + "','" + myComputer.VideoCard
            // + "')\n";

            // File.WriteAllText("log.txt", sql);

            string computersJson = File.ReadAllText("Computers.json");

            //Console.WriteLine(computersJson);

            // JsonSerializerOptions options = new() {

            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // };

            //IEnumerable<Computer>? computers = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);
            IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            // dotnet add package Newtonsoft.Json
            if (computers != null)
            {
                foreach (Computer computer in computers)
                {
                    //Console.WriteLine(computer.MotherBoard);
                }
            }

            string computersCopy = JsonConvert.SerializeObject(computers);

            File.WriteAllText("computersCopyNewtonsoft.txt", computersCopy);
        }

    }
}
