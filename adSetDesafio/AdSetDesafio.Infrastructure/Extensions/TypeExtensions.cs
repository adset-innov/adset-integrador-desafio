using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq.Expressions;

namespace AdSetDesafio.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        public static string FriendlyId(this Type type, bool fullyQualified = false)
        {
            var typeName = fullyQualified
                ? type.FullNameSansTypeParameters().Replace("+", ".")
                : type.Name;

            if (type.IsGenericType)
            {
                var genericArgumentIds = type.GetGenericArguments()
                    .Select(t => t.FriendlyId(fullyQualified))
                    .ToArray();

                return new StringBuilder(typeName)
                    .Replace(string.Format("`{0}", genericArgumentIds.Count()), string.Empty)
                    .Append(string.Format("[{0}]", string.Join(",", genericArgumentIds).TrimEnd(',')))
                    .ToString();
            }

            return typeName;
        }

        public static string FullNameSansTypeParameters(this Type type)
        {
            var fullName = type.FullName;

            if (string.IsNullOrEmpty(fullName))
                fullName = type.Name;

            var chopIndex = fullName.IndexOf("[[");

            return (chopIndex == -1) ? fullName : fullName.Substring(0, chopIndex);
        }

        public static string[] GetEnumNamesForSerialization(this Type enumType)
        {
            return enumType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .Select(fieldInfo =>
                {
                    var memberAttribute = fieldInfo.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
                    return (memberAttribute == null || string.IsNullOrWhiteSpace(memberAttribute.Value))
                        ? fieldInfo.Name
                        : memberAttribute.Value;
                })
                .ToArray();
        }

        private static Dictionary<Type, string> TypesToFriendlyNames = new Dictionary<Type, string>
        {
            {typeof(bool), "bool"},
            {typeof(byte), "byte"},
            {typeof(sbyte), "sbyte"},
            {typeof(char), "char"},
            {typeof(decimal), "decimal"},
            {typeof(double), "double"},
            {typeof(float), "float"},
            {typeof(int), "int"},
            {typeof(uint), "uint"},
            {typeof(long), "long"},
            {typeof(ulong), "ulong"},
            {typeof(object), "object"},
            {typeof(short), "short"},
            {typeof(ushort), "ushort"},
            {typeof(string), "string"}
        };

        public static IEnumerable<FieldInfo> GetConstants(this Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
        }

        public static IEnumerable<T> GetConstantsValues<T>(this Type type) where T : class
        {
            return type.GetConstants().Select(c => c.GetRawConstantValue() as T);
        }

        public static string GetFriendlyName(this Type type)
        {
            if (type.IsArray)
                return type.GetFriendlyNameOfArrayType();
            if (type.IsGenericType)
                return type.GetFriendlyNameOfGenericType();
            if (type.IsPointer)
                return type.GetFriendlyNameOfPointerType();
            var aliasName = default(string);
            return TypesToFriendlyNames.TryGetValue(type, out aliasName)
                ? aliasName
                : type.Name;
        }

        private static string GetFriendlyNameOfArrayType(this Type type)
        {
            var arrayMarker = string.Empty;
            while (type.IsArray)
            {
                var commas = new string(Enumerable.Repeat(',', type.GetArrayRank() - 1).ToArray());
                arrayMarker += $"[{commas}]";
                type = type.GetElementType();
            }
            return type.GetFriendlyName() + arrayMarker;
        }

        private static string GetFriendlyNameOfGenericType(this Type type)
        {
            if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type.GetGenericArguments().First().GetFriendlyName() + "?";

            var friendlyName = type.Name;
            var indexOfBacktick = friendlyName.IndexOf('`');

            if (indexOfBacktick > 0)
                friendlyName = friendlyName.Remove(indexOfBacktick);

            var typeParameterNames = type
                .GetGenericArguments()
                .Select(typeParameter => typeParameter.GetFriendlyName());
            var joinedTypeParameters = string.Join(", ", typeParameterNames);

            return string.Format("{0}<{1}>", friendlyName, joinedTypeParameters);
        }

        private static string GetFriendlyNameOfPointerType(this Type type) =>
            type.GetElementType().GetFriendlyName() + "*";

        public static string ReductionTo(this string propertie, int size)
        {
            return !string.IsNullOrWhiteSpace(propertie) && propertie.Length > size
                ? propertie.Remove(size)
                : propertie;
        }

        public static int ConvertInt(this string value)
        {
            _ = int.TryParse(value, out int valueInt);
            return valueInt;
        }

        public static int? ConvertIntNull(this string value)
        {
            int? result = null;

            if (int.TryParse(value, out int valueInt))
                result = valueInt;

            return result;
        }

        public static long ConvertLong(this string value)
        {
            _ = long.TryParse(value, out long valueLong);
            return valueLong;
        }

        public static long? ConvertLongNull(this string value)
        {
            long? result = null;

            if (long.TryParse(value, out long valueLong))
                result = valueLong;

            return result;
        }

        public static decimal ConvertDecimal(this string value)
        {
            _ = decimal.TryParse(value, out decimal valueDecimal);
            return valueDecimal;
        }

        public static decimal? ConvertDecimalNull(this string value)
        {
            decimal? result = null;

            if (!string.IsNullOrWhiteSpace(value))
            {
                List<Match> blocos = new Regex("[0-9]+").Matches(value).ToList();

                string newValue = string.Empty;
                if (blocos.Count > 1)
                {
                    foreach (Match valor in blocos)
                    {
                        if (valor == blocos.Last())
                            newValue += CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                        newValue += valor.Value;
                    }
                }
                else
                    newValue = value;

                decimal parse;
                if (Decimal.TryParse(newValue, out parse))
                    result = parse;

            }

            return result;
        }

        public static DateTime ConvertDateTime(this string value)
        {
            var style = DateTimeStyles.None;
            var culture = CultureInfo.CreateSpecificCulture("pt-BR");
            _ = DateTime.TryParse(value, culture, style, out DateTime valueDateTime);

            return valueDateTime;
        }

        public static DateTime? ConvertDateTimeNull(this string value)
        {
            DateTime? result = null;
            var style = DateTimeStyles.None;
            var culture = CultureInfo.CreateSpecificCulture("pt-BR");

            if (DateTime.TryParse(value, culture, style, out DateTime valueDateTime))
                result = valueDateTime;

            return result;
        }

        public static string FirstAndLastWords(this string text)
        {
            var words = text.Split(" ");

            if (words.Length >= 2)
                return $"{words[0]} {words[words.Length - 1]}";
            else
                return string.Empty;
        }

        public static bool HasValue<T>(this List<T> value) where T : class
        {
            return value != null && value.Count > 0;
        }

        public static bool HasValue<T>(this IEnumerable<T> value) where T : class
        {
            return value != null && value.Any();
        }

        public static bool HasValue(this IEnumerable<int> value)
        {
            return value != null && value.Any();
        }

        public static bool InValues<T>(this T target, params T[] range) => range.Contains(target);

        public static bool NotInValues<T>(this T target, params T[] range) => !InValues(target, range);

        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        public static bool HasValue(this string value) => !value.IsNullOrWhiteSpace();

        /// <summary>
        /// Function <c>HasDuplicates</c> return <c>true</c> if any value is duplicated. (<paramref name="keySelector"/> is lambda expression to check keys, <paramref name="duplicates"/> out var to duplicated keys).
        /// </summary>
        /// <param name="keySelector">lambda function to key check. Exemples: <code>x => x.Id </code> or <code>x => new {x.Key1, x.Key2}</code> </param>
        /// <param name="duplicates">out enumerable list with distinct duplicates keys for keySelector expression.</param>
        public static bool HasDuplicates<TSource, TKey>(
            this IEnumerable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            out IEnumerable<TKey> duplicates)
        {

            //Não alterar tipos das variaveis nem converter as expressões. 
            //A perfomance foi refinada ao máximo possível para essa implementação levando em conta arquivos com mais de 13k linhas.
            //Está custando em média ~15ms 

            HashSet<TKey> discardList = new(capacity: source.Count());
            HashSet<TKey> duplicatedItens = new();
            _ = source.Select(keySelector.Compile())
                .ToList()
                .All(key => discardList.Add(key) || !duplicatedItens.Add(key) || true);

            bool hasDuplicatedItem = duplicatedItens.Any();

            duplicates = hasDuplicatedItem ? duplicatedItens.Distinct() : default;

            return hasDuplicatedItem;
        }

        public static string JoinText<T>(this IEnumerable<T> source, string textToJoin) => string.Join(textToJoin, source);
    }
}