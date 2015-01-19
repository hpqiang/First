using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LNDLWcfService.Common
{
    public static class CopyClass
    {
        public static T translateItem<T>(this Object myobj) where T : class
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                Type type = memberInfo.GetType();
                if (type.IsValueType || type == typeof(string))
                {
                    Console.WriteLine("Is Value or string Type" + type);
                }
                else if (type.IsArray)
                {
                    Console.WriteLine("Is Array Type\n");
                }
                else if (type.IsClass)
                {
                    Console.WriteLine("Is Class Type\n");
                    propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                    value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                    propertyInfo.SetValue(x, value, null);
                }
                else
                    throw new ArgumentException("Unknown type");
            }
            return (T)x;
        }  
    }
}

//public static object DeepCopy(object obj)
//    {
//        if (obj == null)
//            return null;
//        Type type = obj.GetType();

//        if (type.IsValueType || type == typeof(string))
//        {
//            return obj;
//        }
//        else if (type.IsArray)
//        {
//            Type elementType = Type.GetType(
//                 type.FullName.Replace("[]", string.Empty));
//            var array = obj as Array;
//            Array copied = Array.CreateInstance(elementType, array.Length);
//            for (int i = 0; i < array.Length; i++)
//            {
//                copied.SetValue(DeepCopy(array.GetValue(i)), i);
//            }
//            return Convert.ChangeType(copied, obj.GetType());
//        }
//        else if (type.IsClass)
//        {

//            object toret = Activator.CreateInstance(obj.GetType());
//            FieldInfo[] fields = type.GetFields(BindingFlags.Public |
//                        BindingFlags.NonPublic | BindingFlags.Instance);
//            foreach (FieldInfo field in fields)
//            {
//                object fieldValue = field.GetValue(obj);
//                if (fieldValue == null)
//                    continue;
//                field.SetValue(toret, DeepCopy(fieldValue));
//            }
//            return toret;
//        }
//        else
//            throw new ArgumentException("Unknown type");
//    }