using System;
using System.Collections;
using System.Data;

namespace Tachocline.Data
{
    public static class DbCommandExtensions
    {
        public static IList GetSingleRowValues(this IDbCommand command)
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