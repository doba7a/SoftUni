using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(nameOfClass);
        FieldInfo[] allFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(classType);

        sb.AppendLine($"Class under investigation: {nameOfClass}");

        foreach (FieldInfo field in allFields.Where(f => namesOfFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string nameOfClass)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(nameOfClass);

        FieldInfo[] allFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
        foreach (FieldInfo field in allFields.Where(f => f.IsPublic))
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string nameOfClass)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(nameOfClass);

        sb.AppendLine($"All Private Methods of Class: {nameOfClass}")
            .AppendLine($"Base Class: {classType.BaseType.Name}");

        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (MethodInfo method in nonPublicMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string nameOfClass)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(nameOfClass);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}

