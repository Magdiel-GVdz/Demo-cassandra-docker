using System;
using Cassandra;

namespace CassandraDatabaseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder cassandraBuilder = Cluster.Builder();
            cassandraBuilder.AddContactPoint("127.0.0.2");
            var cluster = cassandraBuilder.Build();
            ISession session = cluster.Connect("demo");
            RowSet rowSet = session.Execute("select * from users");
            foreach (var row in rowSet)
            {
                Console.WriteLine(row[0]);
            }

            // Esperar a que el usuario presione una tecla antes de salir
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

