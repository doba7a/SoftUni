using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        FieldInfo[] privateFields = null;
        FieldInfo[] protectedFields = null;
        FieldInfo[] publicFields = null;
        FieldInfo[] allFields = null;

        Type classType = Type.GetType("HarvestingFields");
        StringBuilder sb = new StringBuilder();

        string input = Console.ReadLine();

        while (input != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    if (privateFields == null)
                    {
                        privateFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                    }

                    foreach (FieldInfo field in privateFields.Where(f => f.Attributes.ToString() == "Private"))
                    {
                        sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "protected":
                    if (protectedFields == null)
                    {
                        protectedFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                    }

                    foreach (FieldInfo field in protectedFields.Where(f => f.Attributes.ToString() == "Family"))
                    {
                        sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "public":
                    if (publicFields == null)
                    {
                        publicFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
                    }

                    foreach (FieldInfo field in publicFields)
                    {
                        sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "all":
                    if (allFields == null)
                    {
                        allFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    }

                    foreach (FieldInfo field in allFields)
                    {
                        if (field.Attributes.ToString() == "Family")
                        {
                            sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                        else
                        {
                            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(sb.ToString().TrimEnd());
    }
}

