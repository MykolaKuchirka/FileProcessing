using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingApplication
{
	internal static class ParsingEmptyCells
	{
        internal static object GetCellValue(this IRow row, int index)
        {
            var cell = row.GetCell(index);
            if (cell == null)
            {
                return 0;
            }
            return cell;
        }
    }
}
