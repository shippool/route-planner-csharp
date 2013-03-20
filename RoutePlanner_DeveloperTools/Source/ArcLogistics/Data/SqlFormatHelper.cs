using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

namespace ESRI.ArcLogistics.Data
{
    /// <summary>
    /// SQL formatting helper class.
    /// </summary>
    internal class SqlFormatHelper
    {
        private static readonly string[] LIKE_ESC = { "_", "%", "[", "^" };

        #region public methods
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Formats name of SQL object.
        /// </summary>
        public static string FormatObjName(string name)
        {
            Debug.Assert(name != null);

            return String.Format("[{0}]", name);
        }

        /// <summary>
        /// Escapes string for SQL LIKE operator.
        /// </summary>
        public static string EscapeLikeString(string str, char escapeChar)
        {
            Debug.Assert(str != null);

            string res = str.Replace(new String(new char[] { escapeChar }),
                new String(new char[] {escapeChar, escapeChar}));

            foreach (string esc in LIKE_ESC)
                res = res.Replace(esc, escapeChar + esc);

            return res;
        }

        /// <summary>
        /// Formats EntitySQL IN query to search objects by id.
        /// </summary>
        public static string FormatObjectsByIdInExpression(string tableName,
            string idFieldName,
            ICollection<Guid> ids)
        {
            Debug.Assert(tableName != null);
            Debug.Assert(idFieldName != null);
            Debug.Assert(ids != null);

            if (ids.Count == 0)
                throw new InvalidOperationException();

            StringBuilder sb = new StringBuilder();

            int nId = 0;
            foreach (Guid id in ids)
            {
                sb.AppendFormat("Guid\'{0}\'", id.ToString());
                if (nId < ids.Count - 1)
                    sb.Append(",");

                nId++;
            }

            return String.Format(QUERY_OBJECTS_BY_ID_IN_EXPRESSION,
                tableName,
                idFieldName,
                sb.ToString());
        }

        #endregion public methods

        #region private constants

        /// <summary>
        /// Query to DataBase.
        /// </summary>
        private const string QUERY_OBJECTS_BY_ID_IN_EXPRESSION = @"select value object from {0} as object where object.{1} in {{{2}}}";

        #endregion
    }
}