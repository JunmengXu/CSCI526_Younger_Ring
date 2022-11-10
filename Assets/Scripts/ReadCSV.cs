using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class ReadCSV : MonoBehaviour 
{
    private static char _csvSeparator = ',';
    private static bool _trimColumns = false;
    //Get the format of a cell
    public static string GetCSVFormat(string str)
    {
        string tempStr = str;
        if (str.Contains(","))
        {
            if (str.Contains("\""))
            {
                tempStr = str.Replace("\"", "\"\"");
            }
            tempStr = "\"" + tempStr + "\"";
        }
        return tempStr;
    }

    //Get the format of a line
    public static string GetCSVFormatLine(List<string> strList)
    {
        string tempStr = "";
        for (int i = 0; i < strList.Count - 1; i++)
        {
            string str = strList[i];
            tempStr = tempStr + GetCSVFormat(str) + ",";
        }
        tempStr = tempStr + GetCSVFormat(strList[strList.Count - 1]) + "\r\n";
        return tempStr;
    }

    //Parse a line
    public static List<string> ParseLine(string line)
    {
        StringBuilder _columnBuilder = new StringBuilder();
        List<string> Fields = new List<string>();
        bool inColum = false;//Whether it is in a cell
        bool inQuotes = false;//Whether it is in a quote
        bool isNotEnd = false;//Whether it is the end of the line
        _columnBuilder.Remove(0, _columnBuilder.Length);

        //An empty line is an empty element, and a comma is 2 empty elements
        if (line == "")
        {
            Fields.Add("");
        }
        // Iterate through every character in the line
        for (int i = 0; i < line.Length; i++)
        {
            char character = line[i];

            //If we are not currently inside a column
            if (!inColum)
            {
                // If the current character is a double quote then the column value is contained within
                // double quotes, otherwise append the next character
                inColum = true;
                if (character == '"')
                {
                    inQuotes = true;
                    continue;
                }
            }
            // If we are in between double quotes
            if (inQuotes)
            {
                if ((i + 1) == line.Length)//this is the last character
                {
                    if (character == '"')//this line is end
                    {
                        inQuotes = false;
                        continue;
                    }
                    else // End with error
                    {
                        isNotEnd = true;
                    }
                }
                else if (character == '"' && line[i + 1] == _csvSeparator)
                {
                    inQuotes = false;
                    inColum = false;
                    i++;//jump over the comma
                }
                //
                else if (character == '"' && line[i + 1] == '"')//escape the quotes
                {
                    i++;//jump over the next character
                }
                // If the current character is double quotes, this is a format error
                else if (character == '"')
                {
                    throw new System.Exception("Format Error: wrong double quotes");
                }
                // Otherwise append the current character
            }
            else if (character == _csvSeparator)
            {
                inColum = false;
            }
            // If we are no longer in the column clear the builder and add the columns to the list
            if (!inColum)
            {
                Fields.Add(_trimColumns ? _columnBuilder.ToString().Trim() : _columnBuilder.ToString());
                _columnBuilder.Remove(0, _columnBuilder.Length);
            }
            else
            {
                _columnBuilder.Append(character);
            }
        }
 
        // If we are still inside a column add a new one
        if (inColum)
        {
            if (isNotEnd)
            {
                _columnBuilder.Append("\r\n");
            }
            Fields.Add(_trimColumns ? _columnBuilder.ToString().Trim() : _columnBuilder.ToString());
        }
        //If we are not in a column, add a new one
        else
        {
            Fields.Add("");
        }
        return Fields;
    }

    //Read the CSV file
    public static List<List<string>> Read(string filePath, Encoding encoding)
    {
        List<List<string>> result = new List<List<string>>();
        //Read all texts
        string content = File.ReadAllText(filePath, encoding);
        //Split each line by \r\n
        //This may be a problem on some csv files, you can try to replace \r\n with \n
        string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lines.Length; i++)
        {
            List<string> line = ParseLine(lines[i]);
            result.Add(line);
        }
        return result;
    }
}
