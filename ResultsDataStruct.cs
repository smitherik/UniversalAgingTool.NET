/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    Results data set to be used by the in application reporting of
               the aging results.
-------------------------------------------------------------------------------
    Modification History
  
    01/21/2020  Erik W. Smith
    [1:eof]
        Initial development.
-----------------------------------------------------------------------------*/
using System;

namespace universalAgingTool
{
    public class ResultsDataStruct
    {
        public string        File        { get; private set; }
        public DateTime      Date        { get; private set; }
        public string        DateColumn  { get; private set; }
        public string        ValueColumn { get; private set; }
        public AgedDataStore Data        { get; private set; }

        public ResultsDataStruct(string        file, 
                                 DateTime      date, 
                                 string        dateColumn, 
                                 string        valueColumn, 
                                 AgedDataStore data)
        {
            File        = file;
            Date        = date;
            DateColumn  = dateColumn;
            ValueColumn = valueColumn;
            Data        = data;
        }
    }
}
