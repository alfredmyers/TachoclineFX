using System;
using System.Collections;
using System.Data;

namespace TachoclineFX 
{
    public static class DbCommandExtensions
    {
        public static IList GetSingleRowValues(IDbCommand command)
        {
            using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
            {
                var values = new object[reader.FieldCount];

                if (!reader.Read())
                {
                    return null;
                }

                reader.GetValues(values);

                return values;
            }
        }
    }
}