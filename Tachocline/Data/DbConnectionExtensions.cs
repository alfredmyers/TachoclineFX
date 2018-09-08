using System;
using System.Data;

namespace Tachocline.Data
{
    public static class DbConnectionExtensions
    {
        public static IDbCommand CreateCommand(this IDbConnection connection, string commandText)
        {
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            return command;
        }

        public static IDataReader ExecuteReader(this IDbConnection connection, string commandText)
        {
            return CreateCommand(connection, commandText).ExecuteReader();
        }

        public static IDataReader ExecuteReader(this IDbConnection connection, string commandText, CommandBehavior commandBehavior)
        {
            return CreateCommand(connection, commandText).ExecuteReader(commandBehavior);
        }

        public static object ExecuteScalar(this IDbConnection connection, string commandText)
        {
            using (var command = CreateCommand(connection, commandText))
            {
                return command.ExecuteScalar();
            }
        }
    }
}